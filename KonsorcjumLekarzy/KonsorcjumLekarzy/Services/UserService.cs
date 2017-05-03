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
            throw new NotImplementedException();
        }

        public void DeleteEntity(object ID)
        {
            ApplicationUser user = repository.Get(ID);
            repository.Delete(user);
        }

        public IList<ApplicationUser> EntietiesList()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser ShowEntity(object ID)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }
    }
}