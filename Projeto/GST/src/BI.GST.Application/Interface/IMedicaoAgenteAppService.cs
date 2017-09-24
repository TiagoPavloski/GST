using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IMedicaoAgenteAppService : IDisposable
    {
        IEnumerable<MedicaoAgenteViewModel> ObterTodos();

        MedicaoAgenteViewModel ObterPorId(int id);

        bool Adicionar(MedicaoAgenteViewModel medicaoAgenteViewModel);

        bool Atualizar(MedicaoAgenteViewModel medicaoAgenteViewModel);

        bool Excluir(int id);

        IEnumerable<MedicaoAgenteViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
