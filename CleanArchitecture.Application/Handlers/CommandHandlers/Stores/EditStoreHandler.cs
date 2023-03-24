using CleanArchitecture.Application.Commands.Categories;
using CleanArchitecture.Application.Commands.Stores;
using CleanArchitecture.Application.Mapper.Categories;
using CleanArchitecture.Application.Mapper.Stores;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Command;
using CleanArchitecture.Domain.Repositories.Query;
using MediatR;

namespace CleanArchitecture.Application.Handlers.CommandHandlers.Stores
{
    public class EditStoreHandler : IRequestHandler<EditStoreCommand, StoreResponse>
    {
        private readonly ICommandStoreRepository _storeCommandRepository;
        private readonly IStoreQueryRepository _storeQueryRepository;
        public EditStoreHandler(ICommandStoreRepository storeCommandRepository, IStoreQueryRepository storeQueryRepository)
        {
            _storeCommandRepository = storeCommandRepository;
            _storeQueryRepository = storeQueryRepository;
        }

        public async Task<StoreResponse> Handle(EditStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = StoreMapper.Mapper.Map<Store>(request);

            if (entity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _storeCommandRepository.UpdateAsync(entity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedStore = await _storeQueryRepository.GetByIdAsync(request.Id);
            var response = StoreMapper.Mapper.Map<StoreResponse>(modifiedStore);

            return response;
        }
    }
}
