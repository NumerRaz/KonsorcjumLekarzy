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

        public DocotrsController(IGenericService<Doctor> doctorService)
        {
            this.doctorService = doctorService;
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

        // GET: Administration/Docotrs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/Docotrs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
