using Microsoft.AspNetCore.Mvc;
using TallerModel;

namespace TallerModelAPI.Controllers
{
    [ApiController]
    [Route("Taller/[controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<ActionResult<Usuario>> Create(Usuario usuario)
            {
                UsuarioServices usuarioService = new UsuarioServices();
                var usuarioCreado = usuarioService.Create(usuario);

            return usuarioCreado == null ? NotFound() : Ok(usuarioCreado); //devuelve dependiendo si es nulo o no, devuelve un tipo de estado http 
                }
            
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Usuario>>>GetAll()
        {
            UsuarioServices usuarioService = new UsuarioServices();
            var listaUsuarios = usuarioService.GetAll();
            return listaUsuarios == null ? NotFound() : Ok(listaUsuarios);

    }

        [HttpGet("GetById")]
        public async Task<ActionResult<Usuario>> GeyById(int usuarioId)
        {
            UsuarioServices usuarioService = new UsuarioServices();
            var usuarioEncontrado = usuarioService.GetById(usuarioId);
            if (usuarioEncontrado != null)
            {
                return BadRequest("Error al encontrar usuario");
            }
            else
            {
                return Ok(usuarioEncontrado);
            }
        }

        [HttpGet("GetByNombreyAp")]

        [HttpPut("Update")]
        public async Task<ActionResult<Usuario>> Update(int usuarioId)
        {
            UsuarioServices usuarioService = new UsuarioServices();
            var usuarioActualizado = usuarioService.GetById(usuarioId);
            if (usuarioActualizado != null)
            {
                return BadRequest("Error al actualizar  usuario");
            }
            else
            {
                return Ok(usuarioActualizado);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Usuario>> Delete(int usuarioId)
        {
            UsuarioServices usuarioService = new UsuarioServices();
            var usuarioEncontrado = usuarioService.Delete(usuarioId);
            if (usuarioEncontrado != null)
            {
                return BadRequest("Error al eliminar usuario");
            }
            else
            {
                return Ok(usuarioEncontrado);
            }
        }
    }
}
