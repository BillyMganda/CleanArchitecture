using CleanArchitecture.Domain.DTOs.Users;
using MediatR;

namespace CleanArchitecture.Application.Queries.Users
{
    public class GetUserByIdQuery : IRequest<GetUserDto>
    {
        public Guid Id { get; private set; }
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
