using SharedKernel.Infrastructure.Entities;
using SharedKernel.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SharedKernel.Application.Services
{
    public interface IService<TEntity> where TEntity : EntityBase
    {
        // TEntity FindByKey(int id);

        // TEntity FindByKeyAsNoTracking(int id);

        // TEntity FindByKeyInclude(int id, params Expression<Func<TEntity, object>>[] includeProperties);

        // TEntity FindByKeyIncludeAsNoTracking(int id, params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        PagedResult<TEntity> Select(
            int page,
            int pageSize,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        // void DeleteByKey(int id);

        void Delete(TEntity entity);
    }

}
