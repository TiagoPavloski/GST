using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;


namespace BI.GST.Application.Interface
{
    public interface IColaboradorAppService : IDisposable
    {
        IEnumerable<ColaboradorViewModel> ObterTodos();

        ColaboradorViewModel ObterPorId(int id);

        bool Adicionar(ColaboradorViewModel colaboradorViewModel);

        bool Atualizar(ColaboradorViewModel colaboradorViewModel);

        bool Excluir(int id);

        IEnumerable<ColaboradorViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);

        IEnumerable<ColaboradorViewModel> ObterTodosPorEmpresa(int EmpresaId);
    }
}
