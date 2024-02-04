using Microsoft.AspNetCore.Identity;

namespace FinancialTrackingApi.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
