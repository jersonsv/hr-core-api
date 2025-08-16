using API.EMPRESA.CONF.Models;
using API.EMPRESA.CONF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.EMPRESA.CONF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoService _service;

        public EmpleadoController(EmpleadoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult<List<Empleado>>> lista()
        {
            return Ok(await _service.Lista());
        }

        [HttpGet]
        [Route("Obtener/{id}")]
        public async Task<ActionResult<List<Empleado>>> obtenerEmpleado(int id)
        {
            var empleado = await _service.ObtenerEmpleado(id);

            if(empleado == null)
                return NotFound("No se encontro el empleado");
            else
                return Ok(empleado);
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<ActionResult> crear(Empleado empleado)
        {
            var response = await _service.CrearEmpleado(empleado);

            if (!string.IsNullOrEmpty(response))
                return BadRequest(response);
            else
                return Ok("Empleado Registado");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<ActionResult> editar(Empleado empleado)
        {
            var response = await _service.EditarEmpleado(empleado);

            if (!string.IsNullOrEmpty(response))
                return BadRequest(response);
            else
                return Ok("Empleado Actualizado");
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<ActionResult> eliminar(int id)
        {
            await _service.EliminarEmpleado(id);
            return Ok();

        }
    }
}
