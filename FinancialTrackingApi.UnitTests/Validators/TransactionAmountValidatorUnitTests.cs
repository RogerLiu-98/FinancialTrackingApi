using FinancialTrackingApi.Model.Validators;
using Xunit;

namespace FinancialTrackingApi.UnitTests.Validators
{
    public class TransactionAmountValidatorUnitTests
    {
        private readonly TransactionAmountValidator _validator;

        public TransactionAmountValidatorUnitTests()
        {
            _validator = new TransactionAmountValidator();
        }

        [Fact]
        public async Task Test_TransactionAmount_LessThanZero_Return_Error()
        {
            var result = await _validator.ValidateAsync("Transaction Amount", -1.0m);
            Assert.NotEmpty(result);
            Assert.Equal("Transaction Amount", result.First().PropertyName);
            Assert.Equal("Transaction Amount must be greater than 0", result.First().ErrorMessage);
        }

        [Fact]
        public async Task Test_TransactionAmount_Valid_Return_NoError()
        {
            var result = await _validator.ValidateAsync("Transaction Amount", 1.0m);
            Assert.Empty(result);
        }
    }
}
