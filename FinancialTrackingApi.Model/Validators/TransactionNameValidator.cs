namespace FinancialTrackingApi.Model.Validators
{
    public class TransactionNameValidator : StringBaseValidator
    {
        public override async Task<List<ValidationError>> ValidateAsync<T>(string propertyName, T input)
        {
            var result = await ValidateStringAsync(Convert.ToString(input), propertyName);
            if (result.Any())
            {
                return result;
            }
            return result;
        }
    }
}
