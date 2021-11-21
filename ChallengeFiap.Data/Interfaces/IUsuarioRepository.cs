using ChallengeFiap.Model;

using System.Threading.Tasks;

namespace ChallengeFiap.Data.Interfaces
{
  public interface IUsuarioRepository : IRepository<Usuario>
  {
    Task<Usuario> GetByEmail(string email);

    Task<Usuario> GetByIdAsync(int id);
  }
}
