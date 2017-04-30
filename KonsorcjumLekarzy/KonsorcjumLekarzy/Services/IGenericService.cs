using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonsorcjumLekarzy.Services
{
    public interface IGenericService<T>
    {
        //CRUD
        IList<T> EntietiesList();
        void CreateEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(object ID);

        //Details
        T ShowEntity(object ID);

        
    }
}
