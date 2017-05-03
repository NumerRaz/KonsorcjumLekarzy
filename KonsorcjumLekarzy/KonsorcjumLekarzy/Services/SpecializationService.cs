using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;

namespace KonsorcjumLekarzy.Services
{
    public class SpecializationService : IGenericService<Specialization>
    {
        private readonly IRepository<Specialization> _repository;

        public SpecializationService(IRepository<Specialization> repository)
        {
            _repository = repository;
        }

        public IList<Specialization> EntietiesList()
        {
            throw new NotImplementedException();
        }

        public void AddEntity(Specialization entity)
        {
            this._repository.Insert(entity);
        }

        public void UpdateEntity(Specialization entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Specialization entity)
        {
            throw new NotImplementedException();
        }

        public Specialization GetEntiyById(int id)
        {
            var result = this._repository.Get(id);
            return result;
        }
    }
}