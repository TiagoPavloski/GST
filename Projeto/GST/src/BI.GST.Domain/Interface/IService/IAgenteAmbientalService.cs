using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IAgenteAmbientalService
    {
        IEnumerable<AgenteAmbiental> ObterTodos();

        AgenteAmbiental ObterPorId(int id);

        IEnumerable<AgenteAmbiental> Find(Expression<Func<AgenteAmbiental, bool>> predicate);

        void Adicionar(AgenteAmbiental agenteAmbiental);

        void Atualizar(AgenteAmbiental agenteAmbiental);

        void Excluir(int id);

        IEnumerable<AgenteAmbiental> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
        void Dispose();
    }
}
