using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiap.Model
{
  public class Cidade
  {
    [Key]
    public int Id { get; set; }
    public int EstadoId { get; set; }
    public string Nome { get; set; }
  }
}
