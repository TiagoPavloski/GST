using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
  public class PessoaViewModel
  {
    public string Nome { get; set; }

    public string CPF { get; set; }

    public string RG { get; set; }

    public string DataNascimento { get; set; }

    public string Email { get; set; }

    public virtual ICollection<TelefoneViewModel> Telefones { get; set; }
  }
}
