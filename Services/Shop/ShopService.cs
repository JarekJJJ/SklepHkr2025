using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SklepHkr2025.Data;
using SklepHkr2025.Model.Shop;

namespace SklepHkr2025.Services.Shop
{
    public class ShopService : IShopService
    {
        private readonly ApplicationDbContext _context;
        public ShopService(ApplicationDbContext context)
        {
            _context = context;

        }
        //Kategorie
        public async Task<int> CreateShopCategory(ShopCategoryForListVm shopCategory)
        {
            var newShopCategory = new Data.Entity.Shop.ShopCategory
            {
                Name = shopCategory.Name,
                IdParentCategory = shopCategory.IdParentCategory
            };
            _context.ShopCategories.Add(newShopCategory);
            await _context.SaveChangesAsync();
            return newShopCategory.Id;
        }
        public async Task<IEnumerable<ShopCategoryForListVm>> GetAllShopCategories()
        {
            var categories = await _context.ShopCategories.ToListAsync();
            return categories.Select(c => new ShopCategoryForListVm
            {
                Id = c.Id,
                Name = c.Name,
                IdParentCategory = c.IdParentCategory
            });
        }
        public async Task<int> UpdateShopCategory(ShopCategoryForListVm shopCategory)
        {
            var existingCategory = await _context.ShopCategories.FindAsync(shopCategory.Id);
            if (existingCategory == null)
            {
                throw new Exception("Category not found");
            }
            existingCategory.Name = shopCategory.Name;
            existingCategory.IdParentCategory = shopCategory.IdParentCategory;
            await _context.SaveChangesAsync();
            return existingCategory.Id;
        }
        public async Task<bool> DeleteShopCategory(int id)
        {
            var category = await _context.ShopCategories.FindAsync(id);
            if (category == null)
            {
                return false;
            }
            _context.ShopCategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<TreeCategoryForListVm>> GetCategoryTreeAsync()
        {
            // Pobierz wszystkie kategorie z bazy
            var flatCategories = await _context.ShopCategories
            .AsNoTracking()
            .Select(c => new
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                IdParentCategory = c.IdParentCategory
            })
            .ToListAsync();

            var lookup = flatCategories.ToDictionary(
                c => c.Id,
                c => new TreeCategoryForListVm
                {
                    IdCategory = c.Id,
                    Name = c.Name
                });

            // Zbuduj drzewo
            List<TreeCategoryForListVm> roots = new();
            foreach (var cat in flatCategories)
            {
                if (string.IsNullOrEmpty(cat.IdParentCategory))
                {
                    roots.Add(lookup[cat.Id]);
                }
                else if (lookup.ContainsKey(cat.IdParentCategory))
                {
                    lookup[cat.IdParentCategory].ChildCategories.Add(lookup[cat.Id]);
                }
            }
            return roots;
        }
    }
}
