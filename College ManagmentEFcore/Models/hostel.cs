using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_ManagmentEFcore.Models
{
    public class hostel
    {
        [Key]
        public int? hostel_id { get; set; }

        [Required]
        public string hostel_name { get; set; }

        [Required]
        public int no_of_seats { get; set; }


        public virtual ICollection<student> Students { get; set; }

    }
}
