using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface ISetorService : IDisposable
    {
        IEnumerable<Setor> ObterTodos();

        Setor ObterPorId(int id);

        IEnumerable<Setor> Find(Expression<Func<Setor, bool>> predicate);

        void Adicionar(Setor Setor);

        void Atualizar(Setor Setor);

        void Excluir(int id);

        IEnumerable<Setor> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
