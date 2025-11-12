namespace BibliotecaAPI.Models
{
    public enum StatusMulta { PENDENTE, PAGA }

    public class Multa
    {
        public int IdEmprestimo { get; set; }
        public double Valor { get; set; }
        public StatusMulta Status { get; set; } = StatusMulta.PENDENTE;
    }
}
