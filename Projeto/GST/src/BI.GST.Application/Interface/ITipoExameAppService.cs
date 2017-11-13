using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
  public interface ITipoExameAppService : IDisposable
  {
    IEnumerable<TipoExameViewModel> ObterTodos();

    TipoExameViewModel ObterPorId(int id);

    bool Adicionar(TipoExameViewModel tipoCursoViewModel);

    bool Atualizar(TipoExameViewModel tipoCursoViewModel);

    string Excluir(int id);

    IEnumerable<TipoExameViewModel> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
