using Catalog.API.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Catalog.API.Infrastructure.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CatalogDbContext CatalogDbContext { get; set; }

        protected RepositoryBase(CatalogDbContext catalogDbContext)
        {
            this.CatalogDbContext = catalogDbContext ?? throw new ArgumentNullException(nameof(catalogDbContext));
        }

        public void Create(T entity)
        {
            this.CatalogDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.CatalogDbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(int page, int pageSize)
        {
            return this.CatalogDbContext.Set<T>().AsNoTracking().Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IQueryable<T> FindAll()
        {
            return this.CatalogDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, int page, int pageSize)
        {
            return this.CatalogDbContext.Set<T>().AsNoTracking().Where(expression).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.CatalogDbContext.Set<T>().AsNoTracking().Where(expression);
        }

        public void Update(T entity)
        {
            this.CatalogDbContext.Set<T>().Update(entity);
        }
    }
}