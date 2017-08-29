using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class MedicaoAgente
  {
    public int MedicaoAgenteId { get; set; }

    public string Data { get; set; }

    public string Medicao { get; set; }

    public string ItemDemonstraAmbientais { get; set; }

    public bool Delete { get; set; }
  }
}
