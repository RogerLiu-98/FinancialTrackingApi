using FinancialTrackingApi.Model.Validators;
using Xunit;

namespace FinancialTrackingApi.UnitTests.Validators
{
    public class TransactionNameValidatorUnitTests
    {
        private readonly TransactionNameValidator _validator;

        public TransactionNameValidatorUnitTests()
        {
            _validator = new TransactionNameValidator();
        }

        [Fact]
        public async Task Test_TransactionName_Empty_Return_Error()
        {
            var result = await _validator.ValidateAsync("TransactionName", string.Empty);
            Assert.NotEmpty(result);
            Assert.Equal("TransactionName", result.First().PropertyName);
            Assert.Equal("TransactionName is required", result.First().ErrorMessage);
        }

        [Fact]
        public async Task Test_TransactionName_Valid_Return_No_Error()
        {
            var result = await _validator.ValidateAsync("TransactionName", "Test");
            Assert.Empty(result);
        }
    }
}
