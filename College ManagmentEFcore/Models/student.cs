using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static College_ManagmentEFcore.Models.Facultymobile;

namespace College_ManagmentEFcore.Models
{
    public class student
    {
        [Key]
        public int SID { get; set; }

        public string SName { get; set; }
        [Required]
        public int Age { get; set; }

        [Required]
        public string Phone { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("Hostel")]
        public int HostelId { get; set; }

        public virtual Department Department { get; set; }

        public virtual hostel Hostel { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }


    }
}
