using FinancialTrackingApi.DataAccess.Contexts;
using FinancialTrackingApi.DataAccess.Entities;
using FinancialTrackingApi.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrackingApi.DataAccess.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FinancialTrackerContext _context;

        public TransactionRepository(FinancialTrackerContext context)
        {
            _context = context;
        }

        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task DeleteTransactionAsync(int transactionId)
        {
            var transaction = await _context.Transactions.SingleOrDefaultAsync(t => t.TransactionId == transactionId && !t.IsDeleted);
            if (transaction == null)
            {
                throw new KeyNotFoundException($"Transaction not found When Trying to Delete Transaction: {transactionId}");
            }
            transaction.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Transaction> GetTransactionByIdAsync(int transactionId)
        {
            var transaction = await _context.Transactions.Include(t => t.Category).SingleOrDefaultAsync(t => t.TransactionId == transactionId && !t.IsDeleted);
            if (transaction == null)
            {
                throw new KeyNotFoundException($"Transaction not found for TransactionId: {transactionId}");
            }
            return transaction;
        }

        public async Task<List<Transaction>> GetTransactionsByUserIdAsync(int userId)
        {
            var transactions = await _context.Transactions.Include(t => t.Category).AsNoTracking().Where(t => t.UserId == userId && !t.IsDeleted).ToListAsync();
            if (transactions == null || !transactions.Any())
            {
                throw new KeyNotFoundException($"Transactions not found for UserId: {userId}");
            }
            return transactions;
        }

        public async Task<Transaction> UpdateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}
