using CleanArchitecture.Application.Queries.Categories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Query;
using MediatR;

namespace CleanArchitecture.Application.Handlers.QueryHandlers.Categories
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, List<Category>>
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        public GetAllCategoryHandler(ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryQueryRepository = categoryQueryRepository;
        }

        public async Task<List<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return (List<Category>)await _categoryQueryRepository.GetAllAsync();
        }
    }
}
