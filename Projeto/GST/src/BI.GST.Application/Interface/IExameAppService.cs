using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
  public interface IExameAppService : IDisposable
  {
    IEnumerable<ExameViewModel> ObterTodos();

    ExameViewModel ObterPorId(int id);

    bool Adicionar(ExameViewModel tipoExameViewModel);

    bool Atualizar(ExameViewModel tipoExameViewModel);

    bool Excluir(int id);

    IEnumerable<ExameViewModel> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
