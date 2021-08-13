using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Infrastructure.Repository
{
    public class GetCatalogRepository : IGetCatalogRepository
    {
        private readonly CatalogDbContext _catalogDbContext;

        public GetCatalogRepository(CatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext ?? throw new ArgumentNullException(nameof(catalogDbContext));
        }

        public async ValueTask<Catalog.API.Models.Catalog> GetCatalogAsync(int catalogId)
        {
            return _catalogDbContext.catalogDbSet.AsNoTracking().Include(x => x.Items).FirstOrDefault(x => x.CatalogId == catalogId);
        }
    }

    public interface IGetCatalogRepository
    {
        ValueTask<Catalog.API.Models.Catalog> GetCatalogAsync(int catalogId);
    }
}