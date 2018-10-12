using Microsoft.VisualStudio.TestTools.UnitTesting;
using RushHour.DAL.EF;
using RushHour.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.DAL.Tests
{
    [TestClass]
    public class FreightTests : IDisposable
    {
        private readonly RushHourContext _db;

        public FreightTests()
        {
            _db = new RushHourContext();
            CleanDatabase();
        }

        [TestMethod]
        public void FirstTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ShouldAddFreightWithDbSet()
        {
            //var delivery = new Delivery {  }
            //var freight = new Freight { };
            //_db.Drivers.Add(driver);
            //Assert.AreEqual(EntityState.Added, _db.Entry(driver).State);
            //Assert.IsTrue(driver.Id == 0);
            //Assert.IsNull(driver.TimeStamp);
            //_db.SaveChanges();
            //Assert.AreEqual(EntityState.Unchanged, _db.Entry(driver).State);
            ////Assert.IsTrue(driver.Id > 0);
            //Assert.IsNotNull(driver.TimeStamp);
            //Assert.IsNotNull(driver.DateCreated);
            //Assert.IsNotNull(driver.DateModified);
            //Assert.IsNotNull(driver.UserCreated);
            //Assert.IsNotNull(driver.UserModified);
            //Assert.AreEqual(1, _db.Drivers.Count());
        }

        //[TestMethod]
        //public void ShouldGetAllDriversOrderedByName()
        //{
        //    _db.Drivers.Add(new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" });
        //    _db.Drivers.Add(new Driver { FirstName = "Andre", MiddleName = "Sebastian", LastName = "Lopez" });
        //    _db.Drivers.Add(new Driver { FirstName = "Jacob", MiddleName = "Johnny", LastName = "Lopez" });
        //    _db.SaveChanges();
        //    var drivers = _db.Drivers.OrderBy(d => d.FirstName).ToList();
        //    Assert.AreEqual(3, drivers.Count());
        //    Assert.AreEqual("Andre", drivers[0].FirstName);
        //    Assert.AreEqual("Jacob", drivers[1].FirstName);
        //    Assert.AreEqual("Johnny", drivers[2].FirstName);
        //}

        //[TestMethod]
        //public void ShouldUpdateDriver()
        //{
        //    var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
        //    _db.Drivers.Add(driver);
        //    _db.SaveChanges();

        //    var modified = driver.DateModified;

        //    driver.FirstName = "Juan";
        //    Assert.AreEqual(EntityState.Modified, _db.Entry(driver).State);

        //    _db.SaveChanges();
        //    Assert.AreEqual(EntityState.Unchanged, _db.Entry(driver).State);

        //    using (var context = new RushHourContext())
        //    {
        //        Assert.AreEqual("Juan", context.Drivers.First().FirstName);
        //        Assert.AreNotEqual(modified, context.Drivers.First().DateModified);
        //    }

        //}       

        //[TestMethod]
        //public void ShouldDeleteDriver()
        //{
        //    var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
        //    _db.Drivers.Add(driver);
        //    _db.SaveChanges();
        //    Assert.AreEqual(1, _db.Drivers.Count());
        //    _db.Drivers.Remove(driver);
        //    Assert.AreEqual(EntityState.Deleted, _db.Entry(driver).State);
        //    _db.SaveChanges();
        //    Assert.AreEqual(0, _db.Drivers.Count());
        //}


        //[TestMethod]
        //public void ShouldDeleteDriverWithTimestamp()
        //{
        //    var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
        //    _db.Drivers.Add(driver);
        //    _db.SaveChanges();

        //    var context = new RushHourContext();
        //    var driverToDelete = new Driver { Id = driver.Id, TimeStamp = driver.TimeStamp };
        //    context.Entry(driverToDelete).State = EntityState.Deleted;
        //    var affected = context.SaveChanges();
        //    Assert.AreEqual(1, affected);
        //}



        private void CleanDatabase()
        {
            _db.Database.ExecuteSqlCommand("Delete from Freights");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT (\"Freights\", RESEED, -1);");
        }

        public void Dispose()
        {
            CleanDatabase();
            _db.Dispose();
        }
    }
}
