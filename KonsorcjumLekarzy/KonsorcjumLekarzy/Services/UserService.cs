using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonsorcjumLekarzy.Database.Repository;
using KonsorcjumLekarzy.Database.Model;

namespace KonsorcjumLekarzy.Services
{
    public class UserService : IGenericService<ApplicationUser>
    {
        private readonly IRepository<ApplicationUser> repository;
        public UserService(IRepository<ApplicationUser> repository)
        {
            this.repository = repository;
        }

        public void CreateEntity(ApplicationUser entity)
        {
            this.repository.Insert(entity);
        }

        public void DeleteEntity(object ID)
        {
            ApplicationUser user = repository.Get(ID);
            repository.Delete(user);
        }

        public IList<ApplicationUser> EntietiesList()
        {
            var users = this.repository.GetAll();
            return users.ToList();
        }

        public ApplicationUser ShowEntity(object ID)
        {
            var user = this.repository.Get(ID);
            return user; 
        }

        public void UpdateEntity(ApplicationUser entity)
        {
            this.repository.Update(entity);
        }
    }
}