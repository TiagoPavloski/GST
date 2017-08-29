using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class Certificado
  {
    public int CertificadoId { get; set; }

    public virtual Funcionario Funcionario { get; set; }

    public virtual Curso Curso { get; set; }

    public string DataEmissao { get; set; }

    public virtual OS OS { get; set; }

    public virtual InstituicaoCurso InstituicaoCurso { get; set; }

    public int Status { get; set; }

    public bool Delete { get; set; }
  }
}
