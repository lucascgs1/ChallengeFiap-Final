using ChallengeFiap.Model;

using System.Threading.Tasks;
using System.Collections.Generic;

namespace ChallengeFiap.Services.Interfaces
{
  public interface IUsuarioServices
  {
    Task<Usuario> AuthenticateAsync(string email, string senha);
    Task<Usuario> GetByIdAsync(int id);
    Usuario GetById(int id);
    IEnumerable<Usuario> GetAllUsuarios();
    Usuario Save(Usuario usuario, int usuarioId = 0);
    void DeleteUsuarioById(int usuarioId);
  }
}
