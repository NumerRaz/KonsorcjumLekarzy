using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonsorcjumLekarzy.Database.Repository;
using KonsorcjumLekarzy.Database.Model;


namespace KonsorcjumLekarzy.Services
{
        public class PatientService : IGenericService<Patient>
        {

            private readonly IRepository<Patient> repository;

            public PatientService(IRepository<Patient> repository)
            {
                this.repository = repository;
            }

        public IGenericService<object> IGenericService
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public IList<Patient> EntietiesList()
            {

                return repository.GetAll().ToList();
            }

            public void CreateEntity(Patient entity)
            {
                repository.Insert(entity);
            }

            public void UpdateEntity(Patient entity)
            {
                repository.Update(entity);
            }

            public void DeleteEntity(object ID)
            {
                Patient patient = repository.Get(ID);
                repository.Delete(patient);
            }

            public Patient ShowEntity(object ID)
            {
                Patient patient = repository.Get(ID);
                return patient;
            }

        }
    }
