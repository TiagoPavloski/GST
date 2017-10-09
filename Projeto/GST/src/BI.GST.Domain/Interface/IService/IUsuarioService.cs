using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IUsuarioService : IDisposable
    {
        IEnumerable<Usuario> ObterTodos();

        Usuario ObterPorId(int id);

        IEnumerable<Usuario> Find(Expression<Func<Usuario, bool>> predicate);

        void Adicionar(Usuario Usuario);

        void Atualizar(Usuario Usuario);

        void Excluir(int id);

        IEnumerable<Usuario> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
