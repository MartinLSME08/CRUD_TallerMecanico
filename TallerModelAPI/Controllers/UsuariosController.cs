using Microsoft.AspNetCore.Mvc;
using TallerModel;

namespace TallerModelAPI.Controllers
{
    [ApiController]
    [Route("Taller/[controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<ActionResult<Usuario>>Create(Usuario usuario)
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
        public async Task<ActionResult<Usuario>>GeyById(int usuarioId)
        {
            UsuarioServices usuarioService = new UsuarioServices();
            var usuarioEncontrado = usuarioService.GetById(usuarioId);
            return usuarioEncontrado == null ? NotFound() : Ok(usuarioEncontrado);

        }

        [HttpGet("GetByNombreyAp")]
        public async Task<ActionResult<Usuario>> GetByNombreyAp(string filtro)
        {
            UsuarioServices usuarioService = new UsuarioServices();
            var usuarioEncontrado = usuarioService.GetByNombreyAp(filtro);
            return usuarioEncontrado == null ? NotFound() : Ok(usuarioEncontrado);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Usuario>>Update(Usuario usuario)
        {
            UsuarioServices usuarioService = new UsuarioServices();
            var usuarioActualizado = usuarioService.Update(usuario);
            return usuarioActualizado == null ? NotFound() : Ok(usuarioActualizado);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Usuario>>Delete(int usuarioId)
        {
            UsuarioServices usuarioService = new UsuarioServices();
            var usuarioEliminado = usuarioService.Delete(usuarioId);
            return usuarioEliminado == null ? NotFound() : Ok(usuarioEliminado);

        }
    }
}
