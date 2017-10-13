using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface  IColaboradorService : IDisposable
    {
        IEnumerable<Colaborador> ObterTodos();

        Colaborador ObterPorId(int id);

        IEnumerable<Colaborador> Find(Expression<Func<Colaborador, bool>> predicate);

        void Adicionar(Colaborador colaborador);

        void Atualizar(Colaborador colaborador);

        void Excluir(int id);

        IEnumerable<Colaborador> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
