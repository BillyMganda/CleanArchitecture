using CleanArchitecture.Application.Queries.Brands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Query;
using MediatR;

namespace CleanArchitecture.Application.Handlers.QueryHandlers.Brands
{
    public class GetAllBrandHandler : IRequestHandler<GetAllBrandQuery, List<Brand>>
    {
        private readonly IBrandQueryRepository _brandQueryRepository;
        public GetAllBrandHandler(IBrandQueryRepository brandQueryRepository)
        {
            _brandQueryRepository = brandQueryRepository;
        }

        public async Task<List<Brand>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            return (List<Brand>)await _brandQueryRepository.GetAllAsync();
        }
    }
}
