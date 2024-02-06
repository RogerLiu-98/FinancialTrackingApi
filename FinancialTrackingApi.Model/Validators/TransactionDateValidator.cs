namespace FinancialTrackingApi.Model.Validators
{
    public class TransactionDateValidator : DateTimeBaseValidator
    {
        public override async Task<List<ValidationError>> ValidateAsync<T>(string propertyName, T input)
        {
            var result = await ValidateDateTimeAsync(Convert.ToDateTime(input), propertyName);
            if (result.Any())
            {
                return result;
            }
            return result;
        }
    }
}
