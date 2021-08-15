using Catalog.API.Infrastructure.Repository.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static Catalog.API.Query.GetValueQuery;

namespace Catalog.API.Handler
{
    public class GetCatalogQueryHandler : IRequestHandler<GetCatalogQuery, GetCatalogResponse>
    {
        private readonly IGetCatalogRepository _getCatalogRepository;

        public GetCatalogQueryHandler(IGetCatalogRepository getCatalogRepository)
        {
            _getCatalogRepository = getCatalogRepository;
        }

        public async Task<GetCatalogResponse> Handle(GetCatalogQuery request, CancellationToken cancellationToken)
        {
            var record = await _getCatalogRepository.GetCatalogAsync(x => x.CatalogType.ToLower() == request.catalogType.ToLower());

            if (record == null)
                return new GetCatalogResponse(true, null);
            else
            {
                var catalogDto = new Models.CatalogDto()
                {
                    CatalogType = record.CatalogType,
                    Items = record.Items
                };
                return new GetCatalogResponse(true, catalogDto);
            }
        }
    }
}