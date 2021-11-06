using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readDto = _enderecoService.Insert(enderecoDto);
            return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ReadEnderecoDto> readDto = _enderecoService.GetAll();

            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ReadEnderecoDto readDto = _enderecoService.GetById(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result resultado = _enderecoService.Update(id, enderecoDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Result resultado = _enderecoService.Delete(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
