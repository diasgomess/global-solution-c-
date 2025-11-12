using Microsoft.AspNetCore.Mvc;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/prompts")]
    public class PromptsController : ControllerBase
    {
        private readonly PromptService _service;

        // Injeção de Dependência do PromptService
        public PromptsController(PromptService service) => _service = service;

        // GET: api/prompts
        /// <summary>
        /// Retorna todos os Prompts cadastrados na memória.
        /// </summary>
        [HttpGet]
        public IActionResult Listar()
        {
            // Delega a chamada para o service
            var prompts = _service.Listar();
            
            if (!prompts.Any())
            {
                return NoContent(); // Retorna 204 No Content se a lista estiver vazia
            }
            
            return Ok(prompts); // Retorna 200 OK com a lista
        }

        // POST: api/prompts
        /// <summary>
        /// Cadastra um novo Prompt.
        /// </summary>
        [HttpPost]
        public IActionResult Criar([FromBody] Prompt novoPrompt)
        {
            try
            {
                // Delega a lógica de cadastro para o service
                _service.Cadastrar(novoPrompt);

                // Retorna 201 Created (Criado com sucesso)
                return CreatedAtAction(
                    // Nota: Se você tivesse um método de busca por Título na controller, usaria ele aqui.
                    // Como não temos, retornaremos o 201 Simples.
                    nameof(Listar), 
                    null, // Passa null para a rota, pois não queremos um URI específico para Listar
                    novoPrompt // Retorna o objeto criado no corpo da resposta
                );
            }
            catch (Exception ex)
            {
                // Captura a exceção de "já cadastrado" ou outra falha de validação
                return BadRequest(ex.Message); // Retorna 400 Bad Request com a mensagem de erro
            }
        }
    }
}