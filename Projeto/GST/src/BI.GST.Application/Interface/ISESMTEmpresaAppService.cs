using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace BI.GST.Application.Interface
{
    public interface ISESMTEmpresaAppService : IDisposable
    {
        IEnumerable<SESMTEmpresaViewModel> ObterTodos();

        SESMTEmpresaViewModel ObterPorId(int id);

        bool Adicionar(SESMTEmpresaViewModel sesmtEmpresaViewModel);

        bool Atualizar(SESMTEmpresaViewModel sesmtEmpresaViewModel);

        bool Excluir(int id);

        IEnumerable<SESMTEmpresaViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
