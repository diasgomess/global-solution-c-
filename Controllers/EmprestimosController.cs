using Microsoft.AspNetCore.Mvc;
using BibliotecaAPI.Services;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/emprestimos")]
    public class EmprestimosController : ControllerBase
    {
        private readonly EmprestimoService _service;

        public EmprestimosController(EmprestimoService service) => _service = service;

        [HttpGet] public IActionResult Listar() => Ok(_service.Listar());

        [HttpPost("{idUsuario}/{isbn}")]
        public IActionResult Emprestar(int idUsuario, string isbn)
        {
            _service.RegistrarEmprestimo(idUsuario, isbn);
            return Ok("Empréstimo registrado com sucesso.");
        }

        [HttpPost("devolucao/{idEmprestimo}")]
        public IActionResult Devolver(int idEmprestimo)
        {
            _service.RegistrarDevolucao(idEmprestimo);
            return Ok("Devolução registrada com sucesso.");
        }
    }
}
