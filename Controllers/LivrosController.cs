using Microsoft.AspNetCore.Mvc;
using BibliotecaAPI.Services;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {
        private readonly LivroService _service;

        public LivrosController(LivroService service) => _service = service;

        [HttpGet] public IActionResult Listar() => Ok(_service.Listar());

        [HttpPost] public IActionResult Cadastrar([FromBody] Livro livro)
        {
            _service.Cadastrar(livro);
            return Ok(livro);
        }
    }
}
