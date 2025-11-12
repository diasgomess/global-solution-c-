using BibliotecaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaAPI.Services
{
    public class PromptService
    {
        // ⚠️ Simulação em memória: Armazena os prompts em uma lista local
        private readonly List<Prompt> _prompts = new();

        // GET: Lista todos os prompts
        /// <summary>
        /// Retorna todos os Prompts cadastrados na memória.
        /// </summary>
        public IEnumerable<Prompt> Listar() => _prompts;
        
        // Helper: Busca um prompt pelo Título (similar ao BuscarPorISBN)
        public Prompt? ObterPorTitulo(string titulo) => 
            _prompts.FirstOrDefault(p => p.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        // POST: Cadastra um novo prompt
        /// <summary>
        /// Cadastra um novo Prompt na memória, garantindo que o Título seja único.
        /// </summary>
        /// <param name="prompt">O Prompt a ser cadastrado.</param>
        public void Cadastrar(Prompt prompt)
        {
            // Valida se o Título já existe (usando a busca case-insensitive)
            if (_prompts.Any(p => p.Titulo.Equals(prompt.Titulo, StringComparison.OrdinalIgnoreCase)))
            {
                // Em um serviço real, você lançaria uma exceção ou retornaria um código de erro.
                throw new Exception($"Prompt com o título '{prompt.Titulo}' já cadastrado.");
            }
            
            // Define a data de cadastro no momento da criação
            prompt.DataCadastro = DateTime.Now; 
            
            _prompts.Add(prompt);
        }
    }
}