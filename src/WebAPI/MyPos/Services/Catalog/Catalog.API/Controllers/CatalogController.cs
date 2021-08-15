using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Catalog.API.Query.GetValueQuery;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("catalog/{catalogType}")]
        public async Task<IActionResult> GetCatalog(string catalogType)
        {
            return Ok(await _mediator.Send(new GetCatalogQuery(catalogType)));
        }
    }
}