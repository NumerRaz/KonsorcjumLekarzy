using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonsorcjumLekarzy.Database.Model
{
    public class Specialization
    {
        [Key]
        public int SpecializationId { get; set; }

        [Required]
        [MaxLength(250)]
        public string SpecializationName { get; set; }

        [MaxLength(250)]
        public string SpecializationDescription { get; set; }
    }
}
