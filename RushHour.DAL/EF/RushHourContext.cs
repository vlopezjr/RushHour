using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using RushHour.Models.Entities;
using RushHour.Models.Entities.Base;

namespace RushHour.DAL.EF
{
    public class RushHourContext : DbContext
    {
        public RushHourContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RushHour.DAL.EF.RushHourContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Freight> Freights { get; set; }
        public DbSet<CustomerAddress> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery>()
                 .HasRequired(a => a.DeliverToAddress)
                 .WithMany()
                 .HasForeignKey(u => u.DeliverToAddressId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Delivery>()
                .HasRequired(a => a.PickupAddress)
                .WithMany()
                .HasForeignKey(u => u.PickupAddressId).WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerAddress>()
                 .HasRequired(a => a.Customer)
                 .WithMany()
                 .HasForeignKey(u => u.CustomerId).WillCascadeOnDelete(false);
        }

        public override int SaveChanges()
        {
            AddTimeStamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            AddTimeStamps();
            return base.SaveChangesAsync();
        }

        private void AddTimeStamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = !string.IsNullOrEmpty(System.Web.HttpContext.Current?.User?.Identity?.Name)
                ? HttpContext.Current.User.Identity.Name
                : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((EntityBase)entity.Entity).DateCreated = DateTime.UtcNow;
                    ((EntityBase)entity.Entity).UserCreated = currentUsername;
                }

                ((EntityBase)entity.Entity).DateModified = DateTime.UtcNow;
                ((EntityBase)entity.Entity).UserModified = currentUsername;
            }
        }
    }
}
