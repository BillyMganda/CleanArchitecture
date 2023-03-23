using CleanArchitecture.Application.Response;
using MediatR;

namespace CleanArchitecture.Application.Commands.Categories
{
    public class CreateCategoryCommand : IRequest<CategoryResponse>
    {
        public string CategoryName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public CreateCategoryCommand()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}
