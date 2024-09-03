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
            modelBuilder.Entity<WorkStation>()
                .HasKey(c => c.WorkStationId);

            modelBuilder.Entity<Order>()
                .HasKey(t => t.OrderId);

            modelBuilder.Entity<Holiday>()
             .HasKey(t => t.HolidayId);

            modelBuilder.Entity<SpecialDay>()
   .HasKey(t => t.SpecialDayId);

            modelBuilder.Entity<PendingOrder>()
   .HasKey(t => t.PendingOrderId);
        }

        public ScheduleDBContext()
        {
            
        }
        public virtual DbSet<WorkStation> WorkStations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<Holiday> SpecialDays { get; set; }

        public virtual DbSet<PendingOrder> PendingOrders { get; set; }



    }
}
