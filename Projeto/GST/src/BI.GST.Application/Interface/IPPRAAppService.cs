using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IPPRAAppService : IDisposable
    {
        IEnumerable<PPRAViewModel> ObterTodos();

        PPRAViewModel ObterPorId(int id);

        bool Adicionar(PPRAViewModel pPRAViewModel);

        bool Atualizar(PPRAViewModel pPRAViewModel);

        bool Excluir(int id);

        IEnumerable<PPRAViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
