using CleanArchitecture.Application.Commands.Stores;
using CleanArchitecture.Application.Mapper.Stores;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Command;
using MediatR;

namespace CleanArchitecture.Application.Handlers.CommandHandlers.Stores
{
    public class CreateStoreHandler : IRequestHandler<CreateStoreCommand, StoreResponse>
    {
        private readonly ICommandStoreRepository _storeCommandRepository;
        public CreateStoreHandler(ICommandStoreRepository storeCommandRepository)
        {
            _storeCommandRepository = storeCommandRepository;
        }

        public async Task<StoreResponse> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var storeEntity = StoreMapper.Mapper.Map<Store>(request);

            if (storeEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newStore = await _storeCommandRepository.AddAsync(storeEntity);
            var response = StoreMapper.Mapper.Map<StoreResponse>(newStore);
            return response;
        }
    }
}
