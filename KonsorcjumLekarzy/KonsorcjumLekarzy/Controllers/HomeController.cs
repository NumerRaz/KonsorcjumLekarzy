using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Models.DTOs;
using KonsorcjumLekarzy.Services;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
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
        private readonly IGenericService<Prescription> _prescriptionService;


        public HomeController(IGenericService<Doctor> doctorService, IGenericService<Patient> patientService, IGenericService<Specialization> specializationService, IGenericService<Visit> visitService, IGenericService<ApplicationUser> userService, IGenericService<Prescription> prescriptionService)
        {
            _doctorService = doctorService;
            _patientService = patientService;
            _specializationService = specializationService;
            _visitService = visitService;
            _userService = userService;
            _prescriptionService = prescriptionService;
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
        
        [AllowAnonymous]
        [HttpPost]
        public string ConfirmeVisit(int id)
        {
            var message = "";
            if (id == null)
            {
                message = "Empty visit id";
                return message;
            }

            var visit = _visitService.EntietiesList().FirstOrDefault(e => e.VisitID == id);
            if (visit != null)
            {
                visit.Confirmation = true;
            }

            _visitService.UpdateEntity(visit);
            message = "Data save correctly";
            return message;
        }

        [HttpPost]
        public string BookingVisit(string hour, string day, string doctor, string patient)
        {
            var data = day.AsDateTime().Date;
            var newData = new DateTime(data.Year, data.Month, data.Day, Int32.Parse(hour.AsDateTime().Hour.ToString()), 0,0);
            var getPatient = _patientService.EntietiesList().Where(x => x.UserId == patient).Select(p => p.PatientId).FirstOrDefault();

            var visit = new Visit();
            visit.DoctorId = Int32.Parse(doctor);
            visit.PatientId = getPatient;
            visit.Confirmation = false;
            visit.StartDate = newData;
            
            _visitService.CreateEntity(visit);

            if (string.IsNullOrEmpty(_visitService.ShowEntity(visit.VisitID).VisitID.ToString()))
            {
                return "Faild during booking visit. Please try again";
            }
            else
            {
                return "Visit booking";
            }

        }

        [HttpPost]
        public void UpdateUserData(string id, string userName, string firstName, string lastName, string birthDay, string phoneNumber, string email, string roleName, string password)
        {
            var account = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
            var user = _userService.ShowEntity(id);
            switch (roleName)
            {
                case "Doctor":
                        var getDoctorByUserId = _doctorService.EntietiesList().FirstOrDefault(d => d.UserId == id);
                        if (getDoctorByUserId != null)
                        {
                            getDoctorByUserId.FirstName = firstName;
                            getDoctorByUserId.LastName = lastName;
                            getDoctorByUserId.BirthDay = birthDay;
                            user.Email = email;
                            user.PhoneNumber = phoneNumber;
                            user.UserName = userName;
                            account.RemovePassword(id);
                            account.AddPassword(id, password);
                            this._doctorService.UpdateEntity(getDoctorByUserId);
                        }
                    this._userService.UpdateEntity(user);
                    break;
                case "Patient":
                        var getPatientByUserId = _patientService.EntietiesList().FirstOrDefault(p => p.UserId == id);
                        if (getPatientByUserId != null)
                        {
                            getPatientByUserId.FirstName = firstName;
                            getPatientByUserId.LastName = lastName;
                            getPatientByUserId.BirthDay = birthDay;
                            user.Email = email;
                            user.PhoneNumber = phoneNumber;
                            user.UserName = userName;
                            account.RemovePassword(id);
                            account.AddPassword(id, password);
                            this._patientService.UpdateEntity(getPatientByUserId);
                        }
                    this._userService.UpdateEntity(user);
                    break;
                case "Admin":
                        user.Email = email;
                        user.PhoneNumber = phoneNumber;
                        user.UserName = userName;
                        account.RemovePassword(id);
                        account.AddPassword(id, password);
                        this._userService.UpdateEntity(user);
                    break;
                default:
                    break;
            }
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
            var account = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var initDto = new InitDTO();
            var activeUser = User.Identity;
            var role = account.GetRoles(activeUser.GetUserId()).ToList();
            
            var userDto = _userService.EntietiesList().Where(u => u.Id.Equals(activeUser.GetUserId()))
                .Select(u => new UserDTO()
                {
                    id = u.Id,
                    RoleName = role.FirstOrDefault(),
                    UserName = u.UserName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber
                }).ToList();

            var specializationDto = _specializationService.EntietiesList().Select(spec => new SpecializationDTO()
            {
                SpecializationDescription = spec.SpecializationDescription,
                SpecializationId = spec.SpecializationId,
                SpecializationName = spec.SpecializationName
            });
            
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
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    BirthDay = d.BirthDay,
                    PhoneNumber = _userService.EntietiesList().Where(u => u.Id == d.UserId).Select(s => s.Email).FirstOrDefault(),
                    Email = _userService.EntietiesList().Where(u => u.Id == d.UserId).Select(s => s.PhoneNumber).FirstOrDefault(),
                    RoleName = account.GetRoles(d.UserId).FirstOrDefault()
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
                    FirstName = p.FirstName,
                    Email = _userService.EntietiesList().Where(u => u.Id == p.UserId).Select(s => s.Email).FirstOrDefault(),
                    LastName = p.LastName,
                    BirthDay = p.BirthDay,
                    PhoneNumber = _userService.EntietiesList().Where(u => u.Id == p.UserId).Select(s => s.PhoneNumber).FirstOrDefault(),
                    RoleName = account.GetRoles(p.UserId).FirstOrDefault()
                }
            }).ToList();

            var visitDto = new List<VisitDTO>();

            if (role.FirstOrDefault() == "Doctor")
            {
                var activeDoctorId = _doctorService.EntietiesList().FirstOrDefault(d => d.UserId == activeUser.GetUserId());
                visitDto = _visitService.EntietiesList().Where(v=>v.DoctorId == activeDoctorId.DoctorId).Select(vi => new VisitDTO()
                {
                    VisitID = vi.VisitID,
                    Confirmation = vi.Confirmation,
                    Duration = vi.Duration,
                    StartDate = vi.StartDate,
                    PatientId = vi.PatientId,
                    DoctorId = vi.DoctorId,
                    PrescriptionDtos = this._prescriptionService.EntietiesList().Where(x => x.VisitID == vi.VisitID).Select(n => new PrescriptionDTO()
                    {
                        VisitID = n.VisitID,
                        Dosage = n.Dosage,
                        DrugName = n.DrugName,
                        UseDrugPerDay = n.UseDrugPerDay
                    }).ToList()
                }).ToList();
            }
            else if (role.FirstOrDefault() == "Patient")
            {
                var activePatientId = _patientService.EntietiesList().FirstOrDefault(d => d.UserId == activeUser.GetUserId());
                visitDto = _visitService.EntietiesList().Where(v => v.PatientId == activePatientId.PatientId).Select(vi => new VisitDTO()
                {
                    VisitID = vi.VisitID,
                    Confirmation = vi.Confirmation,
                    Duration = vi.Duration,
                    StartDate = vi.StartDate,
                    PatientId = vi.PatientId,
                    DoctorId = vi.DoctorId,
                    PrescriptionDtos = this._prescriptionService.EntietiesList().Where(x => x.VisitID == vi.VisitID).Select(n => new PrescriptionDTO()
                    {
                        VisitID = n.VisitID,
                        Dosage = n.Dosage,
                        DrugName = n.DrugName,
                        UseDrugPerDay = n.UseDrugPerDay
                    }).ToList()
                }).ToList();
            }

            var prescriptions = this._prescriptionService.EntietiesList().Select(n => new PrescriptionDTO()
            {
                VisitID = n.VisitID,
                Dosage = n.Dosage,
                DrugName = n.DrugName,
                UseDrugPerDay = n.UseDrugPerDay
            }).ToList();

            initDto.DoctorDto = doctorsDto;
            initDto.PatientDto = patientsDto;
            initDto.UserDto = userDto;
            initDto.SpecializationDto = specializationDto.ToList();
            initDto.VisitDto = visitDto.ToList();
            initDto.PrescriptionDto = prescriptions; 

            return initDto;
        }

    }
}