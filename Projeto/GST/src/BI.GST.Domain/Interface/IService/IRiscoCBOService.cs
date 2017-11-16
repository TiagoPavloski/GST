using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IRiscoCBOService : IDisposable
    {
        IEnumerable<RiscoCBO> ObterTodos();

        RiscoCBO ObterPorId(int id);

        IEnumerable<RiscoCBO> Find(Expression<Func<RiscoCBO, bool>> predicate);

        void Adicionar(RiscoCBO riscoCBO);

        void Atualizar(RiscoCBO riscoCBO);

        void Excluir(int id);

        IEnumerable<RiscoCBO> ObterGrid(string pesquisa, int page);

        int ObterTotalRegistros();
    }
}

