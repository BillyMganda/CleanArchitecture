using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Commands.Users;
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
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly ICommandUserRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        public DeleteUserHandler(ICommandUserRepository userCommandRepository, IUserQueryRepository userQueryRepository)
        {
            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _userQueryRepository.GetByIdAsync(request.Id);

                await _userCommandRepository.DeleteAsync(entity);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "User information has been deleted!";
        }
    }
}
