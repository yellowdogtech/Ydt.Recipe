using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Ydt.Recipe.Services.Interfaces;
using HtmlAgilityPack;
using System.Net.Http;

namespace Ydt.Recipe.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get(string url)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(new Uri("https://www.budgetbytes.com/lemony-artichoke-and-quinoa-salad/"));
                return Ok(result);
            }


        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post()
        {
            return Created("", "");
        }
    }
}