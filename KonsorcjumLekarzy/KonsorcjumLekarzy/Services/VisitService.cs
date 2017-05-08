using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;

namespace KonsorcjumLekarzy.Services
{
    public class VisitService : IGenericService<Visit>
    {
        private readonly IRepository<Visit> repository;

        public VisitService(IRepository<Visit> repository)
        {
            this.repository = repository;
        }

        public IList<Visit> EntietiesList()
        {
            return repository.GetAll().ToList();
        }

        public void CreateEntity(Visit entity)
        {
            repository.Insert(entity);
        }

        public void UpdateEntity(Visit entity)
        {
            repository.Update(entity);
        }

        public void DeleteEntity(object ID)
        {
            Visit specialization = ShowEntity(ID);
            repository.Delete(specialization);
        }

        public Visit ShowEntity(object ID)
        {
            Visit doctorSpecialization = repository.Get(ID);
            return doctorSpecialization;
        }
    }
}