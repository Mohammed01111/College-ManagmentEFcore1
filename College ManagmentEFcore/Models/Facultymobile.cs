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
    public class Facultymobile
    {
        public class StudentPhone
        {
            [Key]
            public int FacultyMobileId { get; set; }

            [ForeignKey("Faculty")]
            public int FacultyId { get; set; }

            public string MobileNumber { get; set; }


            public virtual Faculty Faculty { get; set; }
        }

    }
}
