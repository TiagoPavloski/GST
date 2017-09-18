using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IClassificacaoEfeitoService : IDisposable
    {
        IEnumerable<ClassificacaoEfeito> ObterTodos();

        ClassificacaoEfeito ObterPorId(int id);

        IEnumerable<ClassificacaoEfeito> Find(Expression<Func<ClassificacaoEfeito, bool>> predicate);

        void Adicionar(ClassificacaoEfeito ClassificacaoEfeito);

        void Atualizar(ClassificacaoEfeito ClassificacaoEfeito);

        void Excluir(int id);

        IEnumerable<ClassificacaoEfeito> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
