using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IAgenteRiscoCBOService : IDisposable
    {
        IEnumerable<AgenteRiscoCBO> ObterTodos();

        AgenteRiscoCBO ObterPorId(int id);

        IEnumerable<AgenteRiscoCBO> Find(Expression<Func<AgenteRiscoCBO, bool>> predicate);

        void Adicionar(AgenteRiscoCBO AgenteRiscoCBO);

        void Atualizar(AgenteRiscoCBO AgenteRiscoCBO);

        void Excluir(int id);

        IEnumerable<AgenteRiscoCBO> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
