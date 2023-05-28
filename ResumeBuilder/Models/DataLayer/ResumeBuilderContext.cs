using ResumeBuilder.Models.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Models.CvModel;

namespace ResumeBuilder.Models.DataLayer
{
    public class ResumeBuilderContext : IdentityDbContext
    {
        public ResumeBuilderContext(DbContextOptions<ResumeBuilderContext> options)
            : base(options) { }
        public DbSet<ResumeTemplate> ResumeTemplate { get; set; }
        public DbSet<Resume> Resume { get; set; }
        public DbSet<CvInformation> CvInformation { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
