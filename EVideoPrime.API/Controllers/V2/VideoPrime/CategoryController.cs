using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;

namespace EVideoPrime.API.Controllers.V2.VideoPrime
{
    [ApiVersion("2")]
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryServices _services;

        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var result = _services.GetAllCategoryAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int Id)
        {
            var result = _services.GetCategoryAsync(Id);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            var result = _services.AddCategoryAsync(model);
            return CreatedAtAction("CreateCategory", result);
        }
    }
}
