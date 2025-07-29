using Microsoft.AspNetCore.Mvc;
using MiPrimerWebApi.Bussiness;
using MiPrimerWebApi.Bussiness.BussinessExceptions;
using MiPrimerWebApi.DTOs;
using MiPrimerWebApi.Model;

namespace MiPrimerWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController(IAutoresService autoresService, ILogger<AutoresController> logger) : ControllerBase
    {

        // GET: api/Autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorResponseDTO>>> GetAutores(
            [FromQuery] int limit = 10,
            [FromQuery] int page = 1
            )
        {
            var autores = await autoresService.GetAutores(limit, page);
            return Ok(autores.Select(a=> a.ToResponse()));
        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorResponseDTO>> GetAutor([FromRoute] int id)
        {
            var autor = await autoresService.GetAutor(id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor.ToResponse();
        }

        // PUT: api/Autores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor([FromRoute] int id, [FromBody] AutorRequestDTO autorDto)
        {
            try
            {
                await autoresService.UpdateAutor(id, autorDto.ToAutor());
            }
            catch (BussinessException ex)
            {
                if(ex is AutorNoExisteException)
                {
                    return NotFound(ex.Message);
                }
                if (ex is DatosInvalidosException)
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (Exception ex) 
            {
                logger.LogError(ex.Message);
                throw;
            }

            return NoContent();
        }

        // POST: api/Autores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AutorResponseDTO>> PostAutor([FromBody] AutorRequestDTO autorDto)
        {
            var createdAutor = await autoresService.CreateAutor(autorDto.ToAutor());

            return CreatedAtAction(nameof(GetAutor), new { id = createdAutor.Id }, createdAutor.ToResponse());
        }

        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor([FromRoute] int id)
        {
            try
            {
                await autoresService.DeleteAutor(id);
            }
            catch (AutorNoExisteException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }


    }
}
