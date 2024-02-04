namespace FinancialTrackingApi.DataAccess.Entities
{
    public class Category
    {
        public Category()
        {
            IsActive = true;
        }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
