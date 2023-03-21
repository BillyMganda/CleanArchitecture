using CleanArchitecture.Application.Commands.Brands;
using CleanArchitecture.Domain.Repositories.Command;
using CleanArchitecture.Domain.Repositories.Query;
using MediatR;

namespace CleanArchitecture.Application.Handlers.CommandHandlers.Brands
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand, string>
    {
        private readonly ICommandBrandRepository _brandCommandRepository;
        private readonly IBrandQueryRepository _brandQueryRepository;
        public DeleteBrandHandler(ICommandBrandRepository brandCommandRepository, IBrandQueryRepository brandQueryRepository)
        {
            _brandCommandRepository = brandCommandRepository;
            _brandQueryRepository = brandQueryRepository;
        }

        public async Task<string> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var brandEntity = await _brandQueryRepository.GetByIdAsync(request.Id);

                await _brandCommandRepository.DeleteAsync(brandEntity);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Brand information has been deleted!";
        }
    }
}
