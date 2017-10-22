using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace BI.GST.Application.Interface
{
    public interface IFuncionarioAppService : IDisposable
    {
        IEnumerable<FuncionarioViewModel> ObterTodos();

        FuncionarioViewModel ObterPorId(int id);

        bool Adicionar(FuncionarioViewModel funcionarioViewModel);

        bool Atualizar(FuncionarioViewModel funcionarioViewModel);

        bool Excluir(int id);

        IEnumerable<FuncionarioViewModel> ObterGrid(string pesquisa, int page);

        int ObterTotalRegistros(string pesquisa);
    }
}
