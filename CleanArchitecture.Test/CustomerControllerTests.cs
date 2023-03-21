using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Moq;

namespace CleanArchitecture.Test
{
    public class CustomerControllerTests
    {
        [Fact]
        public async Task Get_ReturnsListOfCustomers()
        {
            // Arrange
            var expectedCustomers = new List<Customer> { new Customer(), new Customer() };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(x => x.Send(It.IsAny<GetAllCustomerQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedCustomers);

            var controller = new customersController(mediatorMock.Object);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.IsType<List<Customer>>(result);
            Assert.Equal(expectedCustomers, result);
        }
    }
}
