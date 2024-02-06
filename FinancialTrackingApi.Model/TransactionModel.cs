namespace FinancialTrackingApi.Model
{
    public class TransactionModel
    {
        public int TransactionId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }
    }
}
