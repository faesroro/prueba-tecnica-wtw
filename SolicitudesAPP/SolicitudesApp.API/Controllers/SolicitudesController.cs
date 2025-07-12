using Microsoft.AspNetCore.Mvc;
using SolicitudesApp.Application.Services;
using SolicitudesApp.Application.DTOs;

namespace SolicitudesApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudesController : ControllerBase
    {
        private readonly SolicitudService _service;

        public SolicitudesController(SolicitudService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitudDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("filtro")]
        public async Task<ActionResult<IEnumerable<SolicitudDto>>> GetFiltered([FromQuery] string? tipo, [FromQuery] DateTime? fecha, [FromQuery] string? estado)
        {
            int? estadoInt = null;

            if (!string.IsNullOrWhiteSpace(estado) && int.TryParse(estado, out int parsed))
            {
                estadoInt = parsed;
            }

            var result = await _service.GetFilteredAsync(tipo, fecha, estadoInt);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudDto>> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CrearSolicitudRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Tipo) || request.Datos is null)
                return BadRequest("El cuerpo debe incluir 'tipo' y 'datos'.");

            var id = await _service.CreateAsync(request.Tipo, request.Estado, request.Datos);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}