using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Application.Queries.Categories;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Moq;

namespace CleanArchitecture.Test
{
    public class CategoryControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly categoriesController _categoriesController;
        public CategoryControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _categoriesController = new categoriesController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Get_ReturnsListOfCategories()
        {
            // Arrange
            var expectedCategories = new List<Category> { new Category(), new Category() };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCategoryQuery>(), default)).ReturnsAsync(expectedCategories);

            // Act
            var result = await _categoriesController.Get();

            // Assert
            Assert.IsType<List<Category>>(result);
            Assert.Equal(expectedCategories.Count, result.Count);
            for (int i = 0; i < expectedCategories.Count; i++)
            {
                Assert.Equal(expectedCategories[i].Id, result[i].Id);
                Assert.Equal(expectedCategories[i].CategoryName, result[i].CategoryName);
                Assert.Equal(expectedCategories[i].CreatedDate, result[i].CreatedDate);
                Assert.Equal(expectedCategories[i].ModifiedDate, result[i].ModifiedDate);
            }
        }

        [Fact]
        public async Task Get_WithValidCategoryId_ReturnsCategory()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var expectedCategory = new Category { Id = categoryId, CategoryName = "Duis ac" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), default)).ReturnsAsync(expectedCategory);

            // Act
            var result = await _categoriesController.Get(categoryId);

            // Assert
            Assert.IsType<Category>(result);
            Assert.Equal(expectedCategory.Id, result.Id);
            Assert.Equal(expectedCategory.CategoryName, result.CategoryName);
        }
    }
}
