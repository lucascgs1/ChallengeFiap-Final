using ChallengeFiap.Model;
using ChallengeFiap.Services.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace ChallengerFiap.Teste
{
  public class EventoTeste
  {
    IEventoService _eventoService;
    public EventoTeste(IEventoService eventoService)
    {
      _eventoService = eventoService;
    }

    [Test]
    public void DeveriaCriarEvento()
    {
      var evento = new Evento();
      evento.Id = 1;
      evento.Gratuito = false;
      evento.Local = "Av. Paulista 910";
      evento.Data = DateTime.Now;
      evento.Descricao = "Evento de teste da fiap";
      evento.Nome = "Challanger fiap";
      evento.QuantidadeMaximaPessoas = 100;

      var participante = new Participante();
      participante.Id = 1;
      participante.EventoId = 1;
      participante.UsuarioId = 1;


      var participantes = new List<Participante>() { participante };

      evento.Participantes = participantes;

      var resultado = _eventoService.CriarEvento(evento);

      Assert.IsTrue(resultado);
    }

    [Test]
    public void DeveriaDeletarEvento()
    {
      var resultado = _eventoService.RemoverEventos(1);

      Assert.IsTrue(resultado);
    }

    [Test]
    public void DeveriaEditarEvento()
    {
      var evento = new Evento();
      evento.Id = 1;
      evento.Gratuito = false;
      evento.Local = "Av. Paulista 910";
      evento.Data = DateTime.Now;
      evento.Descricao = "Evento de teste da fiap";
      evento.Nome = "Challanger fiap";
      evento.QuantidadeMaximaPessoas = 100;

      var participante = new Participante();
      participante.Id = 1;
      participante.EventoId = 1;
      participante.UsuarioId = 1;

      var participante2 = new Participante();
      participante2.Id = 2;
      participante2.EventoId = 1;
      participante2.UsuarioId = 2;


      var participantes = new List<Participante>() { participante };

      evento.Participantes = participantes;

      var resultado = _eventoService.EditarEvento(evento);

      Assert.IsTrue(resultado);

    }

  }
}
