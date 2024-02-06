using FinancialTrackingApi.Model.Interfaces;

namespace FinancialTrackingApi.Model.Validators
{
    public abstract class StringBaseValidator : IValidator
    {
        protected virtual Task<List<ValidationError>> ValidateStringAsync(string input, string propertyName)
        {
            List<ValidationError> result = new List<ValidationError>();
            if (string.IsNullOrWhiteSpace(input))
            {
                result.Add(new ValidationError
                {
                    PropertyName = propertyName,
                    ErrorMessage = $"{propertyName} is required"
                });
            }
            return Task.FromResult(result);
        }

        public abstract Task<List<ValidationError>> ValidateAsync<T>(string propertyName, T input) where T : IConvertible;
    }
}
