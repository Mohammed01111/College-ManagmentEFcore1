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
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string City { get; set; }
        public int AvailableSeats { get; set; }

        public virtual ICollection<student> Students
        {
            get; set;

        }
    }
}
