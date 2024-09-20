using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Entities
{
    public class ScheduleDBContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=108.60.206.36, 14331;Initial Catalog=schedule_db_new;Persist Security Info=False;User ID=sa;Password=ab@03BDDG123#498@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            //optionsBuilder.UseSqlServer("server=AXCITO-DEV-01;database=schedule_db;User Id=sa;Password=axcito@SQL;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkStation>()
                .HasKey(c => c.WorkStationId);

            modelBuilder.Entity<Order>()
                .HasKey(t => t.OrderId);

            modelBuilder.Entity<Holiday>()
             .HasKey(t => t.HolidayId);

            modelBuilder.Entity<CustomDay>()
   .HasKey(t => t.CustomDay_Id);

            modelBuilder.Entity<ScheduleDetails>()
   .HasKey(t => t.ScheduleDetailsId);

            modelBuilder.Entity<Product>()
   .HasKey(t => t.Product_Id);
            modelBuilder.Entity<Output_Rate>()
.HasKey(t => t.Output_Rate_Id);
        }

        public ScheduleDBContext()
        {
            
        }
        public virtual DbSet<WorkStation> WorkStations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<CustomDay> CustomDays { get; set; }

        public virtual DbSet<ScheduleDetails> ScheduleDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Output_Rate> OutputRates { get; set; }

        public virtual DbSet<Operation_Type> OperationTypes { get; set; }



    }
}
