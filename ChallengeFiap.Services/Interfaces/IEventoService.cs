using ChallengeFiap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiap.Services.Interfaces
{
  public interface IEventoService
  {
    Evento CriarEvento(Evento evento);
    IEnumerable<Evento> ListarEventos();
    Evento ListarEventos(long id);
    bool RemoverEventos(long id);
    Evento EditarEvento(Evento evento);
    Evento AdicionarParticipanteEvento(Participante participante);
  }
}
