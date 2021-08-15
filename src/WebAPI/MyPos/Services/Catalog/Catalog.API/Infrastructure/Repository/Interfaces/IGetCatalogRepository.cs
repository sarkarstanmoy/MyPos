using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catalog.API.Infrastructure.Repository.Interfaces
{
    public interface IGetCatalogRepository
    {
        ValueTask<Models.Catalog> GetCatalogAsync(Expression<Func<Models.Catalog, bool>> expression);
    }
}