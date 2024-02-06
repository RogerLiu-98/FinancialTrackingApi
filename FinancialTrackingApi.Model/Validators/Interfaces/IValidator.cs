namespace FinancialTrackingApi.Model.Interfaces
{
    public interface IValidator
    {
        Task<List<ValidationError>> ValidateAsync<T>(string propertyName, T input) where T : IConvertible;
    }
}
