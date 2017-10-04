using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IPPRAService : IDisposable
    {
        IEnumerable<PPRA> ObterTodos();

        PPRA ObterPorId(int id);

        IEnumerable<PPRA> Find(Expression<Func<PPRA, bool>> predicate);

        void Adicionar(PPRA ppra);

        void Atualizar(PPRA ppra);

        void Excluir(int id);

        IEnumerable<PPRA> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
