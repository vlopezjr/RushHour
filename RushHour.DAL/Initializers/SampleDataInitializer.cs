using RushHour.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.DAL.Initializers
{
    public static class SampleDataInitializer
    {
        public static void InitializeData(RushHourContext context)
        {
            ClearData(context);
            ResetIdentity(context);
            SeedData(context);
        }

        public static void ClearData(RushHourContext context)
        {
            ExecuteDeleteSQL(context, "CustomerAddresses");
            ExecuteDeleteSQL(context, "Customers");
            ExecuteDeleteSQL(context, "Drivers");
            ExecuteDeleteSQL(context, "Deliveries");
        }

        public static void ExecuteDeleteSQL(RushHourContext context, string tableName)
        {
            var sql = $"Delete from {tableName}";
            context.Database.ExecuteSqlCommand(sql);
        }

        public static void ResetIdentity(RushHourContext context)
        {
            var tables = new[] {"Drivers", "CustomerAddresses","Customers",
                "Deliveries"};
            foreach (var itm in tables)
            {
                var sql = $"DBCC CHECKIDENT (\"{itm}\", RESEED, -1);";
                context.Database.ExecuteSqlCommand(sql);
            }
        }

        public static void SeedData(RushHourContext context)
        {
            try
            {
                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(SampleData.GetCustomers());
                    context.SaveChanges();
                }

                if (!context.Addresses.Any())
                {
                    context.Addresses.AddRange(SampleData.GetCustomerAddresses());
                    context.SaveChanges();
                }

                if (!context.Drivers.Any())
                {
                    context.Drivers.AddRange(SampleData.GetDrivers());
                    context.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
