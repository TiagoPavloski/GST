using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class Exame
  {
    public int ExameId { get; set; }

    public virtual Funcionario Funcionario { get; set; }

    public virtual TipoExame TipoExame { get; set; }
    
    public string Data { get; set; }

    public int Status { get; set; }

    public bool Delete { get; set; }
  }
}
