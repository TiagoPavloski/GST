using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IMeioPropagacaoAppService : IDisposable
    {
        IEnumerable<MeioPropagacaoViewModel> ObterTodos();

        MeioPropagacaoViewModel ObterPorId(int id);

        bool Adicionar(MeioPropagacaoViewModel meioPropagacaoViewModel);

        bool Atualizar(MeioPropagacaoViewModel meioPropagacaoViewModel);

        bool Excluir(int id);

        IEnumerable<MeioPropagacaoViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
