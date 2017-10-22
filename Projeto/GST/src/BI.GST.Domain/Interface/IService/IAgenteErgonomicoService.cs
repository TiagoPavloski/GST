using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IAgenteErgonomicoService : IDisposable
    {
        IEnumerable<AgenteErgonomico> ObterTodos();

        AgenteErgonomico ObterPorId(int id);

        IEnumerable<AgenteErgonomico> Find(Expression<Func<AgenteErgonomico, bool>> predicate);

        void Adicionar(AgenteErgonomico agenteErgonomico);

        void Atualizar(AgenteErgonomico agenteErgonomico);

        void Excluir(int id);

        IEnumerable<AgenteErgonomico> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
