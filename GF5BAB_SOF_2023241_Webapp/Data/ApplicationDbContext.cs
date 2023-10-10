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
        public DbSet<Part> Parts { get; set; } 
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
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Engineer", NormalizedName = "ENGINEER" },
                new { Id = "3", Name = "Driver", NormalizedName = "DRIVER" },
                new { Id = "4", Name = "Teamprincipal", NormalizedName = "TEAMPRINCIPAL" });
            base.OnModelCreating(builder);

            string filePath = "C:\\Users\\Zsíros Ádám\\Downloads\\TopG.jpg";
            byte[] imageBytes = File.ReadAllBytes(filePath);

            PasswordHasher<SiteUser> ph = new PasswordHasher<SiteUser>();
            SiteUser admin = new SiteUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "tassigny4@gmail.com",
                NormalizedEmail = "TASSIGNY4@GMAIL.COM",
                EmailConfirmed = true,
                UserName = "tassigny4@gmail.com",
                NormalizedUserName = "TASSIGNY4@GMAIL.COM",
                FirstName = "Ádám",
                LastName = "Zsíros",
                Data = imageBytes,
                ContentType = "image/png",

            };
            admin.PasswordHash = ph.HashPassword(admin, "adminka1");
            builder.Entity<SiteUser>().HasData(admin);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = admin.Id
            });
        }
    }
}