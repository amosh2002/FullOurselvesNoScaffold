using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AmbionNoScaffoldFullMVC.Models
{
    public class AmbionNoScaffoldFullMVCContext : DbContext
    {
        public AmbionNoScaffoldFullMVCContext (DbContextOptions<AmbionNoScaffoldFullMVCContext> options)
            : base(options)
        {
        }

        public DbSet<AmbionNoScaffoldFullMVC.Models.Student> Student { get; set; }
        public DbSet<AmbionNoScaffoldFullMVC.Models.Grade> Grade { get; set; }
        public DbSet<AmbionNoScaffoldFullMVC.Models.Ambion> Ambion { get; set; }
    }
}
