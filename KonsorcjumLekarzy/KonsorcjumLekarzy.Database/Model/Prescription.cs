using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KonsorcjumLekarzy.Database.Model
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrescriptionId { get; set; }

        [ForeignKey("Visit")]
        public int VisitID { get; set; }

        public string DrugName { get; set; }
        public string UseDrugPerDay { get; set; }
        public string Dosage { get; set; }

        public virtual Visit Visit { get; set; }
    }
}