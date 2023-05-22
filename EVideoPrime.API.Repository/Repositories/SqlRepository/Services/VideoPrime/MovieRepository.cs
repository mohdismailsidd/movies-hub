using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.Interfaces;
using EVideoPrime.API.Repository.Services;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;
using Microsoft.EntityFrameworkCore;
using Movies.API.DAL;
using System.Linq;

namespace EVideoPrime.API.Repository.SqlRepository.Services.VideoPrime
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        SqlDbContext DbContext
        {
            get
            {
                return _dBContext as SqlDbContext;
            }
        }

        public MovieRepository(DbContext dBContext) : base(dBContext)
        {
        }

        public async Task<IEnumerable<MovieModel>> GetMovieByCategoryAsync(string category)
        {
            var data = await this.
                FindAsync(m => m.Category.Name.Equals(category, StringComparison.InvariantCultureIgnoreCase));

            return data.Select(m=> new MovieModel
            {
                Banner = m.Banner,
                CategoryDetail = m.Category,
                Duration = m.Duration,
                Id = m.Id,
                IsActive = m.IsActive,
                Languages = m.Languages.Select(l => new LanguageModel
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList(),
                Name = m.Name,
                ReleaseDate = m.ReleaseDate,
                Summary = m.Summary,
                Thumbnail = m.Thumbnail,
                VideoUrl = m.VideoUrl
            });
        }

        public async Task<IEnumerable<MovieModel>> GetMovieByLanguageAsync(string language)
        {
            var data = await this.
                FindAsync(m => m.Languages.Where(l=> l.Name.Equals(language, StringComparison.InvariantCultureIgnoreCase)).Any());

            return data.Select(m => new MovieModel
            {
                Banner = m.Banner,
                CategoryDetail = m.Category,
                Duration = m.Duration,
                Id = m.Id,
                IsActive = m.IsActive,
                Languages = m.Languages.Select(l => new LanguageModel
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList(),
                Name = m.Name,
                ReleaseDate = m.ReleaseDate,
                Summary = m.Summary,
                Thumbnail = m.Thumbnail,
                VideoUrl = m.VideoUrl
            });
        }
    }
}
