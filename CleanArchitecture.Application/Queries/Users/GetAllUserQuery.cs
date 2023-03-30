using CleanArchitecture.Domain.DTOs.Users;
using MediatR;

namespace CleanArchitecture.Application.Queries.Users
{
    public class GetAllUserQuery : IRequest<List<GetUserDto>>
    {
    }
}
