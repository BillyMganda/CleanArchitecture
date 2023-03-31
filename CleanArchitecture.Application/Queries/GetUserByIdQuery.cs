using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
