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


        //List / Read
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Values;
        }

        //Create
        [HttpPost]
        public ActionResult<string> Post()
        {
            var newValue = $"Value {Values.Count + 1}";
            Values.Add(newValue);
            return Created(nameof(GetOne), Values.Count);
        }

        //Read One
        [HttpGet("{indice}")]
        public ActionResult<string> GetOne(int indice)
        {
            if (indice >= Values.Count)
            {
                return BadRequest("Indice fuera de rango");
            }
            return Values[indice];
        }

        //Update
        [HttpPut("{indice}")]
        public ActionResult<string> Put(int indice)
        {
            if (indice >= Values.Count)
            {
                return BadRequest("Indice fuera de rango");
            }
            Values[indice] += " - Modificado";
            return Values[indice];
        }

        //Delete
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
