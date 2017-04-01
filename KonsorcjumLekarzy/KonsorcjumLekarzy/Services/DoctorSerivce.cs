using Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonsorcjumLekarzy.Interfaces;

namespace KonsorcjumLekarzy.Services
{
    public class DoctorSerivce : IDoctorSerivces
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorSerivce(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public List<Model.Doctor> GetDcotrsByName(string name)
        {
            var model = _doctorRepository.Doctors().Where(x => x.FirstName.Equals(name)).ToList();
            return model; 
        }
    }
}