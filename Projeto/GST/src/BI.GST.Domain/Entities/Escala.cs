using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class Escala
  {
    public int EscalaId { get; set; }

    public string Nome { get; set; }

    public string HoraAlmoco { get; set; }

    public bool Delete { get; set; }
  }
}
