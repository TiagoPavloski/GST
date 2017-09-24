using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IMeioPropagacaoService : IDisposable
    {
        IEnumerable<MeioPropagacao> ObterTodos();

        MeioPropagacao ObterPorId(int id);

        IEnumerable<MeioPropagacao> Find(Expression<Func<MeioPropagacao, bool>> predicate);

        void Adicionar(MeioPropagacao meioPropagacao);

        void Atualizar(MeioPropagacao meioPropagacao);

        void Excluir(int id);

        IEnumerable<MeioPropagacao> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
