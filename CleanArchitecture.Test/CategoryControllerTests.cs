using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.Commands.Categories;
using CleanArchitecture.Application.Queries.Categories;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [Fact]
        public async Task CreateCategory_WithValidCommand_ReturnsCategoryResponse()
        {
            // Arrange
            var command = new CreateCategoryCommand { CategoryName = "Duis ac"};
            var expectedResponse = new CategoryResponse { Id = Guid.NewGuid(), CategoryName = command.CategoryName};
            _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _categoriesController.CreateCategory(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<CategoryResponse>(okResult.Value);
            Assert.Equal(expectedResponse.Id, response.Id);
            Assert.Equal(expectedResponse.CategoryName, response.CategoryName);            
        }

        [Fact]
        public async Task EditCategory_WithValidCommand_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var command = new EditCategoryCommand { Id = id, CategoryName = "Duis ac"};
            var expectedCategoryResponse = new CategoryResponse { Id = id, CategoryName = "John Smith"};

            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(expectedCategoryResponse);

            // Act
            var result = await _categoriesController.EditCategory(id, command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var categoryResponse = Assert.IsType<CategoryResponse>(okResult.Value);
            Assert.Equal(categoryResponse.Id, categoryResponse.Id);
            Assert.Equal(categoryResponse.CategoryName, categoryResponse.CategoryName);            
        }

        [Fact]
        public async Task DeleteCategory_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedCategoryResponse = "Category information has been deleted!";
            _mediatorMock.Setup(x => x.Send(It.IsAny<DeleteCategoryCommand>(), default)).ReturnsAsync(expectedCategoryResponse);

            // Act
            var result = await _categoriesController.DeleteCategory(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedCategoryResponse, okResult.Value);
        }
    }
}
