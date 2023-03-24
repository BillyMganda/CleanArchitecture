using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.Queries.Brands;
using CleanArchitecture.Application.Queries.Categories;
using CleanArchitecture.Domain.Entities;
using MediatR;
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
    }
}
