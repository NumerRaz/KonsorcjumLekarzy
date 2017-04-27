using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonsorcjumLekarzy.Database.Repository;
using KonsorcjumLekarzy.Database.Model;

namespace KonsorcjumLekarzy.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> repository;
        
        public DoctorService(IRepository<Doctor> repository)
        {
            this.repository = repository;
        }

        public IList<Doctor> DoctorsList()
        {
            return repository.GetAll().ToList();
        }
    }
}