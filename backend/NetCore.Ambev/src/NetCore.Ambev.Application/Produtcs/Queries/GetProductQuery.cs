using MediatR;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Ambev.Application.Produtcs.Queries
{
    public class GetProductQuery : IRequest<IEnumerable<Product>>
    {
        public class GetProductQueryHandle : IRequestHandler<GetProductQuery, IEnumerable<Product>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetProductQueryHandle(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                var entities = await _unitOfWork.ProductRepository.GetAsync();
                return entities;
            }
        }
    }
}
