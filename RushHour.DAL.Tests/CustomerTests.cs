using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RushHour.DAL.EF;
using RushHour.Models.Entities;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using RushHour.DAL.Repos;

namespace RushHour.DAL.Tests
{
    [TestClass]
    public class CustomerTests : IDisposable
    {
        private readonly RushHourContext _db;
        private readonly CustomerRepo _repo;

        public CustomerTests()
        {
            _db = new RushHourContext();
            _repo = new CustomerRepo();

            CleanDatabase();
        }        

        [TestMethod]
        public void ShouldAddCustomerWithDbSet()
        {
            var cust = new Customer { Name = "Best Brakes", Address1 = "182 Arrow Ave", Address2 = "Suite B", City = "Chino", State="CA", PointOfContact = "Jon Jay", PrimaryPhone="9095551212", SecondaryPhone="9095551313", EmailAddress="chalan@bestbrakes.com"};
            _db.Customers.Add(cust);
            Assert.AreEqual(EntityState.Added, _db.Entry(cust).State);
            Assert.IsTrue(cust.Id == 0);
            Assert.IsNull(cust.TimeStamp);
            _db.SaveChanges();
            Assert.AreEqual(EntityState.Unchanged, _db.Entry(cust).State);
            //Assert.IsTrue(driver.Id > 0);
            Assert.IsNotNull(cust.TimeStamp);
            Assert.IsNotNull(cust.DateCreated);
            Assert.IsNotNull(cust.DateModified);
            Assert.IsNotNull(cust.UserCreated);
            Assert.IsNotNull(cust.UserModified);
            Assert.AreEqual(1, _db.Customers.Count());
        }

        [TestMethod]
        public void ShouldAddCustomerWithRepo()
        {
            var cust = new Customer { Name = "Best Brakes", Address1 = "182 Arrow Ave", Address2 = "Suite B", City = "Chino", State = "CA", PointOfContact = "Jon Jay", PrimaryPhone = "9095551212", SecondaryPhone = "9095551313", EmailAddress = "chalan@bestbrakes.com" };
            _repo.Add(cust, false); 
            //Assert.AreEqual(EntityState.Added, _db.Entry(cust).State);
            Assert.IsTrue(cust.Id == 0);
            Assert.IsNull(cust.TimeStamp);
            _repo.SaveChanges();
            // Assert.AreEqual(EntityState.Unchanged, _db.Entry(cust).State);
            //Assert.IsTrue(driver.Id > 0);
            Assert.IsNotNull(cust.TimeStamp);
            Assert.IsNotNull(cust.DateCreated);
            Assert.IsNotNull(cust.DateModified);
            Assert.IsNotNull(cust.UserCreated);
            Assert.IsNotNull(cust.UserModified);
            Assert.AreEqual(1, _repo.Count);
        }

        [TestMethod]
        public void ShouldGetAllDriversOrderedByNameWithDbSet()
        {
            _db.Customers.Add(new Customer { Name = "Best Brakes"});
            _db.Customers.Add(new Customer { Name = "Acmer" });
            _db.Customers.Add(new Customer { Name = "Case Parts" });
            _db.SaveChanges();
            var customers = _db.Customers.OrderBy(d => d.Name).ToList();
            Assert.AreEqual(3, customers.Count());
            Assert.AreEqual("Acmer", customers[0].Name);
            Assert.AreEqual("Best Brakes", customers[1].Name);
            Assert.AreEqual("Case Parts", customers[2].Name);
        }

        [TestMethod]
        public void ShouldGetAllDriversOrderedByNameWithRepo()
        {
            _repo.Add(new Customer { Name = "Best Brakes" }, false);
            _repo.Add(new Customer { Name = "Acmer" }, false);
            _repo.Add(new Customer { Name = "Case Parts" }, false);
            _repo.SaveChanges();
            var customers = _repo.GetAll().ToList();
            Assert.AreEqual(3, customers.Count());
            Assert.AreEqual("Acmer", customers[0].Name);
            Assert.AreEqual("Best Brakes", customers[1].Name);
            Assert.AreEqual("Case Parts", customers[2].Name);
        }


