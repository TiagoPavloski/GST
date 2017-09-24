using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IAgenteAcidenteService : IDisposable
    {
        IEnumerable<AgenteAcidente> ObterTodos();

        AgenteAcidente ObterPorId(int id);

        IEnumerable<AgenteAcidente> Find(Expression<Func<AgenteAcidente, bool>> predicate);

        void Adicionar(AgenteAcidente AgenteAcidente);

        void Atualizar(AgenteAcidente AgenteAcidente);

        void Excluir(int id);

        IEnumerable<AgenteAcidente> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
