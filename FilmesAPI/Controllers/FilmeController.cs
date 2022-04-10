using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Insert([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readDto = _filmeService.Insert(filmeDto);            
            return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin, regular")]
        public IActionResult GetAll([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> readDto = _filmeService.GetAll(classificacaoEtaria);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ReadFilmeDto readDto = _filmeService.GetById(id);
            if (readDto != null) return Ok(readDto);            
            return NotFound();            
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result resultado = _filmeService.Update(id, filmeDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Result resultado = _filmeService.Delete(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
