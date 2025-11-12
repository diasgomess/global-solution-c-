using Microsoft.AspNetCore.Mvc;
using BibliotecaAPI.Services;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuariosController(UsuarioService service) => _service = service;

        [HttpGet] public IActionResult Listar() => Ok(_service.Listar());

        [HttpPost] public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            _service.Cadastrar(usuario);
            return Ok(usuario);
        }
    }
}
