using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace BI.GST.Application.Interface
{
    public interface ICIPAEmpresaFuncionarioAppService : IDisposable
    {
        CIPAEmpresaFuncionarioViewModel ObterPorId(int id);

        bool Adicionar(CIPAEmpresaFuncionarioViewModel cipaEmpresaFuncionarioViewModel);

        bool Atualizar(CIPAEmpresaFuncionarioViewModel cipaEmpresaFuncionarioViewModel);

        bool Excluir(int id);

        IEnumerable<CIPAEmpresaFuncionarioViewModel> ObterGrid(int page, string pesquisa, int cipaEmpresaId);

        int ObterTotalRegistros(string pesquisa, int cipaEmpresaId);

        IEnumerable<CIPAEmpresaFuncionarioViewModel> BuscarFuncionarioCIPAPorEmpresa(int empresaId, int FuncionarioId);
    }
}
