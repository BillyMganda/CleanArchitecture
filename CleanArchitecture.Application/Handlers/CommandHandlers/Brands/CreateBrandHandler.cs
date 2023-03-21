using CleanArchitecture.Application.Commands.Brands;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Application.Mapper.Brands;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Command;
using MediatR;

namespace CleanArchitecture.Application.Handlers.CommandHandlers.Brands
{
    public class CreateBrandHandler : IRequestHandler<CreateBrandCommand, BrandResponse>
    {
        private readonly ICommandBrandRepository _brandCommandRepository;
        public CreateBrandHandler(ICommandBrandRepository brandCommandRepository)
        {
            _brandCommandRepository = brandCommandRepository;
        }

        public async Task<BrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brandEntity = BrandMapper.Mapper.Map<Brand>(request);

            if (brandEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newBrand = await _brandCommandRepository.AddAsync(brandEntity);
            var brandResponse = BrandMapper.Mapper.Map<BrandResponse>(newBrand);
            return brandResponse;
        }
    }
}
