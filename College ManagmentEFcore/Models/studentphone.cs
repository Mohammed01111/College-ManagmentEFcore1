using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_ManagmentEFcore.Models
{

        [PrimaryKey(nameof(SID), nameof(Phone_no))]
        public class StudentPhone
        {
            [ForeignKey("Student")]
            public int SID { get; set; }
            public virtual student Student { get; set; }

            public string Phone_no { get; set; }
        }

}
