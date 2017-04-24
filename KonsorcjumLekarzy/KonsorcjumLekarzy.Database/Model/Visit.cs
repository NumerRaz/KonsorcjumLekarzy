using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonsorcjumLekarzy.Database.Model
{
    public class Visit
    {
        [Key]
        public int VisitID { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public bool Confirmation { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    } 
}
