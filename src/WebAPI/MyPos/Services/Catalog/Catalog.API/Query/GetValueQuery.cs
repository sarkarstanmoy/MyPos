using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Query
{
    public class GetValueQuery
    {
        public record GetCatalogQuery(int id) : IRequest<GetCatalogResponse>;
        public record GetCatalogResponse(bool isFailure, CatalogDto CatalogDto);
    }
}