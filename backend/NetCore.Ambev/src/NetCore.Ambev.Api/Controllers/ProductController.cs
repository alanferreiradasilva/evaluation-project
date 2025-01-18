using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCore.Ambev.Abstractions.Repositories;
using NetCore.Ambev.Application.Produtcs.Queries;

namespace NetCore.Ambev.Api.Controllers
{    
    public class ProductController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var query = new GetProductQuery();
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindAsync(int id)
        {
            var query = new GetProductByIdQuery() { Id = id };
            var entity = await _mediator.Send(query);
            return Ok(entity);
        }

        
    }
}
