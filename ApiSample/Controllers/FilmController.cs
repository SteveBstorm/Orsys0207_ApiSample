using ApiSample.Models;
using ApiSample.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize("adminPolicy")]
        [HttpPost]
        public IActionResult Post(Film f)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            _filmService.Add(f);
            return Ok();
        }

        [Authorize("userPolicy")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        { 
            return Ok(_filmService.GetById(id));
        }
    }
}
