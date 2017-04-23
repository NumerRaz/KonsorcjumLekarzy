using Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace KonsorcjumLekarzy.DAL.Repository
{
    class KonsorcjumContext : DbContext
    {
        public KonsorcjumContext() : base("DefaultConnection")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRole { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaim { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogin { get; set; }
        public virtual DbSet<AspNetUser> AspNetUser { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
