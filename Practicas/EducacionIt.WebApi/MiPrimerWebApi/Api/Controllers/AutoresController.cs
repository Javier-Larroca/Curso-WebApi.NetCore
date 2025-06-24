using Microsoft.AspNetCore.Mvc;
using MiPrimerWebApi.Bussiness;
using MiPrimerWebApi.Bussiness.BussinessExceptions;
using MiPrimerWebApi.Model;

namespace MiPrimerWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController(IAutoresService autoresService, ILogger<AutoresController> logger) : ControllerBase
    {

        // GET: api/Autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            var autores = await autoresService.GetAutores();
            return Ok(autores);
        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutor(int id)
        {
            var autor = await autoresService.GetAutor(id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        // PUT: api/Autores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, Autor autor)
        {
            try
            {
                await autoresService.UpdateAutor(id, autor);
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
        public async Task<ActionResult<Autor>> PostAutor(Autor autor)
        {
            var createdAutor = await autoresService.CreateAutor(autor);

            return CreatedAtAction(nameof(GetAutor), new { id = autor.Id }, createdAutor);
        }

        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
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
