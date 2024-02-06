using FinancialTrackingApi.Model.Validators;
using Xunit;

namespace FinancialTrackingApi.UnitTests.Validators
{
    public class TransactionDateValidatorUnitTests
    {
        private readonly TransactionDateValidator _validator;

        public TransactionDateValidatorUnitTests()
        {
            _validator = new TransactionDateValidator();
        }

        [Fact]
        public async Task Test_TransactionDate_MinDate_Return_Error()
        {
            var result = await _validator.ValidateAsync("TransactionDate", DateTime.MinValue);
            Assert.NotEmpty(result);
            Assert.Equal("TransactionDate", result.First().PropertyName);
            Assert.Equal("TransactionDate is required", result.First().ErrorMessage);
        }

        [Fact]
        public async Task Test_TransactionDate_FutureDate_Return_Error()
        {
            var result = await _validator.ValidateAsync("TransactionDate", DateTime.Now.AddDays(1));
            Assert.NotEmpty(result);
            Assert.Equal("TransactionDate", result.First().PropertyName);
            Assert.Equal("TransactionDate cannot be in the future", result.First().ErrorMessage);
        }
    }
}
