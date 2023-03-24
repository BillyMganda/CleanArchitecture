using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Commands.Users;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Application.Mapper.Users;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.DTOs.Users;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handlers.CommandHandlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, GetUserDto>
    {
        private readonly ICommandUserRepository _userCommandRepository;
        public CreateUserHandler(ICommandUserRepository userCommandRepository)
        {
            _userCommandRepository = userCommandRepository;
        }

        public async Task<GetUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = UserMapper.Mapper.Map<User>(request);

            if (entity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newUser = await _userCommandRepository.AddAsync(entity);
            var response = UserMapper.Mapper.Map<GetUserDto>(newUser);
            return response;
        }
    }
}
