using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Entities
{
    public class ScheduleDBContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=108.60.206.36, 14331;Initial Catalog=task_db;Persist Security Info=False;User ID=sa;Password=ab@03BDDG123#498@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Machine>()
                .HasKey(c => c.MachineId);

            modelBuilder.Entity<Task>()
                .HasKey(t => t.TaskId);

            modelBuilder.Entity<Holiday>()
             .HasKey(t => t.HolidayId);
        }

        public ScheduleDBContext()
        {
            
        }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }

    }
}
