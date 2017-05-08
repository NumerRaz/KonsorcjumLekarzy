using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonsorcjumLekarzy.Database.Model;

namespace KonsorcjumLekarzy.Areas.Administration.Models
{
    public class AdminVm
    {
    }

    public class DoctorCreateVM
    {
        public Doctor Doctor { get; set; }
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public List<Specialization> Specializations { get; set; }
    }

    public class PatientCreateVM
    {
        public Patient Patient { get; set; }
        public List<ApplicationUser> ApplicationUsers { get; set; }
    }

    public class VisitVM
    {
        public Visit Visit { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; } 
    }

}