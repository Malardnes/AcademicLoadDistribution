using Ald.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ald.Dal.Context
{
    public class CollegeContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<Cycle> Cycles { get; set; }

        public DbSet<CycleType> CycleTypes { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<EducationPlan> EducationPlans { get; set; }

        public DbSet<AttestationType> AttestationTypes { get; set; }

        public DbSet<EducationType> EducationTypes { get; set; }

        public DbSet<TeachingLoad> TeachingLoads { get; set; }

        public CollegeContext(DbContextOptions<CollegeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Group>()
                .Property(e => e.StartEducationDate)
                .HasColumnType("date");

            modelBuilder.Entity<Group>()
                .Property(e => e.EndEducationDate)
                .HasColumnType("date");
        }
    }
}
