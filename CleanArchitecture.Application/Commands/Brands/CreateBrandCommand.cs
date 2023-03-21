using CleanArchitecture.Application.Response;
using MediatR;

namespace CleanArchitecture.Application.Commands.Brands
{
    public class CreateBrandCommand : IRequest<BrandResponse>
    {
        public string BrandName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public CreateBrandCommand()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}
