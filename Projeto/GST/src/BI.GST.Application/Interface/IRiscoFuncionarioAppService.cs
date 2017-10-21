using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IRiscoFuncionarioAppService : IDisposable
    {
        IEnumerable<RiscoFuncionarioViewModel> ObterTodos();

        RiscoFuncionarioViewModel ObterPorId(int id);

        bool Adicionar(RiscoFuncionarioViewModel riscoFuncionarioViewModel);

        bool Atualizar(RiscoFuncionarioViewModel riscoFuncionarioViewModel);

        bool Excluir(int id);

        IEnumerable<RiscoFuncionarioViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
