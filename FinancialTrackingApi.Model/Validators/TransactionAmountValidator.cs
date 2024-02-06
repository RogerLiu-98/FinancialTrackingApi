namespace FinancialTrackingApi.Model.Validators
{
    public class TransactionAmountValidator : DecimalBaseValidator
    {
        public override async Task<List<ValidationError>> ValidateAsync<T>(string propertyName, T input)
        {
            var result = await ValidateDecimalAsync(Convert.ToDecimal(input), propertyName);
            if (result.Any())
            {
                return result;
            }
            return result;
        }
    }
}
