using CleanArchitecture.Application.Queries.Categories;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Handlers.QueryHandlers.Categories
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly IMediator _mediator;
        public GetCategoryByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var categories = await _mediator.Send(new GetAllCategoryQuery());
            var selectedCategory = categories.FirstOrDefault(x => x.Id == request.Id);
            return selectedCategory!;
        }
    }
}
