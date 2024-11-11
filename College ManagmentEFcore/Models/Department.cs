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
        public int Id { get; set; }

        public string DName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
