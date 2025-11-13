namespace BibliotecaAPI.Models
{
    public enum Categoria { FICCAO, TECNICO, DIDATICO }

    public class Prompt
    {
        public string Instrução { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public Categoria Categoria { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
