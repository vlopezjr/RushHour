
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
    public class DeliveryRepo : RepoBase<Delivery>, IDeliveryRepo
    {
        public DeliveryRepo()
        {
        }

        public override IEnumerable<Delivery> GetAll()
        {
            return Table.OrderBy(x => x.CustomerId);
        }

        public override IEnumerable<Delivery> GetRange(int skip, int take)
        {
            return GetRange(Table.OrderBy(x => x.CustomerId), skip, take);
        }
    }
}
