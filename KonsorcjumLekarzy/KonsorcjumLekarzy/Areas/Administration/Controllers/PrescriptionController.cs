using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Models;
using KonsorcjumLekarzy.Services;

namespace KonsorcjumLekarzy.Areas.Administration.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IGenericService<Prescription> _prescriptionService;
        private readonly IGenericService<Visit> _visitService;

        public PrescriptionController(IGenericService<Prescription> prescriptionService,
            IGenericService<Visit> visitService)
        {
            _prescriptionService = prescriptionService;
            _visitService = visitService;
        }

        // GET: Administration/Prescription
        public ActionResult Index()
        {
            return View(_prescriptionService.EntietiesList());
        }

        // GET: Administration/Prescription/Details/5
        public ActionResult Details(int id)
        {
            return View(_prescriptionService.ShowEntity(id));
        }

        // GET: Administration/Prescription/Create
        public ActionResult Create()
        {
            var visits = _visitService.EntietiesList().ToList();
            if (visits.Count == 0)
                visits = new List<Visit>(0);

            var vm = new PrescriptionViewModels
            {
                VisitsId = visits.Select(x => x.VisitID).ToList()
            };
            return View(vm);
        }

        // POST: Administration/Prescription/Create
        [HttpPost]
        public ActionResult Create(PrescriptionViewModels prescriptionViewModels)
        {
            _prescriptionService.CreateEntity(new Prescription
            {
                Dosage = prescriptionViewModels.Dosage,
                DrugName = prescriptionViewModels.DrugName,
                PrescriptionId = prescriptionViewModels.PrescriptionId,
                VisitID = prescriptionViewModels.VisitSelectedId,
                UseDrugPerDay = prescriptionViewModels.UseDrugPerDay
            });

            return RedirectToAction("Index");
        }

        // GET: Administration/Prescription/Edit/5
        public ActionResult Edit(int id)
        {
            var entities = _prescriptionService.EntietiesList();
            var result = entities.FirstOrDefault(x => x.PrescriptionId == id);

            return View(result);
        }

        // POST: Administration/Prescription/Edit/5
        [HttpPost]
        public ActionResult Edit(Prescription prescription)
        {
            _prescriptionService.UpdateEntity(prescription);
            return RedirectToAction("Index");
        }

        // GET: Administration/Prescription/Delete/5
        public ActionResult Delete(int id)
        {
            var result = this._prescriptionService.ShowEntity(id);
            return View("Delete", result);
        }

        // POST: Administration/Prescription/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var entity = _prescriptionService.EntietiesList()
                .FirstOrDefault(x => x.PrescriptionId == id);

            if (entity != null) _prescriptionService.DeleteEntity(entity.PrescriptionId);

            return RedirectToAction("Index");
        }
    }
}