        [TestMethod]
        public void ShouldUpdateCustomerWithDbSet()
        {
            var cust = new Customer { Name = "Best Brakes"};
            _db.Customers.Add(cust);
            _db.SaveChanges();

            var modified = cust.DateModified;

            cust.Name = "Best";
            Assert.AreEqual(EntityState.Modified, _db.Entry(cust).State);

            _db.SaveChanges();
            Assert.AreEqual(EntityState.Unchanged, _db.Entry(cust).State);

            using (var context = new RushHourContext())
            {
                Assert.AreEqual("Best", context.Customers.First().Name);
                Assert.AreNotEqual(modified, context.Customers.First().DateModified);
            }

        }

        [TestMethod]
        public void ShouldUpdateCustomerWithRepo()
        {
            var cust = new Customer { Name = "Best Brakes" };
            _repo.Add(cust, false);
            _repo.SaveChanges();

            var modified = cust.DateModified;

            cust.Name = "Best";
            Assert.AreEqual(EntityState.Modified, _repo.Context.Entry(cust).State);

            _repo.SaveChanges();
            Assert.AreEqual(EntityState.Unchanged, _repo.Context.Entry(cust).State);

            using (var context = new RushHourContext())
            {
                Assert.AreEqual("Best", context.Customers.First().Name);
                Assert.AreNotEqual(modified, context.Customers.First().DateModified);
            }

        }


        //[TestMethod]
        //public void ShouldNotUpdateNonAttachedCustomer()
        //{
        //    var cust = new Customer { Name = "Best Brakes" };
        //    _repo.Add(cust, false);          
            
        //    cust.Name = "Best";
        //    _repo.Context.Entry(cust).State = EntityState.Modified;

        //    var ex = Assert.ThrowsException <Exception>(() => _repo.Update(cust));
        //    Assert.AreEqual(ex.Message, "test");
        //}

        [TestMethod]
        public void ShouldDeleteCustomerWithDbSet()
        {
            var cust = new Customer { Name = "Best Brakes" };
            _db.Customers.Add(cust);
            _db.SaveChanges();
            Assert.AreEqual(1, _db.Customers.Count());
            _db.Customers.Remove(cust);
            Assert.AreEqual(EntityState.Deleted, _db.Entry(cust).State);
            _db.SaveChanges();
            Assert.AreEqual(0, _db.Customers.Count());
        }

        [TestMethod]
        public void ShouldDeleteCustomerWithRepo()
        {
            var cust = new Customer { Name = "Best Brakes" };
            _repo.Add(cust, false);
            _repo.SaveChanges();
            Assert.AreEqual(1, _repo.Count);
            _repo.Delete(cust, false);
            Assert.AreEqual(EntityState.Deleted, _repo.Context.Entry(cust).State);
            _repo.SaveChanges();
            Assert.AreEqual(0, _db.Customers.Count());
        }


        [TestMethod]
        public void ShouldDeleteDriverWithTimestampWithDbSet()
        {
            var cust = new Customer { Name = "Best Brakes" };
            _db.Customers.Add(cust);
            _db.SaveChanges();

            var context = new RushHourContext();
            var custToDelete = new Customer { Id = cust.Id, TimeStamp = cust.TimeStamp };
            context.Entry(custToDelete).State = EntityState.Deleted;
            var affected = context.SaveChanges();
            Assert.AreEqual(1, affected);
        }

        [TestMethod]
        public void ShouldDeleteDriverWithTimestampWithRepo()
        {
            var cust = new Customer { Name = "Best Brakes" };
            _repo.Add(cust, false);
            _repo.SaveChanges();

            var context = new RushHourContext();
            var custToDelete = new Customer { Id = cust.Id, TimeStamp = cust.TimeStamp };
            context.Entry(custToDelete).State = EntityState.Deleted;
            var affected = context.SaveChanges();
            Assert.AreEqual(1, affected);
        }


       

        private void CleanDatabase()
        {
            _db.Database.ExecuteSqlCommand("Delete from Customers");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT (\"Customers\", RESEED, -1);");
        }

        public void Dispose()
        {
            CleanDatabase();
            _db.Dispose();
        }
    }
}
