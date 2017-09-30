using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace BI.GST.Application.Interface
{
    public interface IAnexoAppService : IDisposable
    {
        IEnumerable<AnexoViewModel> ObterTodos(int idPPRA);

        AnexoViewModel ObterPorId(int id);

        bool Adicionar(AnexoViewModel anexoViewModel);

        bool Atualizar(AnexoViewModel anexoViewModel);

        bool Excluir(int id);

        IEnumerable<AnexoViewModel> ObterGrid(int page, string pesquisa, int idPPRA);

        int ObterTotalRegistros(string pesquisa, int idPPRA);

    }
}
