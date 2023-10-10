using GF5BAB_SOF_2023241_Webapp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
    }
}