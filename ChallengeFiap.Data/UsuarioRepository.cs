using Microsoft.EntityFrameworkCore;

using ChallengeFiap.Model;
using ChallengeFiap.Data.Context;
using ChallengeFiap.Data.Interfaces;

using System.Threading.Tasks;

namespace ChallengeFiap.Data
{
  public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
  {
    private readonly ApplicationDbContext _context;

    public UsuarioRepository(ApplicationDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<Usuario> GetByEmail(string email)
    {
      return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
      return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }
  }
}
