using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Commands.Users;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Application.Mapper.Users;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.DTOs.Users;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Command;
using CleanArchitecture.Domain.Repositories.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handlers.CommandHandlers.Users
{
    public class EditUserHandler : IRequestHandler<EditUserCommand, GetUserDto>
    {
        private readonly ICommandUserRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        public EditUserHandler(ICommandUserRepository userCommandRepository, IUserQueryRepository userQueryRepository)
        {
            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<GetUserDto> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var entity = UserMapper.Mapper.Map<User>(request);

            if (entity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _userCommandRepository.UpdateAsync(entity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedUser = await _userQueryRepository.GetByIdAsync(request.Id);
            var response = UserMapper.Mapper.Map<GetUserDto>(modifiedUser);

            return response;
        }
    }
}
