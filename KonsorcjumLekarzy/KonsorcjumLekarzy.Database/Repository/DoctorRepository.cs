using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonsorcjumLekarzy.Database.Model;

namespace KonsorcjumLekarzy.Database.Repository
{
    public class DoctorRepository : IRepository<Doctor>
    {
        private readonly ModelCustomContext _db = new ModelCustomContext();
        
        public IEnumerable<Doctor> GetAll()
        {
           var result = _db.Doctors.ToList();
            return result;
        }

        public Doctor Get(long id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Doctor entity)
        {
            _db.Doctors.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
