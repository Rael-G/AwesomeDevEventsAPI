using AwesomeWebEvents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeWebEvents.API.Persistence
{
    public class DevEventsDbContext : DbContext
    {


        public DevEventsDbContext(DbContextOptions<DevEventsDbContext> options) : base(options)
        {

        }

        public DbSet<DevEvent> DevEvents { get; set; }
        public DbSet<DevEventsSpeaker> DevEventsSpeaker { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DevEvent>(e =>
            {
                e.HasKey(de => de.Id);
                e.Property(de => de.Title)
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");
                e.Property(de => de.Description)
                .IsRequired(false)
                .HasMaxLength(250)
                .HasColumnType("nvarchar(250)");
                e.Property(de => de.StartDate)
                .HasColumnName("Start_Date");
                e.Property(de => de.EndDate).HasColumnName("End_Date");
                e.HasMany(de => de.Speakers)
                .WithOne()
                .HasForeignKey(s => s.DevEventId);
            });

            builder.Entity<DevEventsSpeaker>(e => 
            {
                e.HasKey(s => s.Id);
                e.Property(s => s.Name)
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");
                e.Property(s => s.TalkTitle)
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");
                e.Property(s => s.TalkDescription)
                .IsRequired(false)
                .HasMaxLength(250)
                .HasColumnType("nvarchar(250)");
                e.Property(s => s.LinkedInProfile)
                .IsRequired(false)
                .HasMaxLength(250)
                .HasColumnType("nvarchar(250)");
            });
        }

    }
}
