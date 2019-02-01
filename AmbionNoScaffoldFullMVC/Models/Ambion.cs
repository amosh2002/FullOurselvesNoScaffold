﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmbionNoScaffoldFullMVC.Models
{
    public class Ambion
    {
        [Key]
        public int AmbionId { get; set; }
        [Required]
        public string AmbionName { get; set; }
        [Required]
        public bool AmbionStatus { get; set; }

        public ICollection<Student> AmbionStudents { get; set; }

        [NotMapped]
        public SelectList Ambionner { get; set; }
    }
}
