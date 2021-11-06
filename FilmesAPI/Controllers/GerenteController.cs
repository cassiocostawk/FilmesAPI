using FilmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult Insert(CreateGerenteDto dto)
        {
            ReadGerenteDto readDto = _gerenteService.Insert(dto);
            return CreatedAtAction(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ReadGerenteDto readDto = _gerenteService.GetById(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Result resultado = _gerenteService.Delete(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
