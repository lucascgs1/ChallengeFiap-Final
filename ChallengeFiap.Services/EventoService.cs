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

    public Evento CriarEvento(Evento evento)
    {
      _eventoService.Add(evento);
      _eventoService.SaveChanges();
      return evento;
    }

    public Evento EditarEvento(Evento evento)
    {
      var entity = _eventoService.FindFirstBy(x => x.Id == evento.Id);
      if (entity == null) throw new Exception("Evento não encontrado para editar!");

      entity.Gratuito = evento.Gratuito;
      entity.Id = evento.Id;
      entity.Local = evento.Local;
      entity.Nome = evento.Nome;
      entity.Organizador = evento.Organizador;
      entity.Participantes = evento.Participantes;
      entity.QuantidadeMaximaPessoas = evento.QuantidadeMaximaPessoas;

      _eventoService.Update(entity);

      return entity;
    }

    public IEnumerable<Evento> ListarEventos()
    {
      return _eventoService.GetAll();
    }

    public Evento ListarEventos(long id)
    {
      var evento = _eventoService.FindFirstBy(x => x.Id == id);

      if (evento == null)
        throw new Exception("Evento não encontrado!");

      return evento;
    }

    public bool RemoverEventos(long id)
    {
      var evento = _eventoService.FindFirstBy(x => x.Id == id);
      return _eventoService.RemoverEventos(evento);
    }

    public Evento AdicionarParticipanteEvento(Participante participante)
    {
      var evento = _eventoService.FindFirstBy(x => x.Id == participante.EventoId);

      if (evento == null) throw new Exception("Evento não encontrado!");

      evento.Participantes.Add(participante);

      _eventoService.Update(evento);

      return evento;
    }

  }
}
