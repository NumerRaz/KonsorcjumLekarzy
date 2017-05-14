using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Models.DTOs;
using KonsorcjumLekarzy.Services;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KonsorcjumLekarzy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericService<Doctor> _doctorService;
        private readonly IGenericService<Patient> _patientService;
        private readonly IGenericService<Specialization> _specializationService;
        private readonly IGenericService<Visit> _visitService;
        private readonly IGenericService<ApplicationUser> _userService;

        public HomeController(IGenericService<Doctor> doctorService, IGenericService<Patient> patientService, IGenericService<Specialization> specializationService, IGenericService<Visit> visitService, IGenericService<ApplicationUser> userService)
        {
            _doctorService = doctorService;
            _patientService = patientService;
            _specializationService = specializationService;
            _visitService = visitService;
            _userService = userService;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult UserAuthorize()
        {
            var vm = GetInitData();
            return View(vm);
        }

        public JsonResult GetInitialData()
        {
            var initDto = new InitDTO();
            var doctorsDto = _doctorService.EntietiesList().Select(d => new DoctorDTO()
            {
                DoctorId = d.DoctorId,
                FirstName = d.FirstName,
                LastName = d.LastName,
                BirthDay = d.BirthDay,
                UserDto = new UserDTO()
                {
                    id = _userService.EntietiesList().Where(u => u.Id == d.UserId).Select(s => s.Id).FirstOrDefault(),
                    UserName = _userService.EntietiesList().Where(u => u.Id == d.UserId).Select(s => s.UserName).FirstOrDefault(),
                }
            }).ToList();

            var patientsDto = _patientService.EntietiesList().Select(p => new PatientDTO()
            {
                PatientId = p.PatientId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                BirthDay = p.BirthDay,
                UserDto = new UserDTO()
                {
                    id = _userService.EntietiesList().Where(u => u.Id == p.UserId).Select(s => s.Id).FirstOrDefault(),
                    UserName = _userService.EntietiesList().Where(u => u.Id == p.UserId).Select(s => s.UserName).FirstOrDefault(),
                }
            }).ToList();

            initDto.DoctorDto = doctorsDto;
            initDto.PatientDto = patientsDto;

            return Json(initDto, JsonRequestBehavior.AllowGet);
        }
        
        private InitDTO GetInitData()
        {
            var initDto = new InitDTO();
            var activeUser = User.Identity;

            var specializationDto = _specializationService.EntietiesList().Select(spec => new SpecializationDTO()
            {
                SpecializationDescription = spec.SpecializationDescription,
                SpecializationId = spec.SpecializationId,
                SpecializationName = spec.SpecializationName
            });

            var visitDto = _visitService.EntietiesList().Select(vi => new VisitDTO()
            {
                VisitID = vi.VisitID,
                Confirmation = vi.Confirmation,
                Duration = vi.Duration,
                StartDate = vi.StartDate,
                PatientId = vi.PatientId,
                DoctorId = vi.DoctorId
            });

            var userDto = _userService.EntietiesList().Where(u=>u.Id.Equals(activeUser.GetUserId()))
                .Select(u => new UserDTO()
                {
                    id = u.Id,
                    RoleName = Roles.GetRolesForUser(activeUser.Name).FirstOrDefault(),
                    UserName = u.UserName
                }).ToList();

            var doctorsDto = _doctorService.EntietiesList().Select(d => new DoctorDTO()
            {
                DoctorId = d.DoctorId,
                FirstName = d.FirstName,
                LastName = d.LastName,
                BirthDay = d.BirthDay,
                SpecializationDto = new SpecializationDTO()
                {
                    SpecializationId = _specializationService.EntietiesList().Where(spec => spec.SpecializationId == d.SpecializationId)
                        .Select(sel => sel.SpecializationId).FirstOrDefault(),
                    SpecializationName = _specializationService.EntietiesList().Where(spec => spec.SpecializationId == d.SpecializationId)
                        .Select(sel => sel.SpecializationName).FirstOrDefault(),
                    SpecializationDescription = _specializationService.EntietiesList().Where(spec => spec.SpecializationId == d.SpecializationId)
                            .Select(sel => sel.SpecializationDescription).FirstOrDefault()

                },
                UserDto = new UserDTO()
                {
                    id = _userService.EntietiesList().Where(u => u.Id == d.UserId).Select(s => s.Id).FirstOrDefault(),
                    UserName = _userService.EntietiesList().Where(u => u.Id == d.UserId).Select(s => s.UserName).FirstOrDefault(),
                }
            }).ToList();

            var patientsDto = _patientService.EntietiesList().Select(p => new PatientDTO()
            {
                PatientId = p.PatientId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                BirthDay = p.BirthDay,
                UserDto = new UserDTO()
                {
                    id = _userService.EntietiesList().Where(u => u.Id == p.UserId).Select(s => s.Id).FirstOrDefault(),
                    UserName = _userService.EntietiesList().Where(u => u.Id == p.UserId).Select(s => s.UserName).FirstOrDefault(),
                }
            }).ToList();

            initDto.DoctorDto = doctorsDto;
            initDto.PatientDto = patientsDto;
            initDto.UserDto = userDto;
            initDto.SpecializationDto = specializationDto.ToList();
            initDto.VisitDto = visitDto.ToList();

            return initDto;
        }

    }
}