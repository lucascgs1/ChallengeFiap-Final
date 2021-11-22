using ChallengeFiap.Data.Context;
using ChallengeFiap.Data.Interfaces;
using ChallengeFiap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiap.Data
{
  public class EventoRepository : Repository<Evento>, IEventoRepository
  {

    private readonly ApplicationDbContext _context;
    public EventoRepository(ApplicationDbContext context) : base(context)
    {
      _context = context;
    }

    public bool RemoverEventos(Evento evento)
    {
      Db.Evento.Remove(evento);
      var resultado = Db.SaveChanges();

      if (resultado > 0)
        return true;
      else
        return false;
    }
  }
}
