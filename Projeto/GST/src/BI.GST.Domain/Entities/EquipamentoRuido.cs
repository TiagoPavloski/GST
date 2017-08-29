using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class EquipamentoRuido
  {
    public int EquipamentoRuidoId { get; set; }

    public string MarcaEquipamento { get; set; }

    public string ModeloEquipamento { get; set; }

    public string Compensacao { get; set; }

    public string Resposta { get; set; }

    public int Status { get; set; }

    public bool Delete { get; set; }
  }
}
