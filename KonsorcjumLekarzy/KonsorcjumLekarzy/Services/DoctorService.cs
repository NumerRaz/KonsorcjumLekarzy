using System.Collections.Generic;
using System.Linq;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;

namespace KonsorcjumLekarzy.Services
{
    public class DoctorService : IGenericService<Doctor>
    {
        private readonly IRepository<Doctor> repository;

        public DoctorService(IRepository<Doctor> repository)
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

        public IGenericService<object> IGenericService1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public IList<Doctor> EntietiesList()
        {
            return repository.GetAll().ToList();
        }

        public void CreateEntity(Doctor entity)
        {
            repository.Insert(entity);
        }

        public void UpdateEntity(Doctor entity)
        {
            repository.Update(entity);
        }

        public void DeleteEntity(object ID)
        {
            var doctor = repository.Get(ID);
            repository.Delete(doctor);
        }

        public Doctor ShowEntity(object ID)
        {
            var doctor = repository.Get(ID);
            return doctor;
        }
    }
}