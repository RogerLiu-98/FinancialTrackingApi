using AutoMapper;
using FinancialTrackingApi.DataAccess.Entities;
using FinancialTrackingApi.DataAccess.Repositories.Interfaces;
using FinancialTrackingApi.Model;
using FinancialTrackingApi.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace FinancialTrackingApi.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ILogger<TransactionService> _logger;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public TransactionService(ILogger<TransactionService> logger, ITransactionRepository transactionRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _logger = logger;
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<TransactionModel?> CreateTransactionAsync(TransactionCreateModel model, int userId)
        {
            _logger.LogInformation($"Creating transaction for user: {userId}");
            TransactionModel? transactionModel = null;
            try
            {
                var category = await _categoryRepository.GetCategoryByName(model.Category);
                var transaction = new Transaction()
                {
                    UserId = userId,
                    Name = model.Name,
                    CategoryId = category.CategoryId,
                    Amount = model.Amount,
                    Description = model.Description,
                    TransactionDate = model.Date
                };
                var createdTransaction = await _transactionRepository.CreateTransactionAsync(transaction);
                transactionModel = _mapper.Map<TransactionModel>(createdTransaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

            return transactionModel;
        }

        public async Task<TransactionModel?> UpdateTransactionAsync(TransactionUpdateModel model, int userId)
        {
            _logger.LogInformation($"Updating transaction for user: {userId}");
            TransactionModel? transactionModel = null;
            try
            {
                var category = await _categoryRepository.GetCategoryByName(model.Category);
                var transaction = new Transaction()
                {
                    UserId = userId,
                    Name = model.Name,
                    CategoryId = category.CategoryId,
                    Amount = model.Amount,
                    Description = model.Description,
                    TransactionDate = model.Date
                };
                var updatedTransaction = await _transactionRepository.UpdateTransactionAsync(transaction);
                transactionModel = _mapper.Map<TransactionModel>(updatedTransaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return transactionModel;
        }
    }
}
