using FinancialTrackingApi.Model.Validators;
using Xunit;

namespace FinancialTrackingApi.UnitTests.Validators
{
    public class TransactionIdValidatorUnitTests
    {
        private readonly TransactionIdValidator _validator;

        public TransactionIdValidatorUnitTests()
        {
            _validator = new TransactionIdValidator();
        }

        [Fact]
        public async Task Test_TransactionId_Invalid_Id_Return_Error()
        {
            var result = await _validator.ValidateAsync("TransactionId", -1);
            Assert.NotEmpty(result);
            Assert.Equal("TransactionId", result.First().PropertyName);
            Assert.Equal("TransactionId must be greater than 0", result.First().ErrorMessage);
        }

        [Fact]
        public async Task Test_TransactionId_Valid_Id_Return_No_Error()
        {
            var result = await _validator.ValidateAsync("TransactionId", 1);
            Assert.Empty(result);
        }
    }
}
