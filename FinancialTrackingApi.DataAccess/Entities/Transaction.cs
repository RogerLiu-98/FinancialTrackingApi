namespace FinancialTrackingApi.DataAccess.Entities
{
    public class Transaction : Entity
    {
        public int TransactionId { get; set; }

        public int UserId { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public int CategoryId { get; set; }

        public string? Description { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Category Category { get; set; }
    }
}
