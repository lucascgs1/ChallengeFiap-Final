using ChallengeFiap.Api.Model;
using ChallengeFiap.Model;
using ChallengeFiap.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeFiap.Api.Controllers
{
  [Route("api/")]
  [ApiController]
  public class EventController : ControllerBase
  {

    [HttpGet]
    [Route("eventos")]
    public ActionResult Get([FromServices] IEventoService eventoService)
    {
      try
      {
        return Ok(eventoService.ListarEventos());
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }


    [HttpGet]
    [Route("evento/{id}")]
    [Authorize]
    public ActionResult Get([FromServices] IEventoService eventoService, long id)
    {
      try
      {
        return Ok(eventoService.ListarEventos(id));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }

    }


    [HttpPost]
    [Route("evento/criar")]
    public ActionResult Post([FromServices] IEventoService eventoService, [FromBody] EventoViewModel request)
    {
      try
      {
        Evento ev = new Evento();


        ev.Categoria = request.Categoria;
        ev.Data = request.Data;
        ev.Descricao = request.Descricao;
        ev.Gratuito = request.Gratuito;
        ev.Local = request.Local;
        ev.Nome = request.Nome;
        ev.Organizador = request.Organizador;
        ev.Participantes = request.Participantes != null ? request.Participantes : new List<Participante>();
        ev.QuantidadeMaximaPessoas = request.QuantidadeMaximaPessoas;

        return Ok(eventoService.CriarEvento(ev));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }


    [HttpPut]
    [Route("evento/editar")]
    public ActionResult Put([FromServices] IEventoService eventoService, [FromBody] EventoViewModel request)
    {
      try
      {
        Evento ev = new Evento();
        ev.Categoria = request.Categoria;
        ev.Data = request.Data;
        ev.Descricao = request.Descricao;
        ev.Gratuito = request.Gratuito;
        ev.Local = request.Local;
        ev.Nome = request.Nome;
        ev.Organizador = request.Organizador;
        ev.Participantes = request.Participantes;
        ev.QuantidadeMaximaPessoas = request.QuantidadeMaximaPessoas;
        ev.Id = request.Id;

        return Ok(eventoService.EditarEvento(ev));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }


    [HttpDelete("evento/remover/{id}")]
    [Route("evento/editar")]
    public ActionResult Delete([FromServices] IEventoService eventoService, long id)
    {
      try
      {
        return Ok(eventoService.RemoverEventos(id));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
