using Microsoft.EntityFrameworkCore;
using SchoolBusDataAccess.Configurations;
using SchoolBusDomainLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDataAccess.Contexts
{
    internal class SchoolBusDBContext:DbContext
    {

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Ride> Rides { get; set; }
        public virtual DbSet<S_Class> S_Classes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string Constr = "Data Source=LAPTOP-46JAQGOF\\SQLEXPRESS;Initial Catalog=SchoolBus;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(Constr);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>()
        .HasIndex(u => u.UserName)
        .IsUnique();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
