using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonsorcjumLekarzy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KonsorcjumLekarzy.Infrastucture
{
    public class ManageAccount
    {
        public void AddRole(ApplicationDbContext context, TypeRole roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            switch (roleName)
            {
                    case TypeRole.Admin:
                        CheckIfExistRole("Admin", roleManager);
                        break;
                    case TypeRole.Doctor:
                        CheckIfExistRole("Doctor", roleManager);
                        break;
                    case TypeRole.Patient:
                        CheckIfExistRole("Patient", roleManager);
                        break;
                    default:
                        break;
            }
        }

        private bool CheckIfExistRole(string roleName, RoleManager<IdentityRole> roleManager )
        {

            if (!roleManager.RoleExists(roleName))
            {
                var role = new IdentityRole();
                role.Name = roleName;
                roleManager.Create(role);
                return true;
            }
            return false;

        }
    }
}