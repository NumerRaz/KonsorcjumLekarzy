using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Abstract;
using Model.Entities;

namespace KonsorcjumLekarzy.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository repository)
        {
            this.userRepository = repository;
        }
        //ToDo: View Drs
        public ViewResult UsersList()
        {
            return View(userRepository.Users);
        }
    }
}