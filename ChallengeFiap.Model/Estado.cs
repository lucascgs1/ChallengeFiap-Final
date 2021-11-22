using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiap.Model
{
  public class Estado
  {
    [Key]
    public int Id { get; set; }
    public string Sigla { get; set; }
    public string Nome { get; set; }
    public List<Cidade> Cidades { get; set; }
  }
}
