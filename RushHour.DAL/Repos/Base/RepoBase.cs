using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushHour.DAL.EF;
using RushHour.Models.Entities;
using RushHour.Models.Entities.Base;

namespace RushHour.DAL.Repos.Base
{
    public class RepoBase<T> : IDisposable, IRepo<T> where T : EntityBase, new()
    {
        protected readonly RushHourContext Db;
        protected DbSet<T> Table;
        public RushHourContext Context => Db;

        public RepoBase()
        {
            Db = new RushHourContext();
            Table = Db.Set<T>();
        }

        public T Find(int? id) => Table.Find(id);

        public T GetFirst() => Table.FirstOrDefault();

        public virtual IEnumerable<T> GetAll() => Table;

        public IEnumerable<T> GetRange(IQueryable<T> query, int skip, int take)
        => query.Skip(skip).Take(take);

        public virtual IEnumerable<T> GetRange(int skip, int take) => GetRange(Table, skip, take);

        public virtual int Add(T entity, bool persist = true)
        {
            Table.Add(entity);
            return persist ? SaveChanges() : 0;
        }

        public virtual int AddRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.AddRange(entities);
            return persist ? SaveChanges() : 0;
        }

        public virtual int Update(T entity, bool persist = true)
        {
            Db.Entry(entity).State = EntityState.Modified;
            return persist ? SaveChanges() : 0;
        }

        public virtual int UpdateRange(IEnumerable<T> entities, bool persist = true)
        {
            entities.ToList().ForEach(e => Db.Entry(e).State = EntityState.Modified);            
            return persist ? SaveChanges() : 0;
        }

        public virtual int Delete(T entity, bool persist = true)
        {
            Table.Remove(entity);
            return persist ? SaveChanges() : 0;
        }

        public virtual int DeleteRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.RemoveRange(entities);
            return persist ? SaveChanges() : 0;
        }

        public int SaveChanges()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (RetryLimitExceededException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public bool HasChanges => Db.ChangeTracker.HasChanges();

        public int Count => Table.Count();

        //internal T GetEntryFromChangeTracker(int? id)
        //{
        //    return Db.ChangeTracker.Entries<T>().FirstOrDefault(x => (T)x.Id == id);
        //}
        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if (disposing)
                    Db.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
