using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using KonsorcjumLekarzy.Services;
using KonsorcjumLekarzy.Interfaces;

namespace KonsorcjumLekarzy.Controllers
{
    public class HomeController : Controller
    {

        private readonly IDoctorSerivces _doctorService;

        public HomeController(IDoctorSerivces doctorService)
        {
            _doctorService = doctorService;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult UserAuthorize()
        {
            return View();
        }
        
    }
}