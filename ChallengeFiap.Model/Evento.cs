using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiap.Model
{
  public class Evento
  {

    [Key]
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Local { get; set; }
    public DateTime Data { get; set; }
    public int QuantidadeMaximaPessoas { get; set; }
    public List<Usuario> QuantidadePessoasConfirmada { get; set; }
    public List<Usuario> QuantidadePessoasTalvez { get; set; }
    public bool Gratuito { get; set; }
    public string Descricao { get; set; }
    public string Categoria { get; set; }


  }
}
