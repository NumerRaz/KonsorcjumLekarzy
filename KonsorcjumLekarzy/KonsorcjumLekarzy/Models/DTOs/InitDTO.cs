using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using KonsorcjumLekarzy.Database.Model;

namespace KonsorcjumLekarzy.Models.DTOs
{
    public class InitDTO
    {
        public List<DoctorDTO> DoctorDto  { get; set; }
        public List<VisitDTO> VisitDto { get; set; }
        public List<SpecializationDTO> SpecializationDto { get; set; }
        public List<UserDTO> UserDto { get; set; }
        public List<PatientDTO> PatientDto { get; set; }
    }

    public class PatientDTO
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public UserDTO UserDto { get; set; }
    }

    public class UserDTO 
    {
        public string id { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }

    public class SpecializationDTO
    {
        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }
        public string SpecializationDescription { get; set; }
    }

    public class VisitDTO
    {
        public int VisitID { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public bool Confirmation { get; set; }
    }

    public class DoctorDTO
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public UserDTO UserDto { get; set; }
        public SpecializationDTO SpecializationDto { get; set; }
    }
}