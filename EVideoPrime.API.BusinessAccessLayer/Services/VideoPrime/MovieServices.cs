using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime;
using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;

namespace EVideoPrime.API.BusinessAccessLayer.Services.VideoPrime
{
    public class MovieServices : IMovieServices
    {
        private readonly IUnitOfWorkVideoPrime _unitOfWorkVideoPrime;

        public MovieServices(IUnitOfWorkVideoPrime unitOfWorkVideoPrime)
        {
            _unitOfWorkVideoPrime = unitOfWorkVideoPrime;
        }

        public async Task<MovieModel> AddMovieAsync(MovieModel model)
        {
            var result = await _unitOfWorkVideoPrime.MovieRepository.AddAsync(new Movie
            {
                Banner = model.Banner,
                Category = model.CategoryDetail,
                Duration = model.Duration,
                Languages = model.Languages.Select(l=> new Language
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList(),
                Name = model.Name,
                IsActive = model.IsActive,
                ReleaseDate = model.ReleaseDate,
                Summary = model.Summary,
                Thumbnail = model.Thumbnail,
                VideoUrl = model.VideoUrl
            });

            return new MovieModel
            {
                Banner = result!.Banner,
                CategoryDetail = result!.Category,
                Duration = result!.Duration,
                Languages = result!.Languages.Select(l => new LanguageModel
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList(),
                Name = result!.Name,
                IsActive = result!.IsActive,
                ReleaseDate = result!.ReleaseDate,
                Summary = result!.Summary,
                Thumbnail = result!.Thumbnail,
                VideoUrl = result!.VideoUrl
            };
        }

        public async Task AddMoviesAsync(IEnumerable<MovieModel> model)
        {
            await _unitOfWorkVideoPrime.MovieRepository.AddRangeAsync(model.Select(m => new Movie
            {
                Banner = m.Banner,
                Category = m.CategoryDetail,
                Duration = m.Duration,
                Languages = m.Languages.Select(l => new Language
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList(),
                Name = m.Name,
                IsActive = m.IsActive,
                ReleaseDate = m.ReleaseDate,
                Summary = m.Summary,
                Thumbnail = m.Thumbnail,
                VideoUrl = m.VideoUrl
            }));
        }

        public async Task<MovieModel> RemoveMovieAsync(MovieModel model)
        {
            var result = await _unitOfWorkVideoPrime.MovieRepository.RemoveAsync(new Movie
            {
                Banner = model.Banner,
                Category = model.CategoryDetail,
                Duration = model.Duration,
                Languages = model.Languages.Select(l => new Language
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList(),
                Name = model.Name,
                IsActive = model.IsActive,
                ReleaseDate = model.ReleaseDate,
                Summary = model.Summary,
                Thumbnail = model.Thumbnail,
                VideoUrl = model.VideoUrl
            });

            return new MovieModel
            {
                Banner = result!.Banner,
                CategoryDetail = result!.Category,
                Duration = result!.Duration,
                Languages = result!.Languages.Select(l => new LanguageModel
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList(),
                Name = result!.Name,
                IsActive = result!.IsActive,
                ReleaseDate = result!.ReleaseDate,
                Summary = result!.Summary,
                Thumbnail = result!.Thumbnail,
                VideoUrl = result!.VideoUrl
            };
        }

        public async Task RemoveMoviesAsync(IEnumerable<MovieModel> model)
        {
            await _unitOfWorkVideoPrime.MovieRepository.RemoveRangeAsync(model.Select(m => new Movie
            {
                Banner = m.Banner,
                Category = m.CategoryDetail,
                Duration = m.Duration,
                Languages = m.Languages.Select(l => new Language
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList(),
                Name = m.Name,
                IsActive = m.IsActive,
                ReleaseDate = m.ReleaseDate,
                Summary = m.Summary,
                Thumbnail = m.Thumbnail,
                VideoUrl = m.VideoUrl
            }));
        }

        public async Task<MovieModel> GetMovieAsync(int id)
        {
            var result = await _unitOfWorkVideoPrime.MovieRepository.GetAsync(id);

            return new MovieModel
            {
                Banner = result!.Banner,
                CategoryDetail = result!.Category,
                Duration = result!.Duration,
                Languages = result!.Languages.Select(l => new LanguageModel
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList(),
                Name = result!.Name,
                IsActive = result!.IsActive,
                ReleaseDate = result!.ReleaseDate,
                Summary = result!.Summary,
                Thumbnail = result!.Thumbnail,
                VideoUrl = result!.VideoUrl
            };
        }

        public async Task<IEnumerable<MovieModel>> GetAllMoviesAsync()
        {
            var result = await _unitOfWorkVideoPrime.MovieRepository.GetAllAsync();

            return result!.Select(m => new MovieModel
            {
                Banner = m.Banner,
                CategoryDetail = m.Category,
                Duration = m.Duration,
                Languages = m.Languages.Select(l => new LanguageModel
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList(),
                Name = m.Name,
                IsActive = m.IsActive,
                ReleaseDate = m.ReleaseDate,
                Summary = m.Summary,
                Thumbnail = m.Thumbnail,
                VideoUrl = m.VideoUrl
            });
        }

        public async Task<IEnumerable<MovieModel>> GetMovieByCategoryAsync(string category)
        {
            return await _unitOfWorkVideoPrime.MovieRepository.GetMovieByCategoryAsync(category);
        }

        public async Task<IEnumerable<MovieModel>> GetMovieByLanguageAsync(string language)
        {
            return await _unitOfWorkVideoPrime.MovieRepository.GetMovieByLanguageAsync(language);
        }
    }
}
