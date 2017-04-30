using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonsorcjumLekarzy.Database.Model
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Naziwsko")]
        public string LastName { get; set; }
        
        [Display(Name = "Data urodzenia")]
        public string BirthDay { get; set; }

        [Display(Name = "Specjalizacja")]
        [ForeignKey("Specialization")]
        public int SpecializationId { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
