using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushHour.Models.Entities;
using RushHour.Models.Entities.Base;

namespace RushHour.DAL.Repos.Base
{
    public interface IRepo<T> where T : EntityBase
    {
        int Count { get; }
        bool HasChanges { get; }
        T Find(int? id);
        T GetFirst();
        IEnumerable<T> GetAll();
        IEnumerable<T> GetRange(int skip, int take);
        int Add(T entity, bool persist = true);
        int AddRange(IEnumerable<T> entities, bool persist = true);
        int Update(T entity, bool persists = true);
        int UpdateRange(IEnumerable<T> entities, bool persist = true);
        int Delete(T entity, bool persists = true);
        int DeleteRange(IEnumerable<T> entities, bool persist = true);
        //int Delete(int id, byte[] timeStamp, bool persist = true);
        int SaveChanges();
    }
}
