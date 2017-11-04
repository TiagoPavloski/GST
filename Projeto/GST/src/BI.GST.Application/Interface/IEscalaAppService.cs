using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
  public interface IEscalaAppService : IDisposable
  {
    IEnumerable<EscalaViewModel> ObterTodos();

    EscalaViewModel ObterPorId(int id);

    string Adicionar(EscalaViewModel escalaViewModel);

    string Atualizar(EscalaViewModel escalaViewModel);

    string Excluir(int id);

    IEnumerable<EscalaViewModel> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
