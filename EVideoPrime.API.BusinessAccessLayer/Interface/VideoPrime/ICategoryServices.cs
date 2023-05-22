using EVideoPrime.API.Abstractions.Models.VideoPrime;

namespace EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime
{
    public interface ICategoryServices
    {
        Task<CategoryModel> AddCategoryAsync(CategoryModel model);
        Task AddCategoryAsync(IEnumerable<CategoryModel> models);
        Task<IEnumerable<CategoryModel>> GetAllCategoryAsync();
        Task<CategoryModel> GetCategoryAsync(int id);
        Task<CategoryModel> RemoveCategoryAsync(CategoryModel model);
        Task RemoveCategoryAsync(IEnumerable<CategoryModel> models);
    }
}