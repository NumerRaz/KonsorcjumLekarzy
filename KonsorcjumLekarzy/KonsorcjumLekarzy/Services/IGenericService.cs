using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonsorcjumLekarzy.Database.Model;

namespace KonsorcjumLekarzy.Services
{
    public interface IGenericService<T>
    {
        Areas.Administration.Controllers.DocotrsController DocotrsController { get; set; }
        Areas.Administration.Controllers.DocotrsController DocotrsController1 { get; set; }

        //CRUD
        IList<T> EntietiesList();
        void CreateEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(object ID);

        //Details
        T ShowEntity(object ID);
    }
}
