using FinancialTrackingApi.Model;

namespace FinancialTrackingApi.Service.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionModel?> CreateTransactionAsync(TransactionCreateModel model, int userId);
        Task<TransactionModel?> UpdateTransactionAsync(TransactionUpdateModel model, int userId);
    }
}
