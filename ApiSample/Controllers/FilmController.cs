using ApiSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController(FilmService _filmService) : ControllerBase
    {
        //private readonly FilmService _filmService;

        //public FilmController(FilmService filmService)
        //{
        //    _filmService = filmService;
        //}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_filmService.Liste);
        }
    }
}
