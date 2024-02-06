namespace FinancialTrackingApi.Model.Validators
{
    public class TransactionIdValidator : IdBaseValidator
    {
        public override async Task<List<ValidationError>> ValidateAsync<T>(string propertyName, T input)
        {
            var result = await ValidateIdAsync(Convert.ToInt32(input), propertyName);
            if (result.Any())
            {
                return result;
            }
            return result;
        }
    }
}
