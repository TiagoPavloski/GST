using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IFonteRiscoCBOAppService : IDisposable
    {
        IEnumerable<FonteRiscoCBOViewModel> ObterTodos();

        FonteRiscoCBOViewModel ObterPorId(int id);

        bool Adicionar(FonteRiscoCBOViewModel fonteRiscoCBOViewModel);

        bool Atualizar(FonteRiscoCBOViewModel fonteRiscoCBOViewModel);

        bool Excluir(int id);

        IEnumerable<FonteRiscoCBOViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
