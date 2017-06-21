using System.Collections.Generic;
using System.Linq;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;
using KonsorcjumLekarzy.Models;

namespace KonsorcjumLekarzy.Services
{
    public class PrescriptionService : IGenericService<Prescription>
    {
        private readonly IRepository<Prescription> _repository;

        public PrescriptionService(IRepository<Prescription> repository)
        {
            _repository = repository;
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

        public IList<Prescription> EntietiesList()
        {
            return _repository.GetAll().ToList();
        }

        public void CreateEntity(Prescription entity)
        {
            _repository.Insert(entity);
        }

        public void UpdateEntity(Prescription entity)
        {
            _repository.Update(entity);
        }

        public void DeleteEntity(object ID)
        {
            var prescription = _repository.Get(ID);
            _repository.Delete(prescription);
        }

        public Prescription ShowEntity(object ID)
        {
            var prescription = _repository.Get(ID);
            return prescription;
        }
    }
}