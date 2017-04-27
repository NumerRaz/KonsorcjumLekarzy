using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonsorcjumLekarzy.Database.Model;

namespace KonsorcjumLekarzy.Database.Repository
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly ModelCustomContext _db = new ModelCustomContext();

        public IEnumerable<Patient> GetAll()
        {
            var result = _db.Patients.ToList();
            return result;
        }

        public Patient Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Patient entity)
        {
            _db.Patients.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
