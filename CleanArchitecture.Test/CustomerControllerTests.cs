using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Moq;

namespace CleanArchitecture.Test
{
    public class CustomerControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly customersController _customerController;
        public CustomerControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _customerController = new customersController(_mediatorMock.Object);
        }
        [Fact]
        public async Task Get_ReturnsListOfCustomers()
        {
            // Arrange
            var expectedCustomers = new List<Customer> { new Customer(), new Customer() };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCustomerQuery>(), default)).ReturnsAsync(expectedCustomers);

            // Act
            var result = await _customerController.Get();

            // Assert
            Assert.IsType<List<Customer>>(result);
            Assert.Equal(expectedCustomers.Count, result.Count);
            for (int i = 0; i < expectedCustomers.Count; i++)
            {
                Assert.Equal(expectedCustomers[i].Id, result[i].Id);
                Assert.Equal(expectedCustomers[i].FirstName, result[i].FirstName);
                Assert.Equal(expectedCustomers[i].LastName, result[i].LastName);
            }
        }

        [Fact]
        public async Task Get_WithValidCustomerId_ReturnsCustomer()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var expectedCustomer = new Customer { Id = customerId, FirstName = "John" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCustomerByIdQuery>(), default)).ReturnsAsync(expectedCustomer);

            // Act
            var result = await _customerController.Get(customerId);

            // Assert
            Assert.IsType<Customer>(result);
            Assert.Equal(expectedCustomer.Id, result.Id);
            Assert.Equal(expectedCustomer.FirstName, result.FirstName);
        }
    }
}
