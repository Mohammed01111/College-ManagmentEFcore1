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
            [PrimaryKey(nameof(FID), nameof(Mobile_no))]
            public class FacultyMobile
            {
                [ForeignKey("Faculty")]
                public int FID { get; set; }
                public virtual Faculty Faculty { get; set; }

                public string Mobile_no { get; set; }
            }
        }

    }
}
