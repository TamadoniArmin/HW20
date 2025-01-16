using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Operators.Entities;
using App.Domain.Core.MoayeneFani.Requests.Entities;
using App.Domain.Core.MoayeneFani.Users.Entities;
using App.Domain.Core.MoayeneFani.UsersCars.Entities;
using Connection.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new OpratorConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserCarConfiguration());
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Oprator> Oprators { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Request> OutOfServiceRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCar> UserCars { get; set; }
    }
}
