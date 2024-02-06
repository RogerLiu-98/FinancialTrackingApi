using FinancialTrackingApi.Model.Attributes;
using FinancialTrackingApi.Model.Validators;

namespace FinancialTrackingApi.Model
{
    public class TransactionUpdateModel
    {
        [Validation(typeof(TransactionIdValidator))]
        public int TransactionId { get; set; }
        [Validation(typeof(TransactionNameValidator))]
        public string Name { get; set; }
        [Validation(typeof(TransactionAmountValidator))]
        public decimal Amount { get; set; }
        [Validation(typeof(TransactionDateValidator))]
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        [Validation(typeof(TransactionCategoryValidator))]
        public string Category { get; set; }
    }
}
