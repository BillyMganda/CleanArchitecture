using CleanArchitecture.Application.Queries.Brands;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Handlers.QueryHandlers.Brands
{
    public class GetBrandByIdHandler : IRequestHandler<GetBrandByIdQuery, Brand>
    {
        private readonly IMediator _mediator;
        public GetBrandByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Brand> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brands = await _mediator.Send(new GetAllBrandQuery());
            var selectedBrand = brands.FirstOrDefault(x => x.Id == request.Id);
            return selectedBrand!;
        }
    }
}
