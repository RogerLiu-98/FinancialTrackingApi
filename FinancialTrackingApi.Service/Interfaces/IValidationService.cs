using FinancialTrackingApi.Model;

namespace FinancialTrackingApi.Service.Interfaces
{
    public interface IValidationService
    {
        Task<ValidationResultModel> ValidateModelAsync<T>(T model) where T : class;
    }
}
