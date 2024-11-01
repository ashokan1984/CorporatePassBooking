﻿using CorporatePassBooking.Domain.Common;
using System.Linq.Expressions;

namespace CorporatePassBooking.Application.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> Get(Guid id, CancellationToken cancellationToken);

        Task<T> GetWithoutChangeTracking(Guid id, CancellationToken cancellationToken);

        Task<List<T>> GetAll(CancellationToken cancellationToken);

        Task<List<T>> GetAllWithoutChangeTracking(CancellationToken cancellationToken);

        Task<List<T>> GetAllNoTracking(params Expression<Func<T, object>>[] includes);

        Task<bool> Any(Guid id, CancellationToken cancellationToken);

    }
}
