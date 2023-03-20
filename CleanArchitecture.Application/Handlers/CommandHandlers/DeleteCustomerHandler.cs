using CleanArchitecture.Application.Commands;
using CleanArchitecture.Domain.Repositories.Query;
using MediatR;

namespace CleanArchitecture.Application.Handlers.CommandHandlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, string>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;
        public DeleteCustomerHandler(ICustomerCommandRepository customerRepository, ICustomerQueryRepository customerQueryRepository)
        {
            _customerCommandRepository = customerRepository;
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customerEntity = await _customerQueryRepository.GetByIdAsync(request.Id);

                await _customerCommandRepository.DeleteAsync(customerEntity);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Customer information has been deleted!";
        }
    }
}
