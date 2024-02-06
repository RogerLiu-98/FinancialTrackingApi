using FinancialTrackingApi.DataAccess.Entities;
using FinancialTrackingApi.DataAccess.Repositories.Interfaces;
using FinancialTrackingApi.Model.Validators;
using Moq;
using Xunit;

namespace FinancialTrackingApi.UnitTests.Validators
{
    public class TransactionCategoryValidatorUnitTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;

        private readonly TransactionCategoryValidator _validator;
        public TransactionCategoryValidatorUnitTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();

            _validator = new TransactionCategoryValidator(_categoryRepositoryMock.Object);
        }

        [Fact]
        public async Task Test_TransactionCategoryValidator_Empty_Return_Error()
        {
            var result = await _validator.ValidateAsync("Category", string.Empty);
            Assert.NotEmpty(result);
            Assert.Equal("Category", result.First().PropertyName);
            Assert.Equal("Category is required", result.First().ErrorMessage);
        }

        [Fact]
        public async Task Test_TransactionCategoryValidator_Invalid_Category_Return_Error()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    CategoryId = 1,
                    Name = "Housing",
                    Description = "Housing Expenses"
                }
            };

            _categoryRepositoryMock.Setup(s => s.GetAllCategories()).ReturnsAsync(categories);

            var result = await _validator.ValidateAsync("Category", "Invalid Category");

            Assert.NotEmpty(result);
            Assert.Equal("Category", result.First().PropertyName);
            Assert.Equal("Category Invalid Category does not exist", result.First().ErrorMessage);
        }

        [Fact]
        public async Task Test_TransactionCategoryValidator_Valid_Return_No_Error()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    CategoryId = 1,
                    Name = "Housing",
                    Description = "Housing Expenses"
                }
            };

            _categoryRepositoryMock.Setup(s => s.GetAllCategories()).ReturnsAsync(categories);

            var result = await _validator.ValidateAsync("Category", "Housing");

            Assert.Empty(result);
        }
    }
}
