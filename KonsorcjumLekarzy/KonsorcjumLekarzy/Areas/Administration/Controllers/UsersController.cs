using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Models;
using KonsorcjumLekarzy.Services;

namespace KonsorcjumLekarzy.Areas.Administration.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IGenericService<ApplicationUser> _userService;

        public UsersController(IGenericService<ApplicationUser> userService)
        {
            this._userService = userService;
        }

        // GET: Administration/Users
        public ActionResult Index()
        {
            var users = this._userService.EntietiesList();
            return View(users);
        }

        // GET: Administration/Users/Details/5
        public ActionResult Details(string id)
        {
            var user = this._userService.ShowEntity(id);
            return View(user);
        }

        // GET: Administration/Users/Create
        public ActionResult Create()
        {
            var vm = new ApplicationUser();
            return View(vm);
        }

        // POST: Administration/Users/Create
        [HttpPost]
        public ActionResult Create(ApplicationUser user)
        {
            try
            {
                this._userService.CreateEntity(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Users/Edit/5
        public ActionResult Edit(string id)
        {
            var userEdit = this._userService.ShowEntity(id);
            return View(userEdit);
        }

        // POST: Administration/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ApplicationUser user)
        {
            try
            {
                this._userService.UpdateEntity(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Users/Delete/5
        public ActionResult Delete(string id)
        {
            var user = this._userService.ShowEntity(id);
            return View(user);
        }

        // POST: Administration/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                this._userService.DeleteEntity(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
