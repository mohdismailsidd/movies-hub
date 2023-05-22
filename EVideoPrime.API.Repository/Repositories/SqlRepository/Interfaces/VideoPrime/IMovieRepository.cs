using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<MovieModel>> GetMovieByCategoryAsync(string category);
        Task<IEnumerable<MovieModel>> GetMovieByLanguageAsync(string language);
    }
}
