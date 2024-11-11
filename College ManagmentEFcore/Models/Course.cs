using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_ManagmentEFcore.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        [Range(1, 5)]
        public decimal Duration { get; set; }

        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<StudentCourse> StudentsInCourse { get; set; }
    }
}
