using CleanArchitecture.Application.Queries.Stores;
using CleanArchitecture.Application.Queries.Users;
using CleanArchitecture.Domain.DTOs.Users;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handlers.QueryHandlers.Users
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserDto>
    {
        private readonly IMediator _mediator;
        public GetUserByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<GetUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetAllUserQuery());
            var selectedUser = users.FirstOrDefault(x => x.Id == request.Id);
            return selectedUser!;
        }
    }
}
