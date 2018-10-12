using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using RushHour.Models.Entities;
using RushHour.MVC.Configuration;

namespace RushHour.MVC.WebServiceAccess.Base
{
    public class WebApiCalls : WebApiCallsBase, IWebApiCalls
    {
        public WebApiCalls(IWebServiceLocator settings) : base(settings)
        {
        }

        public async Task<int> AddDelivery(Delivery delivery)
        {
            var json = JsonConvert.SerializeObject(delivery);
            var uri = $"{DeliveryBaseUri}";
            return int.Parse(await SubmitPostRequestAsync(uri, json));
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await GetItemAsync<Customer>($"{CustomerBaseUri}/{id}");
        }

        public async Task<IList<Customer>> GetCustomersAsync()
        {
            return await GetItemListAsync<Customer>(CustomerBaseUri);
            
        }
    }
}