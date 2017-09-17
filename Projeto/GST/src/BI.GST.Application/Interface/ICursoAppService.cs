using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
  public interface ICursoAppService : IDisposable
  {
    IEnumerable<CursoViewModel> ObterTodos();

    CursoViewModel ObterPorId(int id);

    bool Adicionar(CursoViewModel cursoViewModel);

    bool Atualizar(CursoViewModel cursoViewModel);

    bool Excluir(int id);

    IEnumerable<CursoViewModel> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
