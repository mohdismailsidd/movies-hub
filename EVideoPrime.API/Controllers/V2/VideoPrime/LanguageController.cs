﻿using EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;

namespace EVideoPrime.API.Controllers.V2.VideoPrime
{
    [ApiVersion("2")]
    public class LanguageController : BaseApiController
    {
        private readonly ILanguageServices _services;

        public LanguageController(ILanguageServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAllLanguage()
        {
            var result = _services.GetAllLanguageAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetLanguageById(int Id)
        {
            var result = _services.GetLanguageAsync(Id);
            return Ok(result);
        }
    }
}
