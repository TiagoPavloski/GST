using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class Cnae
  {
    public int CnaeId { get; set; }

    public string Codigo { get; set; }

    public string Descricao { get; set; }

    public string GrauDeRisco { get; set; }

    public bool Delete { get; set; }
  }
}
