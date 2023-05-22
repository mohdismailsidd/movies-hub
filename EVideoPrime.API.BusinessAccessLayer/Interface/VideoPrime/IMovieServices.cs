using EVideoPrime.API.Abstractions.Models.VideoPrime;

namespace EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime
{
    public interface IMovieServices
    {
        Task<MovieModel> AddMovieAsync(MovieModel movieModel);
        Task AddMoviesAsync(IEnumerable<MovieModel> movieModels);
        Task<IEnumerable<MovieModel>> GetAllMoviesAsync();
        Task<MovieModel> GetMovieAsync(int id);
        Task<IEnumerable<MovieModel>> GetMovieByCategoryAsync(string category);
        Task<IEnumerable<MovieModel>> GetMovieByLanguageAsync(string language);
        Task<MovieModel> RemoveMovieAsync(MovieModel movieModel);
        Task RemoveMoviesAsync(IEnumerable<MovieModel> movieModels);
    }
}