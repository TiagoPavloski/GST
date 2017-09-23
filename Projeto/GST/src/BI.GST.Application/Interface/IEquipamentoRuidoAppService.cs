using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IEquipamentoRuidoAppService : IDisposable
    {
        IEnumerable<EquipamentoRuidoViewModel> ObterTodos();

        EquipamentoRuidoViewModel ObterPorId(int id);

        bool Adicionar(EquipamentoRuidoViewModel equipamentoRuidoViewModel);

        bool Atualizar(EquipamentoRuidoViewModel equipamentoRuidoViewModel);

        bool Excluir(int id);

        IEnumerable<EquipamentoRuidoViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
