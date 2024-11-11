using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_ManagmentEFcore.Models
{

   
    public class StudentPhone
    {
        [Key]
        public int StId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }


        public virtual student Student { get; set; }
    }
    
}
