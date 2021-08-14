using Catalog.API.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catalog.API.Infrastructure.Repository
{
    public class GetCatalogRepository : RepositoryBase<Models.Catalog>, IGetCatalogRepository
    {
        public GetCatalogRepository(CatalogDbContext catalogDbContext) : base(catalogDbContext)
        {
        }

        public async ValueTask<Models.Catalog> GetCatalogAsync(Expression<Func<Models.Catalog, bool>> expression, int page, int pageSize)
        {
            return await FindByCondition(expression, page, pageSize).Include(x => x.Items).FirstOrDefaultAsync();
        }
    }
}