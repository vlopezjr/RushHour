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
    public class DriverTests : IDisposable
    {
        private readonly RushHourContext _db;
        private readonly DriverRepo _repo;

        public DriverTests()
        {
            _db = new RushHourContext();
            _repo = new DriverRepo();
            CleanDatabase();
        }

        

        [TestMethod]
        public void ShouldAddDriverWithDbSet()
        {
            var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
            _db.Drivers.Add(driver);
            Assert.AreEqual(EntityState.Added, _db.Entry(driver).State);
            Assert.IsTrue(driver.Id == 0);
            Assert.IsNull(driver.TimeStamp);
            _db.SaveChanges();
            Assert.AreEqual(EntityState.Unchanged, _db.Entry(driver).State);
            //Assert.IsTrue(driver.Id > 0);
            Assert.IsNotNull(driver.TimeStamp);
            Assert.IsNotNull(driver.DateCreated);
            Assert.IsNotNull(driver.DateModified);
            Assert.IsNotNull(driver.UserCreated);
            Assert.IsNotNull(driver.UserModified);
            Assert.AreEqual(1, _db.Drivers.Count());
        }

        [TestMethod]
        public void ShouldAddDriverWithDbRepo()
        {
            var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
            _repo.Add(driver, false);
            Assert.AreEqual(EntityState.Added, _repo.Context.Entry(driver).State);
            Assert.IsTrue(driver.Id == 0);
            Assert.IsNull(driver.TimeStamp);
            _repo.SaveChanges();
            Assert.AreEqual(EntityState.Unchanged, _repo.Context.Entry(driver).State);
            //Assert.IsTrue(driver.Id > 0);
            Assert.IsNotNull(driver.TimeStamp);
            Assert.IsNotNull(driver.DateCreated);
            Assert.IsNotNull(driver.DateModified);
            Assert.IsNotNull(driver.UserCreated);
            Assert.IsNotNull(driver.UserModified);
            Assert.AreEqual(1, _repo.Count);
        }

        [TestMethod]
        public void ShouldGetAllDriversOrderedByNameWithDbSet()
        {
            _db.Drivers.Add(new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" });
            _db.Drivers.Add(new Driver { FirstName = "Andre", MiddleName = "Sebastian", LastName = "Lopez" });
            _db.Drivers.Add(new Driver { FirstName = "Jacob", MiddleName = "Johnny", LastName = "Lopez" });
            _db.SaveChanges();
            var drivers = _db.Drivers.OrderBy(d => d.FirstName).ToList();
            Assert.AreEqual(3, drivers.Count());
            Assert.AreEqual("Andre", drivers[0].FirstName);
            Assert.AreEqual("Jacob", drivers[1].FirstName);
            Assert.AreEqual("Johnny", drivers[2].FirstName);
        }

        [TestMethod]
        public void ShouldGetAllDriversOrderedByNameWithRepo()
        {
            _repo.Add(new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" }, false);
            _repo.Add(new Driver { FirstName = "Andre", MiddleName = "Sebastian", LastName = "Lopez" }, false);
            _repo.Add(new Driver { FirstName = "Jacob", MiddleName = "Johnny", LastName = "Lopez" }, false);
            _repo.SaveChanges();
            var drivers = _repo.GetAll().ToList();
            Assert.AreEqual(3, drivers.Count());
            Assert.AreEqual("Andre", drivers[0].FirstName);
            Assert.AreEqual("Jacob", drivers[1].FirstName);
            Assert.AreEqual("Johnny", drivers[2].FirstName);
        }

        [TestMethod]
        public void ShouldUpdateDriverWithDbSet()
        {
            var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
            _db.Drivers.Add(driver);            
            _db.SaveChanges();

            var modified = driver.DateModified;

            driver.FirstName = "Juan";
            Assert.AreEqual(EntityState.Modified, _db.Entry(driver).State);

            _db.SaveChanges();
            Assert.AreEqual(EntityState.Unchanged, _db.Entry(driver).State);

            using (var context = new RushHourContext())
            {
                Assert.AreEqual("Juan", context.Drivers.First().FirstName);
                Assert.AreNotEqual(modified, context.Drivers.First().DateModified);
            }

        }

        [TestMethod]
        public void ShouldUpdateDriverWithRepo()
        {
            var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
            _repo.Add(driver, false);
            _repo.SaveChanges();

            var modified = driver.DateModified;

            driver.FirstName = "Juan";
            Assert.AreEqual(EntityState.Modified, _repo.Context.Entry(driver).State);

            _repo.SaveChanges();
            Assert.AreEqual(EntityState.Unchanged, _repo.Context.Entry(driver).State);

            using (var context = new RushHourContext())
            {
                Assert.AreEqual("Juan", context.Drivers.First().FirstName);
                Assert.AreNotEqual(modified, context.Drivers.First().DateModified);
            }

        }


        //[TestMethod]
        //public void ShouldNotUpdateNonAttachedDriver()
        //{
        //    var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
        //    _db.Drivers.Add(driver);
        //    driver.FirstName = "Juan";
        //    _db.Entry(driver).State = EntityState.Modified;


        //}

        [TestMethod]
        public void ShouldDeleteDriverWithDbSet()
        {
            var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
            _db.Drivers.Add(driver);
            _db.SaveChanges();
            Assert.AreEqual(1, _db.Drivers.Count());
            _db.Drivers.Remove(driver);
            Assert.AreEqual(EntityState.Deleted, _db.Entry(driver).State);
            _db.SaveChanges();
            Assert.AreEqual(0, _db.Drivers.Count());
        }

        [TestMethod]
        public void ShouldDeleteDriverWithRepo()
        {
            var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
            _repo.Add(driver, false);
            _repo.SaveChanges();
            Assert.AreEqual(1, _repo.Count);
            _repo.Delete(driver, false);
            Assert.AreEqual(EntityState.Deleted, _repo.Context.Entry(driver).State);
            _repo.SaveChanges();
            Assert.AreEqual(0, _repo.Count);
        }


        [TestMethod]
        public void ShouldDeleteDriverWithTimestampWithDbSet()
        {
            var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
            _db.Drivers.Add(driver);
            _db.SaveChanges();

            var context = new RushHourContext();
            var driverToDelete = new Driver { Id = driver.Id, TimeStamp = driver.TimeStamp };
            context.Entry(driverToDelete).State = EntityState.Deleted;
            var affected = context.SaveChanges();
            Assert.AreEqual(1, affected);
        }

        [TestMethod]
        public void ShouldDeleteDriverWithTimestampWithRepo()
        {
            var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
            _repo.Add(driver,false);
            _repo.SaveChanges();

            var context = new RushHourContext();
            var driverToDelete = new Driver { Id = driver.Id, TimeStamp = driver.TimeStamp };
            context.Entry(driverToDelete).State = EntityState.Deleted;
            var affected = context.SaveChanges();
            Assert.AreEqual(1, affected);
        }

        //[TestMethod]
        //public void ShouldNotDeleteDriverWithoutTimestamp()
        //{
        //    var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
        //    _db.Drivers.Add(driver);
        //    _db.SaveChanges();

        //    var context = new RushHourContext();
        //    var driverToDelete = new Driver { Id = driver.Id };
        //    context.Drivers.Remove(driverToDelete);

        //    var ex = Assert.ThrowsException<InvalidOperationException>(() => _db.SaveChanges());


        //    Assert.AreEqual(1, ex.);
        //}


        private void CleanDatabase()
        {
            _db.Database.ExecuteSqlCommand("Delete from Drivers");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT (\"Drivers\", RESEED, -1);");
        }

        public void Dispose()
        {
            CleanDatabase();
            _db.Dispose();
        }
    }
}
