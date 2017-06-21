using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using KonsorcjumLekarzy.Areas.Administration.Models;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;
using KonsorcjumLekarzy.Services;

namespace KonsorcjumLekarzy.Areas.Administration.Controllers
{
    [Authorize]
    public class DocotrsController
    {
        private readonly IGenericService<Doctor> doctorService;
        private readonly IGenericService<ApplicationUser> userService;
        private readonly IGenericService<Specialization> specializationService;

        public DocotrsController(IGenericService<Doctor> doctorService, IGenericService<ApplicationUser> userService, IGenericService<Specialization> specializationService)
        {
            this.doctorService = doctorService;
            this.userService = userService;
            this.specializationService = specializationService;
        }

        public ActionResult Details(int ID)
        {
            return View(doctorService.ShowEntity(ID));
        }


        public ActionResult Index()
        {
            return View(doctorService.EntietiesList());
        }


        [HttpGet]
        public ActionResult Create()
        {
            var vm = new DoctorCreateVM();
            var users = this.userService.EntietiesList();
            var doctors = this.doctorService.EntietiesList();
            var specialization = this.specializationService.EntietiesList();

            var usersDoctors =
                from p in users
                join c in doctors on p.Id equals c.UserId into joined
                select new ApplicationUser()
                {
                    Id = p.Id,
                    Email = p.Email,
                    UserName = p.UserName
                };

            vm.ApplicationUsers = usersDoctors.ToList();
            vm.Specializations = specialization.ToList();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            var specialization = this.specializationService.ShowEntity(doctor.SpecializationId);
            var user = this.userService.ShowEntity(doctor.UserId);

            if (ModelState.IsValid)
            {
                doctorService.CreateEntity(doctor);
                return RedirectToAction("Index");
            }
            else
                return View(doctor);
        }


        [HttpGet]
        public ActionResult Edit(int ID)
        {
            return View(doctorService.ShowEntity(ID));
        }


        [HttpPost]
        public ActionResult Edit(Doctor doctor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    doctorService.UpdateEntity(doctor);
                    return RedirectToAction("Index");
                }
                else
                    return View(doctor);
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try Again");
            }
            return View(doctor);
        }


        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Doctor doctor = doctorService.ShowEntity(ID);
            if (doctor == null)
                return RedirectToAction("Index");
            else
                return View(doctor);
        }

        [HttpPost]
        public ActionResult Delete(int ID, string confirmButton)
        {
            Doctor doctor = doctorService.ShowEntity(ID);
            if (doctor == null)
                return RedirectToAction("Index");

            userService.DeleteEntity(doctor.UserId);
            doctorService.DeleteEntity(ID);

            return RedirectToAction("Index");
        }
    }
}
