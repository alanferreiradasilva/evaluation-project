using MediatR;
using NetCore.Ambev.Abstractions.Entities;
using NetCore.Ambev.Abstractions.Repositories;
using NetCore.Ambev.Abstractions.Repositories.NoSql;

namespace NetCore.Ambev.Application.Carts.Query
{
    public class GetCartsQuery : IRequest<IEnumerable<Cart>>
    {
        public class GetCartsQueryHandler : IRequestHandler<GetCartsQuery, IEnumerable<Cart>>
        {
            private readonly INoSqlUnitOfWork _noSqlUnitOfWork;

            public GetCartsQueryHandler(INoSqlUnitOfWork noSqlUnitOfWork)
            {
                _noSqlUnitOfWork = noSqlUnitOfWork;
            }

            public async Task<IEnumerable<Cart>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
            {
                var Carts = await _noSqlUnitOfWork.CartNoSqlRepository.GetAllAsync();
                return Carts;
            }
        }
    }
}
