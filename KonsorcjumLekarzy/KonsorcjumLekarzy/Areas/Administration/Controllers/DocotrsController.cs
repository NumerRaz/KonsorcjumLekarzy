using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;

namespace KonsorcjumLekarzy.Areas.Administration.Controllers
{
    public class DocotrsController : Controller
    {
        private readonly IRepository<Doctor> _repositoryDoctor;

        public DocotrsController(IRepository<Doctor> repositoryDoctor)
        {
            _repositoryDoctor = repositoryDoctor;
        }

        // GET: Administration/Docotrs
        public ActionResult Index()
        {
            var result = _repositoryDoctor.GetAll();
            return View(result);
        }

        public JsonResult JsonIndex()
        {
            var result = _repositoryDoctor.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Administration/Docotrs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/Docotrs/Create
        public ActionResult Create()
        {
            var vm = new Doctor();
            return View(vm);
        }

        // POST: Administration/Docotrs/Create
        [HttpPost]
        public ActionResult Create(Doctor collection)
        {
            try
            {
                _repositoryDoctor.Insert(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Docotrs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/Docotrs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
