using FinancialTrackingApi.DataAccess.Entities;

namespace FinancialTrackingApi.DataAccess.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(int transactionId);
        Task<List<Transaction>> GetTransactionsByUserIdAsync(int userId);
        Task<Transaction> UpdateTransactionAsync(Transaction transaction);
        Task DeleteTransactionAsync(int transactionId);
    }
}
