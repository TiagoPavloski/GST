using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IFonteRiscoCBOService : IDisposable
    {
        IEnumerable<FonteRiscoCBO> ObterTodos();

        FonteRiscoCBO ObterPorId(int id);

        IEnumerable<FonteRiscoCBO> Find(Expression<Func<FonteRiscoCBO, bool>> predicate);

        void Adicionar(FonteRiscoCBO AgenteCausadorCBO);

        void Atualizar(FonteRiscoCBO AgenteCausadorCBO);

        void Excluir(int id);

        IEnumerable<FonteRiscoCBO> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
