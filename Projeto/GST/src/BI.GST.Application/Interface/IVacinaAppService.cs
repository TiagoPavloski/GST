using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
  public interface IVacinaAppService : IDisposable
  {
    IEnumerable<VacinaViewModel> ObterTodos();

    VacinaViewModel ObterPorId(int id);

    bool Adicionar(VacinaViewModel tipoVacinaViewModel);

    bool Atualizar(VacinaViewModel tipoVacinaViewModel);

    bool Excluir(int id);

    IEnumerable<VacinaViewModel> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
