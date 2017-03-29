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

        DoctorController(IDoctorRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult DoctorList()
        {
            return View(repository.Doctors);
        }
    }
}