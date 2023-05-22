using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.BusinessAccessLayer.Interface.Identity;
using EVideoPrime.API.Entities.Identity;
using EVideoPrime.API.Repository.SqlRepository.Interface.Identity;

namespace EVideoPrime.API.BusinessAccessLayer.Services.Identity
{
    public class RoleServices : IRoleServices
    {
        private readonly IUnitOfWorkIdentity _unitOfWorkIdentity;

        public RoleServices(IUnitOfWorkIdentity unitOfWorkIdentity)
        {
            _unitOfWorkIdentity = unitOfWorkIdentity;
        }

        public async Task<CategoryModel> AddCategoryAsync(CategoryModel model)
        {
            var result = await _unitOfWorkIdentity.RoleRepository.AddAsync(new Role
            {
                Name = model.Name,
            });
            model.Id = result!.Id;
            return model;
        }

        public async Task AddCategoryAsync(IEnumerable<CategoryModel> models)
        {
            await _unitOfWorkIdentity.RoleRepository.AddRangeAsync(models.Select(m => new Role
            {
                Name = m.Name
            }));
        }

        public async Task<CategoryModel> RemoveCategoryAsync(CategoryModel model)
        {
            var result = await _unitOfWorkIdentity.RoleRepository.RemoveAsync(new Role
            {
                Id = model.Id,
                Name = model.Name
            });

            return model;
        }

        public async Task RemoveCategoryAsync(IEnumerable<CategoryModel> models)
        {
            await _unitOfWorkIdentity.RoleRepository.RemoveRangeAsync(models.Select(m => new Role
            {
                Id = m.Id,
                Name = m.Name
            }));
        }

        public async Task<CategoryModel> GetCategoryAsync(int id)
        {
            var result = await _unitOfWorkIdentity.RoleRepository.GetAsync(id);

            return new CategoryModel
            {
                Id = result!.Id,
                Name = result!.Name
            };
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoryAsync()
        {
            var result = await _unitOfWorkIdentity.RoleRepository.GetAllAsync();

            return result!.Select(m => new CategoryModel
            {
                Id = m!.Id,
                Name = m!.Name
            });
        }
    }
}
