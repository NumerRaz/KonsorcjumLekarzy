using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonsorcjumLekarzy.Models
{
    public class PrescriptionViewModels
    {
        public int PrescriptionId { get; set; }
        public int VisitID { get; set; }
        public string DrugName { get; set; }
        public string UseDrugPerDay { get; set; }
        public string Dosage { get; set; }
        public List<int> VisitsId { get; set; }
        public int VisitSelectedId { get; set; }
    }
}