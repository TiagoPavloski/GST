using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface ICronogramaDeAcoesService : IDisposable
    {
        IEnumerable<CronogramaDeAcoes> ObterTodos();

        CronogramaDeAcoes ObterPorId(int id);

        IEnumerable<CronogramaDeAcoes> Find(Expression<Func<CronogramaDeAcoes, bool>> predicate);

        void Adicionar(CronogramaDeAcoes cronogramaDeAcoes);

        void Atualizar(CronogramaDeAcoes cronogramaDeAcoes);

        void Excluir(int id);

        IEnumerable<CronogramaDeAcoes> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
