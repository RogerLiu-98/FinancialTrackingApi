namespace FinancialTrackingApi.DataAccess.Entities
{
    public class Entity
    {
        public Entity()
        {
            IsDeleted = false;
        }

        public bool IsDeleted { get; set; }

        public DateTime CreatedTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }

        public int UpdatedBy { get; set; }
    }
}
