using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmbionNoScaffoldFullMVC.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        [Required]
        public string GradeName { get; set; }
        [Required]
        public bool GradeStatus { get; set; }

        public ICollection<Student> GradeStudents { get; set; }

        [NotMapped]
        public SelectList Gradener { get; set; }

    }
}
