using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult Insert(CreateSessaoDto dto)
        {
            ReadSessaoDto readDto = _sessaoService.Insert(dto);
            return CreatedAtAction(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ReadSessaoDto readDto = _sessaoService.GetById(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

    }
}
