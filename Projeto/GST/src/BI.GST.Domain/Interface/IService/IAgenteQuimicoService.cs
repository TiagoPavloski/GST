using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IAgenteQuimicoService : IDisposable
    {
        IEnumerable<AgenteQuimico> ObterTodos();

        AgenteQuimico ObterPorId(int id);

        IEnumerable<AgenteQuimico> Find(Expression<Func<AgenteQuimico, bool>> predicate);

        void Adicionar(AgenteQuimico AgenteQuimico);

        void Atualizar(AgenteQuimico AgenteQuimico);

        void Excluir(int id);

        IEnumerable<AgenteQuimico> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
