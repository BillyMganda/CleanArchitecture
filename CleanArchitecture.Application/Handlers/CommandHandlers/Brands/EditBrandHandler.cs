using CleanArchitecture.Application.Commands.Brands;
using CleanArchitecture.Application.Mapper.Brands;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.Command;
using CleanArchitecture.Domain.Repositories.Query;
using MediatR;

namespace CleanArchitecture.Application.Handlers.CommandHandlers.Brands
{
    public class EditBrandHandler : IRequestHandler<EditBrandCommand, BrandResponse>
    {
        private readonly ICommandBrandRepository _brandCommandRepository;
        private readonly IBrandQueryRepository _brandQueryRepository;
        public EditBrandHandler(ICommandBrandRepository brandCommandRepository, IBrandQueryRepository brandQueryRepository)
        {
            _brandCommandRepository = brandCommandRepository;
            _brandQueryRepository = brandQueryRepository;
        }

        public async Task<BrandResponse> Handle(EditBrandCommand request, CancellationToken cancellationToken)
        {
            var brandEntity = BrandMapper.Mapper.Map<Brand>(request);

            if (brandEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _brandCommandRepository.UpdateAsync(brandEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedBrand = await _brandQueryRepository.GetByIdAsync(request.Id);
            var brandResponse = BrandMapper.Mapper.Map<BrandResponse>(modifiedBrand);

            return brandResponse;
        }
    }
}
