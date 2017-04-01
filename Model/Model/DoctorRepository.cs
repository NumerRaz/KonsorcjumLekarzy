using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Abstract
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ModelORMContainer _modelOrmContainer;
        private readonly DbSet<Doctor> doctorDbSet;

        public DoctorRepository()
        {
            _modelOrmContainer = new ModelORMContainer();
            doctorDbSet = _modelOrmContainer.DoctorSet;
        }

        public IEnumerable<Doctor> Doctors()
        {
            var result = this.doctorDbSet;
            return result;
        }
    }
}
