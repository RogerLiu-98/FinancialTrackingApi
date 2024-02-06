using FinancialTrackingApi.Model.Interfaces;

namespace FinancialTrackingApi.Model.Validators
{
    public abstract class IdBaseValidator : IValidator
    {
        protected virtual Task<List<ValidationError>> ValidateIdAsync(int input, string propertyName)
        {
            List<ValidationError> result = new List<ValidationError>();
            if (input <= 0)
            {
                result.Add(new ValidationError
                {
                    PropertyName = propertyName,
                    ErrorMessage = $"{propertyName} must be greater than 0"
                });
            }
            return Task.FromResult(result);
        }

        public abstract Task<List<ValidationError>> ValidateAsync<T>(string propertyName, T input) where T : IConvertible;
    }
}
