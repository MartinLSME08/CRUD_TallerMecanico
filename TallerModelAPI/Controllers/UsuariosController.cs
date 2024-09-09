using Microsoft.AspNetCore.Mvc;
using TallerModel;

namespace TallerModelAPI.Controllers
{
    [ApiController]
    [Route("Taller/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioServices _usuarioService;

        public UsuariosController() {
            _usuarioService = new UsuarioServices();
                }

        [HttpPost("Create")]
        public async Task<ActionResult<Usuario>>Create(Usuario usuario)
            {
                var usuarioCreado = await _usuarioService.Create(usuario);
                return usuarioCreado == null ? NotFound() : Ok(usuarioCreado); //devuelve dependiendo si es nulo o no, devuelve un tipo de estado http 
                }
            
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Usuario>>>GetAll()
        {
            var listaUsuarios = await _usuarioService.GetAll();
            return listaUsuarios == null ? NotFound() : Ok(listaUsuarios);

        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Usuario>>GeyById(int usuarioId)
        {
            var usuarioEncontrado = await _usuarioService.GetById(usuarioId);
            return usuarioEncontrado == null ? NotFound() : Ok(usuarioEncontrado);

        }

        [HttpGet("GetByNombreyAp")]
        public async Task<ActionResult<Usuario>> GetByNombreyAp(string filtro)
        {
            var usuarioEncontrado = await _usuarioService.GetByNombreyAp(filtro);
            return usuarioEncontrado == null ? NotFound() : Ok(usuarioEncontrado);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Usuario>>Update(Usuario usuario)
        {
            var usuarioActualizado = await _usuarioService.Update(usuario);
            return usuarioActualizado == null ? NotFound() : Ok(usuarioActualizado);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Usuario>>Delete(int usuarioId)
        {
            var usuarioEliminado = await _usuarioService.Delete(usuarioId);
            return usuarioEliminado == null ? NotFound() : Ok(usuarioEliminado);
        }
    }
}
