using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime;
using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;

namespace EVideoPrime.API.BusinessAccessLayer.Services.VideoPrime
{
    public class LanguageServices : ILanguageServices
    {
        private readonly IUnitOfWorkVideoPrime _unitOfWorkVideoPrime;

        public LanguageServices(IUnitOfWorkVideoPrime unitOfWorkVideoPrime)
        {
            _unitOfWorkVideoPrime = unitOfWorkVideoPrime;
        }

        public async Task<LanguageModel> AddLanguageAsync(LanguageModel model)
        {
            var result = await _unitOfWorkVideoPrime.LanguageRepository.AddAsync(new Language
            {
                Name = model.Name
            });
            model.Id = result!.Id;
            return model;
        }

        public async Task AddLanguagesAsync(IEnumerable<LanguageModel> models)
        {
            await _unitOfWorkVideoPrime.LanguageRepository.AddRangeAsync(models.Select(m => new Language
            {
                Name = m.Name
            }));
        }

        public async Task<LanguageModel> RemoveLanguageAsync(LanguageModel model)
        {
            var result = await _unitOfWorkVideoPrime.LanguageRepository.RemoveAsync(new Language
            {
                Id = model.Id,
                Name = model.Name
            });

            return model;
        }

        public async Task RemoveLanguageAsync(IEnumerable<LanguageModel> models)
        {
            await _unitOfWorkVideoPrime.LanguageRepository.RemoveRangeAsync(models.Select(m => new Language
            {
                Id = m.Id,
                Name = m.Name
            }));
        }

        public async Task<LanguageModel> GetLanguageAsync(int id)
        {
            var result = await _unitOfWorkVideoPrime.LanguageRepository.GetAsync(id);
            var movies = await _unitOfWorkVideoPrime.MovieRepository.GetMovieByLanguageAsync(result!.Name);

            return new LanguageModel
            {
                Id = result!.Id,
                Name = result!.Name,
                Movies = movies
            };
        }

        public async Task<IEnumerable<LanguageModel>> GetAllLanguageAsync()
        {
            var result = await _unitOfWorkVideoPrime.LanguageRepository.GetAllAsync();

            var final = result!.Select(m => new LanguageModel
            {
                Id = m!.Id,
                Name = m!.Name
            });

            foreach (var lan in final)
            {
                lan.Movies = (await _unitOfWorkVideoPrime.MovieRepository.GetMovieByLanguageAsync(lan.Name)).ToList();
            }

            return final;
        }
    }
}
