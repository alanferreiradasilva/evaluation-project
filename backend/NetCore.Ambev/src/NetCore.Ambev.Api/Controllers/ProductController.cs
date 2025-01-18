using Microsoft.AspNetCore.Mvc;
using NetCore.Ambev.Abstractions.Repositories;

namespace NetCore.Ambev.Api.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.FindAsync(id);
            return Ok(product);
        }
    }
}
