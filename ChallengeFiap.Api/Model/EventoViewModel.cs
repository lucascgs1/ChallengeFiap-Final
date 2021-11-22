using ChallengeFiap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeFiap.Api.Model
{
  public class EventoViewModel
  {
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Local { get; set; }
    public DateTime Data { get; set; }
    public int QuantidadeMaximaPessoas { get; set; }
    public List<Participante> Participantes { get; set; }
    public bool Gratuito { get; set; }
    public string Descricao { get; set; }
    public string Categoria { get; set; }
    public string Organizador { get; set; }
  }
}
