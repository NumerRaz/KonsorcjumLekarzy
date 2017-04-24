using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonsorcjumLekarzy.Database.Model
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string BirthDay { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
