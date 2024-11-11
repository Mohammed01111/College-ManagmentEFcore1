using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_ManagmentEFcore.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}

