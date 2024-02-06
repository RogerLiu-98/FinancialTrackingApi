using AutoMapper;
using FinancialTrackingApi.DataAccess.Entities;
using FinancialTrackingApi.DataAccess.Repositories.Interfaces;
using FinancialTrackingApi.Model;
using FinancialTrackingApi.Model.MappingProfiles;
using FinancialTrackingApi.Service;
using FinancialTrackingApi.Service.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Service.Tests
{
    public class TransactionServiceUnitTests
    {
        private readonly Mock<ILogger<TransactionService>> _loggerMock;
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;
        private readonly IMapper _mapper;

        private readonly ITransactionService _transactionService;
        public TransactionServiceUnitTests()
        {
            _loggerMock = new Mock<ILogger<TransactionService>>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<TransactionMappingProfile>()).CreateMapper();

            _transactionService = new TransactionService(_loggerMock.Object, _transactionRepositoryMock.Object, _categoryRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task Test_CreateTransactionAsync_Succeed_Return_TransactionModel()
        {
            TransactionCreateModel model = new TransactionCreateModel()
            {
                Name = "Test",
                Category = "Housing",
                Amount = 100.45m,
                Description = "Test",
                Date = new DateTime(2022, 12, 22)
            };

            _categoryRepositoryMock.Setup(x => x.GetCategoryByName(It.IsAny<string>())).ReturnsAsync(new Category()
            {
                CategoryId = 1,
                Name = "Housing",
                Description = "Housing expenses"
            });

            _transactionRepositoryMock.Setup(x => x.CreateTransactionAsync(It.IsAny<Transaction>())).ReturnsAsync(new Transaction()
            {
                TransactionId = 1,
                UserId = 1,
                Name = "Test",
                CategoryId = 1,
                Amount = 100.45m,
                Description = "Test",
                TransactionDate = new DateTime(2022, 12, 22)
            });

            var result = await _transactionService.CreateTransactionAsync(model, 1);

            Assert.NotNull(result);
            Assert.Equal(1, result.TransactionId);
        }

        [Fact]
        public async Task Test_UpdateTransactionAsync_Succeed_Return_TransactionModel()
        {
            TransactionUpdateModel model = new TransactionUpdateModel()
            {
                TransactionId = 1,
                Name = "Test",
                Category = "Housing",
                Amount = 100.45m,
                Description = "Test"
            };

            _categoryRepositoryMock.Setup(x => x.GetCategoryByName(It.IsAny<string>())).ReturnsAsync(new Category()
            {
                CategoryId = 1,
                Name = "Housing",
                Description = "Housing expenses"
            });

            _transactionRepositoryMock.Setup(x => x.UpdateTransactionAsync(It.IsAny<Transaction>())).ReturnsAsync(new Transaction()
            {
                TransactionId = 1,
                UserId = 1,
                Name = "Test",
                CategoryId = 1,
                Amount = 100.45m,
                Description = "Test",
                TransactionDate = new DateTime(2022, 12, 22)
            });

            var result = await _transactionService.UpdateTransactionAsync(model, 1);

            Assert.NotNull(result);
            Assert.Equal(model.TransactionId, result.TransactionId);
        }
    }
}
