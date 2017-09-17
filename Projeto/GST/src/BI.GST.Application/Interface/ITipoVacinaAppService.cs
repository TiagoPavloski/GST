using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
  public interface ITipoVacinaAppService : IDisposable
  {
    IEnumerable<TipoVacinaViewModel> ObterTodos();

    TipoVacinaViewModel ObterPorId(int id);

    bool Adicionar(TipoVacinaViewModel tipoCursoViewModel);

    bool Atualizar(TipoVacinaViewModel tipoCursoViewModel);

    bool Excluir(int id);

    IEnumerable<TipoVacinaViewModel> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
