using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime;
using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;

namespace EVideoPrime.API.BusinessAccessLayer.Services.VideoPrime
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IUnitOfWorkVideoPrime _unitOfWorkVideoPrime;

        public CategoryServices(IUnitOfWorkVideoPrime unitOfWorkVideoPrime)
        {
            _unitOfWorkVideoPrime = unitOfWorkVideoPrime;
        }

        public async Task<CategoryModel> AddCategoryAsync(CategoryModel model)
        {
            var result = await _unitOfWorkVideoPrime.CategoryRepository.AddAsync(new Category
            {
                Name = model.Name,
                Description = model.Description
            });
            model.Id = result!.Id;
            return model;
        }

        public async Task AddCategoryAsync(IEnumerable<CategoryModel> models)
        {
            await _unitOfWorkVideoPrime.CategoryRepository.AddRangeAsync(models.Select(m => new Category
            {
                Name = m.Name
            }));
        }

        public async Task<CategoryModel> RemoveCategoryAsync(CategoryModel model)
        {
            var result = await _unitOfWorkVideoPrime.CategoryRepository.RemoveAsync(new Category
            {
                Id = model.Id,
                Name = model.Name
            });

            return model;
        }

        public async Task RemoveCategoryAsync(IEnumerable<CategoryModel> models)
        {
            await _unitOfWorkVideoPrime.CategoryRepository.RemoveRangeAsync(models.Select(m => new Category
            {
                Id = m.Id,
                Name = m.Name
            }));
        }

        public async Task<CategoryModel> GetCategoryAsync(int id)
        {
            var result = await _unitOfWorkVideoPrime.CategoryRepository.GetAsync(id);

            return new CategoryModel
            {
                Id = result!.Id,
                Name = result!.Name
            };
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoryAsync()
        {
            var result = await _unitOfWorkVideoPrime.CategoryRepository.GetAllAsync();

            return result!.Select(m => new CategoryModel
            {
                Id = m!.Id,
                Name = m!.Name
            });
        }
    }
}
