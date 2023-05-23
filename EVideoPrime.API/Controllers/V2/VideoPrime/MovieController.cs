using EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;

namespace EVideoPrime.API.Controllers.V2.VideoPrime
{
    [ApiVersion("2")]
    public class MovieController : BaseApiController
    {
        private readonly IMovieServices _services;

        public MovieController(IMovieServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAllMovie()
        {
            var result = _services.GetAllMoviesAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetMovieById(int Id)
        {
            var result = _services.GetMovieAsync(Id);
            return Ok(result);
        }
    }
}
