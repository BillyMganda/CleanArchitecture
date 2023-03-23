using CleanArchitecture.Application.Commands.Categories;
using CleanArchitecture.Application.Mapper.Categories;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Command;
using MediatR;

namespace CleanArchitecture.Application.Handlers.CommandHandlers.Categories
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryResponse>
    {
        private readonly ICommandCategoryRepository _categoryCommandRepository;
        public CreateCategoryHandler(ICommandCategoryRepository categoryCommandRepository)
        {
            _categoryCommandRepository = categoryCommandRepository;
        }

        public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryEntity = CategoryMapper.Mapper.Map<Category>(request);

            if (categoryEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newCategory = await _categoryCommandRepository.AddAsync(categoryEntity);
            var categoryResponse = CategoryMapper.Mapper.Map<CategoryResponse>(newCategory);
            return categoryResponse;
        }
    }
}
