using CleanArchitecture.Application.Queries.Stores;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Handlers.QueryHandlers.Stores
{
    public class GetStoreByIdHandler : IRequestHandler<GetStoreByIdQuery, Store>
    {
        private readonly IMediator _mediator;
        public GetStoreByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Store> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var stores = await _mediator.Send(new GetAllStoreQuery());
            var selectedStore = stores.FirstOrDefault(x => x.Id == request.Id);
            return selectedStore!;
        }
    }
}
