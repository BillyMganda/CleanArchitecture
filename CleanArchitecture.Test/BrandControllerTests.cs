using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.Commands.Brands;
using CleanArchitecture.Application.Commands.Categories;
using CleanArchitecture.Application.Queries.Brands;
using CleanArchitecture.Application.Queries.Categories;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitecture.Test
{
    public class BrandControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly brandsController _brandsController;
        public BrandControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _brandsController = new brandsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Get_ReturnsListOfbrands()
        {
            // Arrange
            var expectedResults = new List<Brand> { new Brand(), new Brand() };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllBrandQuery>(), default)).ReturnsAsync(expectedResults);

            // Act
            var result = await _brandsController.Get();

            // Assert
            Assert.IsType<List<Brand>>(result);
            Assert.Equal(expectedResults.Count, result.Count);
            for (int i = 0; i < expectedResults.Count; i++)
            {
                Assert.Equal(expectedResults[i].Id, result[i].Id);
                Assert.Equal(expectedResults[i].BrandName, result[i].BrandName);
                Assert.Equal(expectedResults[i].CreatedDate, result[i].CreatedDate);
                Assert.Equal(expectedResults[i].ModifiedDate, result[i].ModifiedDate);
            }
        }

        [Fact]
        public async Task Get_WithValidBrandId_ReturnsBrand()
        {
            // Arrange
            var brandId = Guid.NewGuid();
            var expectedResults = new Brand { Id = brandId, BrandName = "Duis ac" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBrandByIdQuery>(), default)).ReturnsAsync(expectedResults);

            // Act
            var result = await _brandsController.Get(brandId);

            // Assert
            Assert.IsType<Brand>(result);
            Assert.Equal(expectedResults.Id, result.Id);
            Assert.Equal(expectedResults.BrandName, result.BrandName);
        }

        [Fact]
        public async Task CreateBrand_WithValidCommand_ReturnsBrandResponse()
        {
            // Arrange
            var command = new CreateBrandCommand { BrandName = "Test Brand" };
            var expectedResponse = new BrandResponse { Id = Guid.NewGuid(), BrandName = command.BrandName };
            _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _brandsController.CreateBrand(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<BrandResponse>(okResult.Value);
            Assert.Equal(expectedResponse.Id, response.Id);
            Assert.Equal(expectedResponse.BrandName, response.BrandName);
        }

        [Fact]
        public async Task EditBrand_WithValidCommand_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var command = new EditBrandCommand { Id = id, BrandName = "Test Brand" };
            var expectedResponse = new BrandResponse { Id = id, BrandName = "John Smith" };

            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _brandsController.EditBrand(id, command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<BrandResponse > (okResult.Value);
            Assert.Equal(response.Id, expectedResponse.Id);
            Assert.Equal(response.BrandName, expectedResponse.BrandName);
        }
    }
}
