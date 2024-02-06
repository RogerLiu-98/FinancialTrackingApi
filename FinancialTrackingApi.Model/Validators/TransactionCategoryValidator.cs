using FinancialTrackingApi.DataAccess.Repositories.Interfaces;

namespace FinancialTrackingApi.Model.Validators
{
    public class TransactionCategoryValidator : StringBaseValidator
    {
        private readonly ICategoryRepository _categoryRepository;

        public TransactionCategoryValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public override async Task<List<ValidationError>> ValidateAsync<T>(string propertyName, T input)
        {
            var result = await ValidateStringAsync(Convert.ToString(input), propertyName);
            if (result.Any())
            {
                return result;
            }
            var categories = await _categoryRepository.GetAllCategories();
            if (!categories.Any(c => c.Name.ToUpper() == input.ToString().ToUpper()))
            {
                result.Add(new ValidationError
                {
                    PropertyName = propertyName,
                    ErrorMessage = "Category does not exist"
                });
            }
            return result;
        }
    }
}
