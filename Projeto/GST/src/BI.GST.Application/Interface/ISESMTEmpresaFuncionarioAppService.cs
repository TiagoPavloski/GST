using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace BI.GST.Application.Interface
{
    public interface ISESMTEmpresaFuncionarioAppService : IDisposable
    {
        SESMTEmpresaFuncionarioViewModel ObterPorId(int id);

        bool Adicionar(SESMTEmpresaFuncionarioViewModel sesmtEmpresaFuncionarioViewModel);

        bool Atualizar(SESMTEmpresaFuncionarioViewModel sesmtEmpresaFuncionarioViewModel);

        bool Excluir(int id);

        IEnumerable<SESMTEmpresaFuncionarioViewModel> ObterGrid(int page, string pesquisa, int SESMTEmpresaId);

        int ObterTotalRegistros(string pesquisa, int SESMTEmpresaId);
    }
}
