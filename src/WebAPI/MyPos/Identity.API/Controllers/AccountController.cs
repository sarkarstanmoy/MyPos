using Identity.API.Infrastructure.Repositories;
using Identity.API.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Identity.API.Command.PostCommand;
using static Identity.API.Queries.GetValuesQuery;

namespace Identity.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            return Ok(await _mediator.Send(new GetUserQuery(user)));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            return Ok(await _mediator.Send(new PostUserCommand(user)));
        }
    }
}