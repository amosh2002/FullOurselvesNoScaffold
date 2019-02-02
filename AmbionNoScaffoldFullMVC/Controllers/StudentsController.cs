using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmbionNoScaffoldFullMVC.Models;

namespace AmbionNoScaffoldFullMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AmbionNoScaffoldFullMVCContext _context;

        public StudentsController(AmbionNoScaffoldFullMVCContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            string GradeIdFromSearchFilter = Request.Query.FirstOrDefault(x => x.Key == "[0].CurrentGradeID").Value;

            IQueryable<Grade> allGrades = from grd in _context.Grade
                                          where grd.GradeStatus == true
                                          select grd;


            IQueryable<Grade> filteredGrade = from o in _context.Grade
                                              where o.GradeStatus == true
                                              where o.GradeId == Int32.Parse(GradeIdFromSearchFilter)
                                              select o;

            IQueryable<Student> filteredStudentsByGrade =
                  from s in _context.Student
                  from g in filteredGrade
                  from a in _context.Ambion

                  where s.CurrentGradeID == g.GradeId
                  where s.CurrentAmbionID == a.AmbionId

                  select new Student
                  {
                      Ambion = a,
                      Grade = g,
                      Id = s.Id,
                      StudentName = s.StudentName
                  };

            IQueryable<Student> allStudents =
                  from a in _context.Ambion
                  from s in _context.Student
                  from g in _context.Grade

                  where s.CurrentAmbionID == a.AmbionId
                  where s.CurrentGradeID == g.GradeId

                  where a.AmbionStatus == true
                  where g.GradeStatus == true

                  select new Student
                  {
                      Grade = g,
                      Id = s.Id,
                      Ambion = a,
                      StudentName = s.StudentName
                  };


            ViewData["AllDistinctGradesSelectlist"] = new SelectList(await allGrades.Distinct().ToListAsync(), "GradeId", "GradeName");

            List<Student> returningStudents = null;

            if (GradeIdFromSearchFilter == null)
            {
                returningStudents = await allStudents.ToListAsync();
            }
            else
            {
                returningStudents = await filteredStudentsByGrade.ToListAsync();
            }
            return View(returningStudents);
        }

        public async Task<IActionResult> Create()
        {

            IQueryable<Grade> AllGrades = from m in _context.Grade
                                          where m.GradeStatus == true
                                          orderby m.GradeId
                                          select m;


            IQueryable<Ambion> AllAmbions = from a in _context.Ambion
                                            where a.AmbionStatus == true
                                            orderby a.AmbionId
                                            select a;

            ViewData["AllDistinctGradesSelectlist"] = new SelectList(await AllGrades.Distinct().ToListAsync(), "GradeId", "GradeName");
            ViewData["AllDistinctAmbionsSelectlist"] = new SelectList(await AllAmbions.Distinct().ToListAsync(), "AmbionId", "AmbionName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(g => g.Grade)
                .Include(a => a.Ambion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IQueryable<Grade> allGrades = from grd in _context.Grade
                                          where grd.GradeStatus == true
                                          select grd;

            IQueryable<Ambion> allAmbions = from amb in _context.Ambion
                                            where amb.AmbionStatus == true
                                            select amb;

            ViewData["AllDistinctGradesSelectList"] = new SelectList(await allGrades.Distinct().ToListAsync(), "GradeId", "GradeName");
            ViewData["AllDistinctAmbionsSelectList"] = new SelectList(await allAmbions.Distinct().ToListAsync(), "AmbionId", "AmbionName");

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentName,CurrentGradeID,CurrentAmbionID")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(g => g.Grade)
                .Include(a => a.Ambion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }

    }
}
