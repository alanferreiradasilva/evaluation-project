using MediatR;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories;

namespace NetCore.Ambev.Application.Produtcs.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandle : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetProductByIdQueryHandle(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var entities = await _unitOfWork.ProductRepository.FindAsync(request.Id);
                return entities;
            }
        }
    }
}
