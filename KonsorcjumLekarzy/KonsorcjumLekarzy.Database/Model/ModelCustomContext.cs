using System.Data.Entity;

namespace KonsorcjumLekarzy.Database.Model
{
    public class ModelCustomContext: ApplicationDbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}
