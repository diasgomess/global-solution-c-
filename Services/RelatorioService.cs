using BibliotecaAPI.Models;

namespace BibliotecaAPI.Services
{
    public class RelatorioService
    {
        private readonly EmprestimoService _emprestimoService;

        public RelatorioService(EmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }

        public IEnumerable<Emprestimo> ListarAtrasados() =>
            _emprestimoService.Listar().Where(e => e.Status == StatusEmprestimo.ATRASADO);
    }
}
