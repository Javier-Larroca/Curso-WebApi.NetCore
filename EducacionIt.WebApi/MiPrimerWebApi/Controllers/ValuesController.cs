using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static List<string> Values = ["Value 1", "Value 2"];

        public ValuesController()
        {
            Console.WriteLine("Inicializando el controller");
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Values;    
        }

        [HttpPost]
        public ActionResult<string> Post()
        {
            var newValue = $"Value {Values.Count + 1}";
            Values.Add(newValue);
            return Created(nameof(GetOne), newValue);
        }

        [HttpGet("{indice}")]
        public ActionResult<string> GetOne(int indice)
        {
            if(indice >= Values.Count)
            {
                return BadRequest("Indice fuera de rango");
            }
            return Values[indice];
        }

        [HttpPut("{indice}")]
        public ActionResult<string> Put(int indice)
        {
            if (indice >= Values.Count)
            {
                return BadRequest("Indice fuera de rango");
            }
            Values[indice] += " - modificado";
            return Values[indice];
        }

        [HttpDelete("{indice}")]
        public ActionResult Delete(int indice)
        {
            if (indice >= Values.Count)
            {
                return BadRequest("Indice fuera de rango");
            }
            Values.RemoveAt(indice);
            return NoContent();
        }
    }
}
