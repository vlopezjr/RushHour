using Microsoft.VisualStudio.TestTools.UnitTesting;
using RushHour.DAL.EF;
using RushHour.DAL.Repos;
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
    public class DeliveryTests : IDisposable
    {
        private readonly RushHourContext _db;
        //private readonly CustomerRepo _custRepo;
        //private readonly 
        private readonly DeliveryRepo _repo;

        public DeliveryTests()
        {
            _db = new RushHourContext();
            _repo = new DeliveryRepo();
            CleanDatabase();
        }

        

        [TestMethod]
        public void ShouldAddDeliveryWithoutFreightWithDbSet()
        {
            var cust = new Customer { Name = "Best Brakes" };
            var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
            var address = new CustomerAddress { Address1 = "282 E Benbow", CustomerId = cust.Id };
            var delivery = new Delivery { RefNo = 111, DeliveryCharge = 10.85m, TotalCharge = 10.85m, CustomerId = cust.Id, DriverId = driver.Id, DeliverToAddressId = address.Id };

            _db.Customers.Add(cust);
            _db.Drivers.Add(driver);
            _db.Addresses.Add(address);
            _db.Deliveries.Add(delivery);
            Assert.AreEqual(EntityState.Added, _db.Entry(delivery).State);
            Assert.IsTrue(delivery.Id == 0);
            _db.SaveChanges();

            Assert.IsTrue(cust.Id > -1);
            Assert.IsTrue(driver.Id > -1);
            Assert.IsTrue(delivery.Id > -1);

            Assert.AreEqual("Best Brakes", delivery.Customer.Name);
            Assert.AreEqual("Johnny", delivery.Driver.FirstName);

            Assert.IsNotNull(delivery.TimeStamp);
            Assert.IsNotNull(delivery.DateCreated);
            Assert.IsNotNull(delivery.DateModified);
            Assert.IsNotNull(delivery.UserCreated);
            Assert.IsNotNull(driver.UserModified);
            Assert.AreEqual(1, _db.Deliveries.Count());         
        }

        [TestMethod]
        public void ShouldAddDeliveryWithFreightWithDbSet()
        {
            var cust = new Customer { Name = "Best Brakes" };
            var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
            var address = new CustomerAddress { Address1 = "282 E Benbow", CustomerId = cust.Id };
            var delivery = new Delivery { RefNo = 111, DeliveryCharge = 10.85m, TotalCharge = 10.85m, CustomerId = cust.Id, DriverId = driver.Id, DeliverToAddressId = address.Id };
            var freights = new List<Freight>
            {
                new Freight { Quantity = 1, DeliveryId = delivery.Id, Type = FreightType.Box },
                new Freight { Quantity = 1, DeliveryId = delivery.Id, Type = FreightType.Envelope },
                new Freight { Quantity = 1, DeliveryId = delivery.Id, Type = FreightType.Pallet }
            };

            _db.Customers.Add(cust);
            _db.Drivers.Add(driver);
            _db.Addresses.Add(address);
            _db.Deliveries.Add(delivery);
            _db.Freights.AddRange(freights);

            Assert.AreEqual(EntityState.Added, _db.Entry(delivery).State);
            Assert.IsTrue(delivery.Id == 0);
            _db.SaveChanges();

            Assert.IsTrue(cust.Id > -1);
            Assert.IsTrue(driver.Id > -1);
            Assert.IsTrue(delivery.Id > -1);

            Assert.AreEqual("Best Brakes", delivery.Customer.Name);
            Assert.AreEqual("Johnny", delivery.Driver.FirstName);

            Assert.IsNotNull(delivery.TimeStamp);
            Assert.IsNotNull(delivery.DateCreated);
            Assert.IsNotNull(delivery.DateModified);
            Assert.IsNotNull(delivery.UserCreated);
            Assert.IsNotNull(driver.UserModified);
            Assert.AreEqual(1, _db.Deliveries.Count());
            Assert.AreEqual(3, delivery.Freights.Count());
            Assert.AreEqual(3, _db.Freights.Count());
            Assert.AreEqual(111, freights[0].Delivery.RefNo);
        }

        //[TestMethod]
        //public void ShouldAddDeliveryWithFreightWithRepo()
        //{
        //    var cust = new Customer { Name = "Best Brakes" };
        //    var driver = new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" };
        //    var delivery = new Delivery { RefNo = 111, DeliveryCharge = 10.85m, TotalCharge = 10.85m, CustomerId = cust.Id, DriverId = driver.Id };
        //    var freights = new List<Freight>
        //    {
        //        new Freight { Quantity = 1, DeliveryId = delivery.Id, Type = FreightType.Box },
        //        new Freight { Quantity = 1, DeliveryId = delivery.Id, Type = FreightType.Envelope },
        //        new Freight { Quantity = 1, DeliveryId = delivery.Id, Type = FreightType.Pallet }
        //    };

           
        //    _repo.Add(delivery, false);
            

        //    Assert.AreEqual(EntityState.Added, _db.Entry(delivery).State);
        //    Assert.IsTrue(delivery.Id == 0);
        //    _db.SaveChanges();

        //    Assert.IsTrue(cust.Id > -1);
        //    Assert.IsTrue(driver.Id > -1);
        //    Assert.IsTrue(delivery.Id > -1);

        //    Assert.AreEqual("Best Brakes", delivery.Customer.Name);
        //    Assert.AreEqual("Johnny", delivery.Driver.FirstName);

        //    Assert.IsNotNull(delivery.TimeStamp);
        //    Assert.IsNotNull(delivery.DateCreated);
        //    Assert.IsNotNull(delivery.DateModified);
        //    Assert.IsNotNull(delivery.UserCreated);
        //    Assert.IsNotNull(driver.UserModified);
        //    Assert.AreEqual(1, _db.Deliveries.Count());
        //    Assert.AreEqual(3, delivery.Freights.Count());
        //    Assert.AreEqual(3, _db.Freights.Count());
        //    Assert.AreEqual(111, freights[0].Delivery.RefNo);
        //}

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

            _db.Database.ExecuteSqlCommand("Delete from Deliveries");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT (\"Deliveries\", RESEED, -1);");

            _db.Database.ExecuteSqlCommand("Delete from CustomerAddresses");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT (\"CustomerAddresses\", RESEED, -1);");

            _db.Database.ExecuteSqlCommand("Delete from Customers");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT (\"Customers\", RESEED, -1);");

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

