using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCore.Ambev.Application.Produtcs.Queries;
using NetCore.Ambev.Application.Users.Queries;

namespace NetCore.Ambev.Api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var query = new GetUserQuery();
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }
    }
}
