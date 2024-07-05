using Microsoft.EntityFrameworkCore;
using Backend_Gimfit.Models;

namespace Backend_Gimfit.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSchedule> CourseSchedules { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Course entity
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Trainer)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure CourseSchedule entity
            modelBuilder.Entity<CourseSchedule>()
                .HasOne(cs => cs.ScheduledCourse)
                .WithMany()
                .HasForeignKey(cs => cs.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure many-to-many relationship between CourseSchedule and Client
            modelBuilder.Entity<CourseSchedule>()
                .HasMany(cs => cs.Clients)
                .WithMany(c => c.CourseSchedules)
                .UsingEntity(j => j.ToTable("CourseScheduleClient"));

            // Configure Subscription entity
            modelBuilder.Entity<Subscription>()
                .HasMany(s => s.Courses)
                .WithOne(c => c.Subscription)
                .HasForeignKey(c => c.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
