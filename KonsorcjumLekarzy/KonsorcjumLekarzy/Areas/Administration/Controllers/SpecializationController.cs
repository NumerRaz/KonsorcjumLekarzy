using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;

namespace KonsorcjumLekarzy.Areas.Administration.Controllers
{
    public class SpecializationController : Controller
    {
        private readonly IRepository<Specialization> _repositorySpecialization;

        public SpecializationController(IRepository<Specialization> repositorySpecialization)
        {
            _repositorySpecialization = repositorySpecialization;
        }

        // GET: Administration/Specialization
        public ActionResult Index()
        {
            var result = _repositorySpecialization.GetAll();
            return View(result);
        }

        // GET: Administration/Specialization/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/Specialization/Create
        public ActionResult Create()
        {
            var vm = new Specialization();
            return View(vm);
        }

        // POST: Administration/Specialization/Create
        [HttpPost]
        public ActionResult Create(Specialization collection)
        {
            try
            {
                _repositorySpecialization.Insert(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Specialization/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/Specialization/Edit/5
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

        // GET: Administration/Specialization/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/Specialization/Delete/5
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
