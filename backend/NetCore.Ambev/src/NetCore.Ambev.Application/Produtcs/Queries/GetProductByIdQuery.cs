using Mapster;
using MediatR;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories;
using NetCore.Ambev.Application.Dtos;

namespace NetCore.Ambev.Application.Produtcs.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandle : IRequestHandler<GetProductByIdQuery, ProductDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetProductByIdQueryHandle(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var entity = await _unitOfWork.ProductRepository.FindAsync(request.Id);
                return entity.Adapt<ProductDto>();
            }
        }
    }
}
