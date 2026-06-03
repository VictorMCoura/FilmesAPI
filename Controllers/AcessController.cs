namespace FilmesAPI.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    [ApiController]
    public class AcessController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "IdadeMinima")]
        public IActionResult Get()
        {
            
            return Ok("Acesso Permitido");
        }
    }
