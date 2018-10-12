
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushHour.DAL.Repos.Base;
using RushHour.Models.Entities;

namespace RushHour.DAL.Repos
{
    public class DriverRepo : RepoBase<Driver>
    {
        public DriverRepo()
        {
        }

        public override IEnumerable<Driver> GetAll()
        {
            return Table.OrderBy(x => x.FirstName);
        }

        public override IEnumerable<Driver> GetRange(int skip, int take)
        {
            return GetRange(Table.OrderBy(x => x.FirstName), skip, take);
        }
    }
}
