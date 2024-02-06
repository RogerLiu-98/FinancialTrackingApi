using FinancialTrackingApi.Model.Interfaces;

namespace FinancialTrackingApi.Model.Validators
{
    public abstract class DateTimeBaseValidator : IValidator
    {
        protected virtual Task<List<ValidationError>> ValidateDateTimeAsync(DateTime input, string propertyName)
        {
            List<ValidationError> result = new List<ValidationError>();
            if (input == DateTime.MinValue)
            {
                result.Add(new ValidationError
                {
                    PropertyName = propertyName,
                    ErrorMessage = $"{propertyName} is required"
                });
            }
            if (input > DateTime.Now)
            {
                result.Add(new ValidationError
                {
                    PropertyName = propertyName,
                    ErrorMessage = $"{propertyName} cannot be in the future"
                });
            }
            return Task.FromResult(result);
        }
        public abstract Task<List<ValidationError>> ValidateAsync<T>(string propertyName, T input) where T : IConvertible;
    }
}
