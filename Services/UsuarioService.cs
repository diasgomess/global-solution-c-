using BibliotecaAPI.Models;

namespace BibliotecaAPI.Services
{
    public class UsuarioService
    {
        private readonly List<Usuario> _usuarios = new();

        public IEnumerable<Usuario> Listar() => _usuarios;
        public Usuario? BuscarPorId(int id) => _usuarios.FirstOrDefault(u => u.Id == id);

        public void Cadastrar(Usuario usuario)
        {
            if (_usuarios.Any(u => u.Id == usuario.Id))
                throw new Exception("Usuário já cadastrado.");
            _usuarios.Add(usuario);
        }
    }
}
