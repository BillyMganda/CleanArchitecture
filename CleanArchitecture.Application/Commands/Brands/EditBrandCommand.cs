using CleanArchitecture.Application.Response;
using MediatR;

namespace CleanArchitecture.Application.Commands.Brands
{
    public class EditBrandCommand : IRequest<BrandResponse>
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
    }
}
