using Facturador.DTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Facturador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController(IValidator<FacturaDTO> validator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateFactura([FromBody] FacturaDTO factura)
        {
            ValidationResult result = await validator.ValidateAsync(factura);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }
    }
}
