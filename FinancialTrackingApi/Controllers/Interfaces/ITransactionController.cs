using FinancialTrackingApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackingApi.Controllers.Interfaces
{
    public interface ITransactionController
    {
        Task<ActionResult<TransactionModel>> CreateTransaction(TransactionCreateModel transaction);
        Task<ActionResult<TransactionModel>> UpdateTransaction(TransactionUpdateModel transaction);
    }
}
