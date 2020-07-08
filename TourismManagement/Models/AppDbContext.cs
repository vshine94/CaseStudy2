using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TourismManagement.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<CustomerTour> CustomerTours { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id=vshine94.mssql.somee.com;packet size=4096;user id=vshine_SQLLogin_1;pwd=rgrf97c5vl;data source=vshine94.mssql.somee.com;persist security info=False;initial catalog=vshine94");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tour>().HasOne<Type>(t => t.Type)
                .WithMany(ty => ty.Tours).HasForeignKey(t => t.TypeId);
            modelBuilder.Entity<CustomerTour>().HasKey(ct => new { ct.CustomerId, ct.TourId });
        }
    }
}
