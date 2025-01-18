﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCore.Ambev.Application.Carts.Commands;

namespace NetCore.Ambev.Api.Controllers
{
    public class CartController : BaseApiController
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> FindAsync(int id)
        //{
        //    var product = await _unitOfWork.ProductRepository.FindAsync(id);
        //    return Ok(product);
        //}

        //[HttpPost]
        //public async Task<IActionResult> PostAsync([FromBody]CreateCartCommand command)
        //{
        //    var entity = await _mediator.Send(command);

        //    return CreatedAtAction(nameof(FindAsync), new { id = entity.Id }, entity);
        //}
    }
}
