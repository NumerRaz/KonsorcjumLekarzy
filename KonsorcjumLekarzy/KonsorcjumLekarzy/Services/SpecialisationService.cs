using System;
using System.Collections.Generic;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;
using KonsorcjumLekarzy.Services;
using System.Linq;
using System.Web;

namespace KonsorcjumLekarzy.Services
{
    public class SpecialisationService : IGenericService<Specialization>
    {
        private readonly IRepository<Specialization> repository;

        public SpecialisationService(IRepository<Specialization> repository)
        {
            this.repository = repository;
        }

        public IList<Specialization> EntietiesList()
        {

            return repository.GetAll().ToList();
        }

        public void CreateEntity(Specialization entity)
        {
            repository.Insert(entity);
        }

        public void UpdateEntity(Specialization entity)
        {
            repository.Update(entity);
        }

        public void DeleteEntity(object ID)
        {
            Specialization specialization = ShowEntity(ID);
            repository.Delete(specialization);
        }

        public Specialization ShowEntity(object ID)
        {
            Specialization doctorSpecialization = repository.Get(ID);
            return doctorSpecialization;
        }
    }
}