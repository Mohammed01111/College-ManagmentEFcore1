using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_ManagmentEFcore.Models
{
    public class Faculty
    {
        [Key]
        public int FID { get; set; }

        [Required]
        public string FacultyName { get; set; }

        [Range(500, 4000)]
        public double Salary { get; set; }

        public string FDepartment { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<student>? Students { get; set; }

        public virtual ICollection<Subject>? Subjects { get; set; }
    }
}

