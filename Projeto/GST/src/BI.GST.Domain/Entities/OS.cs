using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class OS
  {
    public int OsId { get; set; }

    public virtual Funcionario Funcionario { get; set; }

    public virtual Empresa Empresa { get; set; }

    public virtual Colaborador Colaborador { get; set; }

    public string Nome { get; set; }

    public string Descricao { get; set; }

    public virtual TipoCurso TipoCurso { get; set; }

    public string Emissao { get; set; }

    public int Status { get; set; }

    public bool Delete { get; set; }
  }
}
