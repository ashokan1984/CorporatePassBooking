using CorporatePassBooking.Application.Repository;
using CorporatePassBooking.Domain.Common;
using CorporatePassBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CorporatePassBooking.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly CorporatePassBookingContext Context;

        public BaseRepository(CorporatePassBookingContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            Context.Add(entity);
        }

        public void Update(T entity)
        {
            try
            {
                Context.Update(entity);     
                Context.SaveChanges();      
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency conflicts here
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is T)
                    {
                        entry.Reload();
                    }
                }

                // Log the error, return a message, or rethrow to notify caller of conflict
                throw new Exception("The entity you tried to update was modified by another process.");
            }
        }

        public void Delete(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            Context.Update(entity);
        }

        public virtual Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return Context.Set<T>().FirstOrDefaultAsync(x => x.ID == id, cancellationToken);
        }

        public virtual Task<bool> Any(Guid id, CancellationToken cancellationToken)
        {
            return Context.Set<T>().AnyAsync(x => x.ID == id, cancellationToken);
        }

        public virtual Task<T> GetWithoutChangeTracking(Guid id, CancellationToken cancellationToken)
        {
            return Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.ID == id, cancellationToken);
        }

        public virtual Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return Context.Set<T>().ToListAsync(cancellationToken);
        }

        public virtual List<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.ToList();
        }

        public virtual Task<List<T>> GetAllNoTracking(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            query.AsNoTracking();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.ToListAsync();
        }

        public virtual Task<List<T>> GetAllWithoutChangeTracking(CancellationToken cancellationToken)
        {
            return Context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
    }
}
