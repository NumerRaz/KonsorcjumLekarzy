using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonsorcjumLekarzy.Database.Model;

namespace KonsorcjumLekarzy.Database.Repository
{
     public class SpecializationRepository : IRepository<Specialization>
    {
        private readonly ModelCustomContext _db = new ModelCustomContext();

        public IEnumerable<Specialization> GetAll()
        {
            throw new NotImplementedException();
        }

        public Specialization Get(long id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Specialization entity)
        {
            _db.Specializations.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Specialization entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Specialization entity)
        {
            throw new NotImplementedException();
        }
    }
}
