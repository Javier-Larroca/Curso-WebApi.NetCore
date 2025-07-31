using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimerWebApi.Bussiness;
using MiPrimerWebApi.Bussiness.BussinessExceptions;
using MiPrimerWebApi.DTOs;

namespace MiPrimerWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController(ILibrosService librosService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroResponseDTO>>> GetLibros(
            [FromQuery] int limit = 10,
            [FromQuery] int page = 1
            )
        {
            var libros = await librosService.GetLibros(limit, page);
            return Ok(libros.Select(l => l.ToResponse()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibroResponseDTO>> GetLibro([FromRoute] int id)
        {
            var libro = await librosService.GetLibro(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro.ToResponse();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro([FromRoute] int id, [FromBody] LibroRequestDTO libroDto)
        {
            try
            {
                await librosService.UpdateLibro(id, libroDto.ToLibro());
            }
            catch (BussinessException ex)
            {
                if (ex is AutorNoExisteException)
                {
                    return NotFound(ex.Message);
                }
                if (ex is LibroNoExisteException)
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
                //logger.LogError(ex.Message);
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<LibroResponseDTO>> PostLibro([FromBody] LibroRequestDTO libroDto)
        {
            var createdLibro = await librosService.CreateLibro(libroDto.ToLibro());

            return CreatedAtAction(nameof(GetLibro), new { id = createdLibro.Id }, createdLibro.ToResponse());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro([FromRoute] int id)
        {
            try
            {
                await librosService.DeleteLibro(id);
            }
            catch (AutorNoExisteException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

    }
}
