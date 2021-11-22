using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiap.Model
{
  public class Participante
  {
    [Key]
    public long Id { get; set; }
    public long EventoId { get; set; }
    public long UsuarioId { get; set; }

  }
}
