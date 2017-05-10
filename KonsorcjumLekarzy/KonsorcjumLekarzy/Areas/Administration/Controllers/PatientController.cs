﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;
using KonsorcjumLekarzy.Services;
using System.Data;
using KonsorcjumLekarzy.Areas.Administration.Models;

namespace KonsorcjumLekarzy.Areas.Administration.Controllers
{
    public class PatientController : Controller
    {
        private readonly IGenericService<Patient> patientService;
        private readonly IGenericService<ApplicationUser> userService;

        public PatientController(IGenericService<Patient> patientService, IGenericService<ApplicationUser> userService)
        {
            this.patientService = patientService;
            this.userService = userService;
        }


        public ActionResult Details(int ID)
        {
            return View(patientService.ShowEntity(ID));
        }


        public ActionResult Index()
        {
            return View(patientService.EntietiesList());
        }


        [HttpGet]
        public ActionResult Create()
        {
            var vm = new PatientCreateVM();
            var users = this.userService.EntietiesList();

            vm.ApplicationUsers = users.ToList();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                patientService.CreateEntity(patient);
                return RedirectToAction("Index");
            }
            else
                return View(patient);
        }


        [HttpGet]
        public ActionResult Edit(int ID)
        {
            return View(patientService.ShowEntity(ID));
        }


        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    patientService.UpdateEntity(patient);
                    return RedirectToAction("Index");
                }
                else
                    return View(patient);
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try Again");
            }
            return View(patient);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Patient patient = patientService.ShowEntity(ID);
            if (patient == null)
                return RedirectToAction("Index");
            else
                return View(patient);
        }

        [HttpPost]
        public ActionResult Delete(int ID, string confirmButton)
        {
            Patient patient = patientService.ShowEntity(ID);
            if (patient == null)
                return RedirectToAction("Index");

            userService.DeleteEntity(patient.UserId);
            patientService.DeleteEntity(ID);
            
            return RedirectToAction("Index");
        }
    }
}