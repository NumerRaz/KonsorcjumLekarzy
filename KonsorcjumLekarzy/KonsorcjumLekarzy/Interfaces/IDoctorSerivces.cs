using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonsorcjumLekarzy.Interfaces
{
    public interface IDoctorSerivces
    {
         List<Model.Doctor> GetAllDoctors();
    }
}