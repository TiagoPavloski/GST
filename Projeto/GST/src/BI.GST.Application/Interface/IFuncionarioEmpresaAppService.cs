using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace BI.GST.Application.Interface
{
    public interface IFuncionarioEmpresaAppService : IDisposable
    {
        IEnumerable<FuncionarioEmpresaViewModel> ObterTodos();

        FuncionarioEmpresaViewModel ObterPorId(int id);

        bool Adicionar(FuncionarioEmpresaViewModel funcionarioEmpresaViewModel);

        bool Atualizar(FuncionarioEmpresaViewModel funcionarioEmpresaViewModel);

        bool Excluir(int id);

        IEnumerable<FuncionarioEmpresaViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
