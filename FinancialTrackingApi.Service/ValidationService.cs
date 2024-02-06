using FinancialTrackingApi.Model;
using FinancialTrackingApi.Model.Attributes;
using FinancialTrackingApi.Model.Interfaces;
using FinancialTrackingApi.Service.Interfaces;
using System.Reflection;

namespace FinancialTrackingApi.Service
{
    public class ValidationService : IValidationService
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<ValidationResultModel> ValidateModelAsync<T>(T model) where T : class
        {
            var validationResult = new ValidationResultModel();
            var validationTasks = new List<Task<List<ValidationError>>>();
            var properties = model.GetType().GetProperties();

            foreach (var property in properties)
            {
                var validationAttribute = property.GetCustomAttribute<ValidationAttribute>();

                if (validationAttribute != null)
                {
                    var validator = (IValidator)_serviceProvider.GetService(validationAttribute.ValidatorType);
                    var value = property.GetValue(model) as IConvertible;
                    var task = validator.ValidateAsync(property.Name, value);
                    validationTasks.Add(task);
                }
            }

            var results = await Task.WhenAll(validationTasks);
            foreach (var result in results)
            {
                validationResult.Errors.AddRange(result);
            }

            return validationResult;
        }
    }
}
