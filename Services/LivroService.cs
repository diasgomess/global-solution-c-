using BibliotecaAPI.Models;

namespace BibliotecaAPI.Services
{
    public class LivroService
    {
        private readonly List<Livro> _livros = new();

        public IEnumerable<Livro> Listar() => _livros;
        public Livro? BuscarPorISBN(string isbn) => _livros.FirstOrDefault(l => l.ISBN == isbn);

        public void Cadastrar(Livro livro)
        {
            if (_livros.Any(l => l.ISBN == livro.ISBN))
                throw new Exception("Livro já cadastrado.");
            _livros.Add(livro);
        }

        public void AtualizarStatus(string isbn, StatusLivro status)
        {
            var livro = BuscarPorISBN(isbn) ?? throw new Exception("Livro não encontrado.");
            livro.Status = status;
        }
    }
}
