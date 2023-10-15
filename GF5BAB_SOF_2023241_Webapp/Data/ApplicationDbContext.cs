using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GF5BAB_SOF_2023241_Webapp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Part> Parts { get; set; } 
        
        public DbSet<Test> Tests { get; set; }
        public DbSet<SiteUser> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Part>()
                .HasOne(t => t.Engineer)
                .WithMany()
                .HasForeignKey(t => t.EngineerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Meeting>()
                .HasOne(t => t.TeamPrincipal)
                .WithMany()
                .HasForeignKey(t => t.TeamPrincipalId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Test>()
               .HasOne(t => t.Driver)
               .WithMany()
               .HasForeignKey(t => t.DriverId)
               .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Engineer", NormalizedName = "ENGINEER" },
                new { Id = "3", Name = "Driver", NormalizedName = "DRIVER" },
                new { Id = "4", Name = "Teamprincipal", NormalizedName = "TEAMPRINCIPAL" });

            base.OnModelCreating(builder);
        }
    }
}