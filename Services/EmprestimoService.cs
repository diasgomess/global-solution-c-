using BibliotecaAPI.Models;

namespace BibliotecaAPI.Services
{
    public class EmprestimoService
    {
        private readonly LivroService _livroService;
        private readonly UsuarioService _usuarioService;
        private readonly List<Emprestimo> _emprestimos = new();
        private readonly List<Multa> _multas = new();

        public EmprestimoService(LivroService livroService, UsuarioService usuarioService)
        {
            _livroService = livroService;
            _usuarioService = usuarioService;
        }

        public IEnumerable<Emprestimo> Listar() => _emprestimos;

        public void RegistrarEmprestimo(int idUsuario, string isbn)
        {
            var usuario = _usuarioService.BuscarPorId(idUsuario) ?? throw new Exception("Usuário não encontrado.");
            var livro = _livroService.BuscarPorISBN(isbn) ?? throw new Exception("Livro não encontrado.");

            if (livro.Status != StatusLivro.DISPONIVEL)
                throw new Exception("Livro não está disponível para empréstimo.");

            var emprestimosAtivos = _emprestimos.Count(e => e.IdUsuario == idUsuario && e.Status == StatusEmprestimo.ATIVO);
            if (emprestimosAtivos >= 3)
                throw new Exception("Usuário já possui 3 empréstimos ativos.");

            var prazo = usuario.Tipo == TipoUsuario.PROFESSOR ? 15 : 7;

            var novo = new Emprestimo
            {
                Id = _emprestimos.Count + 1,
                IdUsuario = idUsuario,
                ISBNLivro = isbn,
                DataEmprestimo = DateTime.Now,
                DataPrevistaDevolucao = DateTime.Now.AddDays(prazo)
            };

            _emprestimos.Add(novo);
            _livroService.AtualizarStatus(isbn, StatusLivro.EMPRESTADO);
        }

        public void RegistrarDevolucao(int idEmprestimo)
        {
            var emprestimo = _emprestimos.FirstOrDefault(e => e.Id == idEmprestimo)
                ?? throw new Exception("Empréstimo não encontrado.");

            if (emprestimo.Status != StatusEmprestimo.ATIVO)
                throw new Exception("Empréstimo já finalizado.");

            emprestimo.DataRealDevolucao = DateTime.Now;

            if (emprestimo.DataRealDevolucao > emprestimo.DataPrevistaDevolucao)
            {
                var diasAtraso = (emprestimo.DataRealDevolucao.Value - emprestimo.DataPrevistaDevolucao).Days;
                var multa = new Multa { IdEmprestimo = emprestimo.Id, Valor = diasAtraso * 1.0 };
                _multas.Add(multa);
                emprestimo.Status = StatusEmprestimo.ATRASADO;
            }
            else
            {
                emprestimo.Status = StatusEmprestimo.FINALIZADO;
            }

            _livroService.AtualizarStatus(emprestimo.ISBNLivro, StatusLivro.DISPONIVEL);
        }

        public IEnumerable<Multa> ListarMultas() => _multas;
    }
}
