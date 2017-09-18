using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IEquipamentoRuidoService
    {
        IEnumerable<EquipamentoRuido> ObterTodos();

        EquipamentoRuido ObterPorId(int id);

        IEnumerable<EquipamentoRuido> Find(Expression<Func<EquipamentoRuido, bool>> predicate);

        void Adicionar(EquipamentoRuido equipamentoRuido);

        void Atualizar(EquipamentoRuido equipamentoRuido);

        void Excluir(int id);

        IEnumerable<EquipamentoRuido> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);

        void Dispose();
    }
}
