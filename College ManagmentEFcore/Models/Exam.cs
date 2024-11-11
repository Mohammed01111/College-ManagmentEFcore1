using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace College_ManagmentEFcore.Models
{

    public class Exam
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<student> Students { get; set; }
    }
}
