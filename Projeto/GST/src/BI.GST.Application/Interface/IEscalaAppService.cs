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

    bool Adicionar(EscalaViewModel escalaViewModel);

    bool Atualizar(EscalaViewModel escalaViewModel);

    bool Excluir(int id);

    IEnumerable<EscalaViewModel> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
