using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IEPIAppService : IDisposable
    {
        IEnumerable<EPIViewModel> ObterTodos();

        EPIViewModel ObterPorId(int id);

        bool Adicionar(EPIViewModel agentCausadorCBOViewModel);

        bool Atualizar(EPIViewModel agentCausadorCBOViewModel);

        bool Excluir(int id);

        IEnumerable<EPIViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
