using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Query
{
    public class GetValueQuery
    {
        public record GetCatalogQuery(string catalogType) : IRequest<GetCatalogResponse>;
        public record GetCatalogResponse(bool isFailure, CatalogDto CatalogDto);
    }
}