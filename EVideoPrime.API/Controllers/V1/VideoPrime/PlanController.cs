using EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime;
using Microsoft.AspNetCore.Mvc;

namespace EVideoPrime.API.Controllers.V1.VideoPrime
{
    [ApiVersion("1")]
    public class PlanController : BaseApiController
    {
        private readonly IPlanServices _services;

        public PlanController(IPlanServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAllPlan()
        {
            var result = _services.GetAllPlansAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetPlanById(int Id)
        {
            var result = _services.GetPlanAsync(Id);
            return Ok(result);
        }
    }
}
