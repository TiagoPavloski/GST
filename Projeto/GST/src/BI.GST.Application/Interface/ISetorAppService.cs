using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface ISetorAppService : IDisposable
    {
        IEnumerable<SetorViewModel> ObterTodos();

        SetorViewModel ObterPorId(int id);

        bool Adicionar(SetorViewModel setorViewModel);

        bool Atualizar(SetorViewModel setorViewModel);

        bool Excluir(int id);

        IEnumerable<SetorViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
