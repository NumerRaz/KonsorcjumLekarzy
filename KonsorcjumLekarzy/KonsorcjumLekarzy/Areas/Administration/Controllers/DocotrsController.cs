using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;
using KonsorcjumLekarzy.Services;

namespace KonsorcjumLekarzy.Areas.Administration.Controllers
{
    public class DocotrsController : Controller
    {
        private readonly IGenericService<Doctor> doctorService;
        private readonly IGenericService<ApplicationUser> userService;

        public DocotrsController(IGenericService<Doctor> doctorService, IGenericService<ApplicationUser> userService)
        {
            this.doctorService = doctorService;
            this.userService = userService;
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
            return View();
        }

        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
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
            catch(DataException)
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
