using CleanArchitecture.Application.Commands.Brands;
using CleanArchitecture.Application.Commands.Categories;
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
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, string>
    {
        private readonly ICommandCategoryRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        public DeleteCategoryHandler(ICommandCategoryRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
        }

        public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoryEntity = await _categoryQueryRepository.GetByIdAsync(request.Id);

                await _categoryCommandRepository.DeleteAsync(categoryEntity);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Category information has been deleted!";
        }
    }
}
