using ChallengeFiap.Data.Interfaces;
using ChallengeFiap.Model;
using ChallengeFiap.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiap.Services
{
  public class EventoService : IEventoService
  {
    private IEventoRepository _eventoService;
    public EventoService(IEventoRepository eventoService)
    {
      _eventoService = eventoService;
    }

    public bool CriarEvento(Evento evento)
    {
      return _eventoService.CriarEvento(evento);
    }

    public bool EditarEvento(Evento evento)
    {
      return _eventoService.EditarEvento(evento);
    }

    public IEnumerable<Evento> ListarEventos()
    {
      return _eventoService.ListarEventos();
    }

    public Evento ListarEventos(long id)
    {
      return _eventoService.ListarEventos(id);
    }

    public bool RemoverEventos(Evento evento)
    {
      return _eventoService.RemoverEventos(evento);
    }
  }
}
