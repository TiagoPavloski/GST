using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class Pessoa
  {
    public string Nome { get; set; }

    public string CPF { get; set; }

    public string RG { get; set; }

    public string DataNascimento { get; set; }

    public string Email { get; set; }

    public string PIS { get; set; }

	public string CLT { get; set; }

	public string Serie { get; set; }

    public virtual ICollection<Telefone> Telefones { get; set; }
  }
}
