using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Abstract;
using Model;

namespace KonsorcjumLekarzy.Controllers
{
    public class DoctorController : Controller
    {
        private IDoctorRepository repository;

        public DoctorController(IDoctorRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult DoctorList()
        {
            var model = repository.Doctors(); 
            return View(model);
        }
    }
}