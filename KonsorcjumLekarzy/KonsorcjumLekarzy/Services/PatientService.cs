using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;

namespace KonsorcjumLekarzy.Services
{
    public class PatientService : IGenericService<Patient>
    {
        private readonly IRepository<Patient> _repository;

        public PatientService(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public IList<Patient> EntietiesList()
        {
            throw new NotImplementedException();
        }

        public void AddEntity(Patient entity)
        {
            this._repository.Insert(entity);
        }

        public void UpdateEntity(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void GetEntiyById(int id)
        {
            throw new NotImplementedException();
        }
    }
}