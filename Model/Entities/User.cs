using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public decimal PhoneNumber { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        [Key]
        [ForeignKey("UserTypeID")]
        public virtual UserType UserType { get; set; }
    }
}
