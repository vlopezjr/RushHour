
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushHour.DAL.Repos.Base;
using RushHour.DAL.Repos.Interfaces;
using RushHour.Models.Entities;

namespace RushHour.DAL.Repos
{
    public class CustomerAddressRepo : RepoBase<CustomerAddress>, ICustomerAddressRepo
    {
        public CustomerAddressRepo()
        {
        }

        public IEnumerable<CustomerAddress> GetAllForCustomer(int customerId)
        {
            return Table.Where(x=>x.CustomerId == customerId).OrderBy(x => x.Name);
        }        
    }
}
