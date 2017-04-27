using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonsorcjumLekarzy.Database.Model;

namespace KonsorcjumLekarzy.Services
{
    public interface IDoctorService
    {
        IList<Doctor> DoctorsList();
    }
}
