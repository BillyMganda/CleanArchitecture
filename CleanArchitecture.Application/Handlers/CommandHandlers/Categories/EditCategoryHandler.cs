using CleanArchitecture.Application.Commands.Brands;
using CleanArchitecture.Application.Commands.Categories;
using CleanArchitecture.Application.Mapper.Brands;
using CleanArchitecture.Application.Mapper.Categories;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Command;
using CleanArchitecture.Domain.Repositories.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handlers.CommandHandlers.Categories
{
    public class EditCategoryHandler : IRequestHandler<EditCategoryCommand, CategoryResponse>
    {
        private readonly ICommandCategoryRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        public EditCategoryHandler(ICommandCategoryRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
        }

        public async Task<CategoryResponse> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryEntity = CategoryMapper.Mapper.Map<Category>(request);

            if (categoryEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _categoryCommandRepository.UpdateAsync(categoryEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedCategory = await _categoryQueryRepository.GetByIdAsync(request.Id);
            var categoryResponse = CategoryMapper.Mapper.Map<CategoryResponse>(modifiedCategory);

            return categoryResponse;
        }
    }
}
