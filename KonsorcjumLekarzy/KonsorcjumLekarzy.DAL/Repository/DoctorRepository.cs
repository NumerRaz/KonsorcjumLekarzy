using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    class DoctorRepository : IDoctroRepository<DoctorExample>
    {
        public void Delete(DoctorExample doctor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorExample> Doctors()
        {
            throw new NotImplementedException();
        }

        public DoctorExample GetById(DoctorExample Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(DoctorExample doctor)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(DoctorExample doctor)
        {
            throw new NotImplementedException();
        }
    }

    internal class DoctorExample
    {
    }
}
