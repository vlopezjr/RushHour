using RushHour.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.MVC.WebServiceAccess.Base
{
    public interface IWebApiCalls
    {
        Task<IList<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task<int> AddDelivery(Delivery delivery);
    }
}
