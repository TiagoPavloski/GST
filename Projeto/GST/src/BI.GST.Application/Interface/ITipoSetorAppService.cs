using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface ITipoSetorAppService : IDisposable
    {
        IEnumerable<TipoSetorViewModel> ObterTodos();

        TipoSetorViewModel ObterPorId(int id);

        bool Adicionar(TipoSetorViewModel tipoSetorViewModel);

        bool Atualizar(TipoSetorViewModel tipoSetorViewModel);

        bool Excluir(int id);

        IEnumerable<TipoSetorViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
