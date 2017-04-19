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
            return result.ToList();
        }

        public Doctor GetById(object Id)
        {
            var result = this.doctorDbSet;
            return result.Find(Id);
        }

        public void Insert(Doctor doctor)
        {
            var result = this.doctorDbSet;
            result.Add(doctor);
            Save();
        }

        public void Update(Doctor doctor)
        {
            var result = this._modelOrmContainer;
            result.Entry(doctor).State = EntityState.Modified;
            Save();
        }

        public void Delete(object doctor)
        {

            var result = GetById(doctor);
            doctorDbSet.Remove(result);
            Save();
        }

        public void Save()
        {

            var result = this._modelOrmContainer;
            result.SaveChanges();
        }
    }
}
