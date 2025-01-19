using Mapster;
using MediatR;
using NetCore.Ambev.Abstractions.Repositories;
using NetCore.Ambev.Application.Dtos;

namespace NetCore.Ambev.Application.Users.Queries
{
    public class GetUserQuery : IRequest<IEnumerable<UserDto>>
    {
        public class GetUserQueryHandle : IRequestHandler<GetUserQuery, IEnumerable<UserDto>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetUserQueryHandle(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var entities = await _unitOfWork.UserRepository.GetAsync();

                var dtos = entities.Adapt<List<UserDto>>();

                return dtos;
            }
        }
    }
}
