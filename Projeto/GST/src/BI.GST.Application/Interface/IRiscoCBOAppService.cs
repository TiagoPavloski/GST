using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
  public interface IRiscoCBOAppService : IDisposable
  {
    IEnumerable<RiscoCBOViewModel> ObterTodos();

    RiscoCBOViewModel ObterPorId(int id);

    bool Adicionar(RiscoCBOViewModel riscoCBOViewModel);

    bool Atualizar(RiscoCBOViewModel riscoCBOViewModel);

    bool Excluir(int id);

    IEnumerable<RiscoCBOViewModel> ObterGrid(int page);

    int ObterTotalRegistros();
  }
}
