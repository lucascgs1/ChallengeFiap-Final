using ChallengeFiap.Data.Interfaces;
using ChallengeFiap.Model;
using ChallengeFiap.Services.Interfaces;
using System;
using System.Collections.Generic;


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
      var evento = _eventoService.ListarEventos(id);

      if (evento == null)
        throw new Exception("Evento não encontrado!");

      return evento;
    }

    public bool RemoverEventos(long id)
    {
      var evento = _eventoService.FindFirstBy(x => x.Id == id);
      return _eventoService.RemoverEventos(evento);
    }

  }
}
