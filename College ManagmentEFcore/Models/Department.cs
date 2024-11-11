using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_ManagmentEFcore.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        [Required]
        public string DeptName { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }

        public virtual ICollection<Course>? Courses { get; set; }

        public virtual ICollection<Exam>? Exams { get; set; }
    }
}
