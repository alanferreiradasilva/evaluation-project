using Mapster;
using MediatR;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories;
using NetCore.Ambev.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Ambev.Application.Produtcs.Queries
{
    public class GetProductQuery : IRequest<IEnumerable<ProductDto>>
    {
        public class GetProductQueryHandle : IRequestHandler<GetProductQuery, IEnumerable<ProductDto>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetProductQueryHandle(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                var entities = await _unitOfWork.ProductRepository.GetAsync();
                var dtos = entities.Adapt<List<ProductDto>>();
                return dtos;
            }
        }
    }
}
