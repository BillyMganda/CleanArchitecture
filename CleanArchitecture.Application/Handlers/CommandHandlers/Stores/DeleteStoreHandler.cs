using CleanArchitecture.Application.Commands.Stores;
using CleanArchitecture.Domain.Repositories.Command;
using CleanArchitecture.Domain.Repositories.Query;
using MediatR;

namespace CleanArchitecture.Application.Handlers.CommandHandlers.Stores
{
    public class DeleteStoreHandler : IRequestHandler<DeleteStoreCommand, string>
    {
        private readonly ICommandStoreRepository _storeCommandRepository;
        private readonly IStoreQueryRepository _storeQueryRepository;
        public DeleteStoreHandler(ICommandStoreRepository storeCommandRepository, IStoreQueryRepository storeQueryRepository)
        {
            _storeCommandRepository = storeCommandRepository;
            _storeQueryRepository = storeQueryRepository;
        }

        public async Task<string> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _storeQueryRepository.GetByIdAsync(request.Id);

                await _storeCommandRepository.DeleteAsync(entity);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Store information has been deleted!";
        }
    }
}
