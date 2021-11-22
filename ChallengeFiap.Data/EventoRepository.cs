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

    public bool CriarEvento(Evento evento)
    {

      var entity = Db.Evento.FirstOrDefault(x => x.Id == evento.Id);

      entity.Local = evento.Local;
      entity.Nome = evento.Nome;
      entity.Organizador = evento.Organizador;
      entity.Participantes = evento.Participantes;
      entity.QuantidadeMaximaPessoas = evento.QuantidadeMaximaPessoas;
      entity.Gratuito = evento.Gratuito;
      entity.Descricao = evento.Descricao;
      entity.Categoria = evento.Categoria;
      entity.Data = evento.Data;
            
      var resultado = Db.SaveChanges();

      if (resultado > 0)
        return true;
      else
        return false;
    }

    public bool EditarEvento(Evento evento)
    {
      Db.Evento.Add(evento);
      var resultado = Db.SaveChanges();

      if (resultado > 0)
        return true;
      else
        return false;
    }

    public IEnumerable<Evento> ListarEventos()
    {
      return Db.Evento.Where(x => x.Id > 0);
    }

    public Evento ListarEventos(long id)
    {
      return Db.Evento.FirstOrDefault(x => x.Id == id);
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
