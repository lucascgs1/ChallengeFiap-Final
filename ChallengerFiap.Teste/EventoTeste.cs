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


      var resultado = _eventoService.CriarEvento(evento);

      Assert.IsTrue(resultado);
    }
  }
}
