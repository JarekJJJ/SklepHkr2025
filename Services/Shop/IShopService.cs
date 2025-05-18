using SklepHkr2025.Model.Shop;

namespace SklepHkr2025.Services.Shop
{
    public interface IShopService
    {
        Task<int> CreateShopCategory(ShopCategoryForListVm shopCategory);
        Task<bool> DeleteShopCategory(int id);
        Task<IEnumerable<ShopCategoryForListVm>> GetAllShopCategories();
        Task<int> UpdateShopCategory(ShopCategoryForListVm shopCategory);
        Task<List<TreeCategoryForListVm>> GetCategoryTreeAsync();
    }
}