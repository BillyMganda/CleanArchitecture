using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [Fact]
        public async Task GetByEmail_WithValidEmail_ReturnsCustomer()
        {
            // Arrange
            var customerEmail = "john.doe@example.com";
            var expectedCustomer = new Customer { Id = Guid.NewGuid(), Email = customerEmail, FirstName = "John" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCustomerByEmailQuery>(), default)).ReturnsAsync(expectedCustomer);

            // Act
            var result = await _customerController.GetByEmail(customerEmail);

            // Assert
            Assert.IsType<Customer>(result);
            Assert.Equal(expectedCustomer.Id, result.Id);
            Assert.Equal(expectedCustomer.Email, result.Email);
            Assert.Equal(expectedCustomer.FirstName, result.FirstName);
        }

        [Fact]
        public async Task CreateCustomer_WithValidCommand_ReturnsCustomerResponse()
        {
            // Arrange
            var command = new CreateCustomerCommand { FirstName = "John", Email = "john@example.com" };
            var expectedResponse = new CustomerResponse { Id = Guid.NewGuid(), FirstName = command.FirstName, Email = command.Email };
            _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _customerController.CreateCustomer(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<CustomerResponse>(okResult.Value);
            Assert.Equal(expectedResponse.Id, response.Id);
            Assert.Equal(expectedResponse.FirstName, response.FirstName);
            Assert.Equal(expectedResponse.Email, response.Email);
        }

        [Fact]
        public async Task EditCustomer_WithValidCommand_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var command = new EditCustomerCommand { Id = id, FirstName = "John", Email = "john@example.com" };
            var expectedCustomerResponse = new CustomerResponse { Id = id, FirstName = "John Smith", Email = "john.smith@example.com" };

            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(expectedCustomerResponse);

            // Act
            var result = await _customerController.EditCustomer(id, command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var customerResponse = Assert.IsType<CustomerResponse>(okResult.Value);
            Assert.Equal(expectedCustomerResponse.Id, customerResponse.Id);
            Assert.Equal(expectedCustomerResponse.FirstName, customerResponse.FirstName);
            Assert.Equal(expectedCustomerResponse.Email, customerResponse.Email);
        }

        [Fact]
        public async Task DeleteCustomer_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedCustomerResponse = "Customer information has been deleted!";
            _mediatorMock.Setup(x => x.Send(It.IsAny<DeleteCustomerCommand>(), default)).ReturnsAsync(expectedCustomerResponse);

            // Act
            var result = await _customerController.DeleteCustomer(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedCustomerResponse, okResult.Value);
        }
    }
}
