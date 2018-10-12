using RushHour.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.DAL.Initializers
{
    public static class SampleData
    {
        public static IEnumerable<Customer> GetCustomers() => new List<Customer>
        {
            new Customer { Name = "Best Brakes", Address1 = "182 Arrow Ave", Address2 = "Suite B", City = "Chino", State="CA", PointOfContact = "Jon Jay", PrimaryPhone="9095551212", SecondaryPhone="9095551313", EmailAddress="chalan@bestbrakes.com"},
            new Customer { Name = "Best Brakes #2", Address1 = "182 Arrow Ave", Address2 = "Suite B", City = "Chino", State="CA", PointOfContact = "Jon Jay", PrimaryPhone="9095551212", SecondaryPhone="9095551313", EmailAddress="chalan@bestbrakes.com"},
            new Customer { Name = "Best Brakes #3", Address1 = "182 Arrow Ave", Address2 = "Suite B", City = "Chino", State="CA", PointOfContact = "Jon Jay", PrimaryPhone="9095551212", SecondaryPhone="9095551313", EmailAddress="chalan@bestbrakes.com"}
        };

        public static IEnumerable<CustomerAddress> GetCustomerAddresses() => new List<CustomerAddress>
        {
            new CustomerAddress { Name = "Store 50A", Address1 = "120 Temple City Blvd", City = "Temple City", Zip = "91780", CustomerId = 0},
            new CustomerAddress { Name = "Store 50B", Address1 = "3345 Rosemead Blvd", City = "Rosemead", Zip = "90054", CustomerId = 0},

            new CustomerAddress { Name = "Warehouse A", Address1 = "12495 Mountain Ave", City = "Ontario", Zip = "91224", CustomerId = 1},
            new CustomerAddress { Name = "Warehouse B", Address1 = "112 Olympic Blvd", City = "Los Angeles", Zip = "90005", CustomerId = 1},

            new CustomerAddress { Name = "Depot X", Address1 = "101 A Street", City = "Santa Monica", Zip = "91452", CustomerId = 2},
            new CustomerAddress { Name = "Depot Y", Address1 = "102 B Street", City = "Venice", Zip = "91452", CustomerId = 2}
        };

        public static IEnumerable<Driver> GetDrivers() => new List<Driver>
        {
            new Driver { FirstName = "Johnny", MiddleName = "Carlos", LastName = "Lopez" },
            new Driver { FirstName = "Andre", MiddleName = "Sebastian", LastName = "Lopez" },
            new Driver { FirstName = "Jacob", MiddleName = "Johnny", LastName = "Lopez" }
            
        };
    }
}
