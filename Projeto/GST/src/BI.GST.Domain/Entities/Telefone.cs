using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class Telefone
  {
    public int TelefoneId { get; set; }

    public string Numero { get; set; }

    public bool Delete { get; set; }
  }
}
