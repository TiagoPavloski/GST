using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
  public interface ITipoCursoAppService : IDisposable
  {
    IEnumerable<TipoCursoViewModel> ObterTodos();

    TipoCursoViewModel ObterPorId(int id);

    bool Adicionar(TipoCursoViewModel tipoCursoViewModel);

    bool Atualizar(TipoCursoViewModel tipoCursoViewModel);

    string Excluir(int id);

    IEnumerable<TipoCursoViewModel> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
