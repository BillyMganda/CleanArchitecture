using CleanArchitecture.Application.Response;
using MediatR;

namespace CleanArchitecture.Application.Commands.Categories
{
    public class EditCategoryCommand : IRequest<CategoryResponse>
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
