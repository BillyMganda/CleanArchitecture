using CleanArchitecture.Application.Queries.Stores;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Query;
using MediatR;

namespace CleanArchitecture.Application.Handlers.QueryHandlers.Stores
{
    public class GetAllStoreHandler : IRequestHandler<GetAllStoreQuery, List<Store>>
    {
        private readonly IStoreQueryRepository _storeQueryRepository;
        public GetAllStoreHandler(IStoreQueryRepository storeQueryRepository)
        {
            _storeQueryRepository = storeQueryRepository;
        }

        public async Task<List<Store>> Handle(GetAllStoreQuery request, CancellationToken cancellationToken)
        {
            return (List<Store>)await _storeQueryRepository.GetAllAsync();
        }
    }
}
