
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonsorcjumLekarzy.Interfaces;

namespace KonsorcjumLekarzy.Services
{
    public class DoctorSerivce : IDoctorSerivces
    {
        //private readonly IDoctorRepository doctorRepository;



        //public DoctorSerivce(IDoctorRepository doctorRepository)
        //{
        //    this.doctorRepository = doctorRepository;
        //}

        ////Filter Read Methods 
        //#region
        //public List<Model.Doctor> GetAllDoctors()
        //{
        //    var model = doctorRepository.Doctors().ToList();

        //    return model;

        //}

        //public List<Model.Doctor> GetDoctorsByName(string name)
        //{
        //    var model = doctorRepository.Doctors()
        //        .Where(x => x.FirstName.Equals(name)).ToList();
        
        //    return model;
        //}


        //public List<Model.Doctor> GetDoctorsByEmail(string email)
        //{
        //    var model = doctorRepository.Doctors()
        //        .Where(x => x.Email.Equals(email)).ToList();

        //    return model;
        //}


        //public List<Model.Doctor> GetDoctorsBySpecialization(string docType)
        //{
        //    var model = doctorRepository.Doctors()
        //        .Where(x => x.DoctorType.Equals(docType)).ToList();

        //    return model;
        //}
        //#endregion

        ////Other CRUD Methods
        //#region
        //public void Create(Model.Doctor doctor)
        //{
        //    doctorRepository.Insert(doctor);
        //}

        //public void Edit(Model.Doctor doctor)
        //{
        //    doctorRepository.Update(doctor);
        //}

        //public void Delete(Model.Doctor doctor)
        //{
        //    doctorRepository.Delete(doctor);
        //}
        //#endregion
    }
}