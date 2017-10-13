using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
  public interface IFuncionarioAppService : IDisposable
  {
    IEnumerable<FuncionarioViewModel> ObterTodos();

    FuncionarioViewModel ObterPorId(int id);

    bool Adicionar(FuncionarioViewModel funcionarioViewModel, int[] ExameId, int[] VacinaId, int[] CursoId);

    bool Atualizar(FuncionarioViewModel funcionarioViewModel, int[] ExameId, int[] VacinaId, int[] CursoId);

    bool Excluir(int id);

    IEnumerable<FuncionarioViewModel> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
