using CleanArchitecture.Application.Queries.Users;
using CleanArchitecture.Domain.DTOs.Users;
using CleanArchitecture.Domain.Repositories.Query;
using MediatR;

namespace CleanArchitecture.Application.Handlers.QueryHandlers.Users
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, List<GetUserDto>>
    {
        private readonly IUserQueryRepository _userQueryRepository;
        public GetAllUserHandler(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }

        public async Task<List<GetUserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return (List<GetUserDto>)await _userQueryRepository.GetAllAsync();
        }
    }
}
