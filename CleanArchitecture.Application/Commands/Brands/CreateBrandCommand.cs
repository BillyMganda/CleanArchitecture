using CleanArchitecture.Application.Response;
using MediatR;

namespace CleanArchitecture.Application.Commands.Brands
{
    public class CreateBrandCommand : IRequest<BrandResponse>
    {
        public string BrandName { get; set; }
        public DateTime CreatedDate { get; set; }
        public CreateBrandCommand()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
