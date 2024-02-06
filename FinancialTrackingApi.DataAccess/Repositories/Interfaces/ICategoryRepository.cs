using FinancialTrackingApi.DataAccess.Entities;

namespace FinancialTrackingApi.DataAccess.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryByName(string name);
    }
}
