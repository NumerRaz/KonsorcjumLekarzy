using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KonsorcjumLekarzy.Database.Model
{
    public class Visit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitID { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public bool Confirmation { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }


        public virtual ICollection<Prescription> Prescription { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}