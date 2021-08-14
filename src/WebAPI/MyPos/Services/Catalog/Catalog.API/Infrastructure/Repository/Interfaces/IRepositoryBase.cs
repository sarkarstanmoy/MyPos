using System;
using System.Linq;
using System.Linq.Expressions;

namespace Catalog.API.Infrastructure.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll(int page, int pageSize);

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, int page, int pageSize);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}