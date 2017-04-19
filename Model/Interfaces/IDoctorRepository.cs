using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model.Abstract
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> Doctors();
        Doctor GetById(object Id);
        void Insert(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(object doctor);
        void Save();
    }
}
