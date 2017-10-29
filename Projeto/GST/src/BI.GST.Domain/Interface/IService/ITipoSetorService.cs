using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface ITipoSetorService : IDisposable
    {
        IEnumerable<TipoSetor> ObterTodos();

        TipoSetor ObterPorId(int id);

        IEnumerable<TipoSetor> Find(Expression<Func<TipoSetor, bool>> predicate);

        void Adicionar(TipoSetor TipoSetor);

        void Atualizar(TipoSetor TipoSetor);

        void Excluir(int id);

        IEnumerable<TipoSetor> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
