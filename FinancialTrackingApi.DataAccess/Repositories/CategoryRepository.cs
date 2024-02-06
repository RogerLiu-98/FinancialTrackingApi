using FinancialTrackingApi.DataAccess.Contexts;
using FinancialTrackingApi.DataAccess.Entities;
using FinancialTrackingApi.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrackingApi.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FinancialTrackerContext _context;

        public CategoryRepository(FinancialTrackerContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.Where(c => c.IsActive).ToListAsync();
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.IsActive &&
                c.Name.ToUpper() == name.ToUpper());
            if (category == null)
            {
                throw new KeyNotFoundException($"Category not found for Name: {name}");
            }
            return category;
        }
    }
}
