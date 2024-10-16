using Microsoft.EntityFrameworkCore;
using ttcm_api.Models;

namespace ttcm_api.Contexts
{
    public class MainAppContext : DbContext
    {

        public DbSet<ttcm_api.Models.Program> Program { get; set; }
        public DbSet<ttcm_api.Models.Trainer> Trainers { get; set; }
        public DbSet<ttcm_api.Models.Course> Courses { get; set; }
        public MainAppContext(DbContextOptions<MainAppContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.Property(e => e.Salary)
                      .HasPrecision(18, 2);
            });
        }
    }
}


