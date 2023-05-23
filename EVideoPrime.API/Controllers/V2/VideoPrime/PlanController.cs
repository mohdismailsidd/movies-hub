using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime;
using Microsoft.AspNetCore.Mvc;

namespace EVideoPrime.API.Controllers.V2.VideoPrime
{
    [ApiVersion("2")]
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

        [HttpPost]
        public IActionResult CreatePlan(PlanModel model)
        {
            var result = _services.AddPlanAsync(model);
            return CreatedAtAction("CreatePlan",result);
        }
    }
}
