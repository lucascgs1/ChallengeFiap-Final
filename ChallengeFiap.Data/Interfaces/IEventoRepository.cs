using ChallengeFiap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiap.Data.Interfaces
{
  public interface IEventoRepository : IRepository<Evento>
  {
    bool CriarEvento(Evento evento);
    IEnumerable<Evento> ListarEventos();
    Evento ListarEventos(long id);
    bool RemoverEventos(Evento evento);
    bool EditarEvento(Evento evento);
  }
}
