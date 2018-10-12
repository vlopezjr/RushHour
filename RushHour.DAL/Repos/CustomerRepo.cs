
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
    public class CustomerRepo : RepoBase<Customer>, ICustomerRepo
    {
        public CustomerRepo()
        {
        }

        public override IEnumerable<Customer> GetAll()
        {
            return Table.OrderBy(x => x.Name);
        }

        public override IEnumerable<Customer> GetRange(int skip, int take)
        {
            return GetRange(Table.OrderBy(x => x.Name), skip, take);
        }
    }
}
