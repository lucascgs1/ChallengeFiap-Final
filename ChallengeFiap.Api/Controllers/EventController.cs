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
    /// <summary>
    /// controller de eventos
    /// </summary>
    [Route("api/")]
    [ApiController]
    public class EventController : ControllerBase
    {
        /// <summary>
        /// obtem os dados de evento
        /// </summary>
        /// <param name="eventoService">servico de eventos</param>
        /// <returns></returns>
        [HttpGet]
        [Route("eventos")]
        public ActionResult GetAll([FromServices] IEventoService eventoService)
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

        /// <summary>
        /// obtem os dados de um evento
        /// </summary>
        /// <param name="eventoService">servico de eventos</param>
        /// <param name="id">codigo do evento</param>
        /// <returns>dados do evento</returns>
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

        /// <summary>
        /// salva um novo evento
        /// </summary>
        /// <param name="eventoService">servico de evento</param>
        /// <param name="request">dados do evento novo</param>
        /// <returns></returns>
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

        /// <summary>
        /// atualiza os dados de um evento
        /// </summary>
        /// <param name="eventoService">servico de evento</param>
        /// <param name="request">dados do evento</param>
        /// <returns></returns>
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

        /// <summary>
        /// deleta um evento
        /// </summary>
        /// <param name="eventoService">servico de vento</param>
        /// <param name="id">codigo de evento</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("evento/remover/{id}")]
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
