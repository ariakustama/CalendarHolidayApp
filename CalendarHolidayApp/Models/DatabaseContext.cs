using Microsoft.EntityFrameworkCore;

namespace CalendarHolidayApp.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { 

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { 
        
        }
        public virtual DbSet<TblDateHoliday> TblDateHolidays { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<TblDateHoliday>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(225)
                    .IsUnicode(true);

                entity.Property(e => e.DateHoliday).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.IsSameDay)
                   .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(sysdatetime())");
            });
        }
    }
}
