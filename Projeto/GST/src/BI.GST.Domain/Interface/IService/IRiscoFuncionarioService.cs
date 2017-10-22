using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IRiscoFuncionarioService : IDisposable 
    {
        IEnumerable<RiscoFuncionario> ObterTodos();

        RiscoFuncionario ObterPorId(int id);

        IEnumerable<RiscoFuncionario> Find(Expression<Func<RiscoFuncionario, bool>> predicate);

        void Adicionar(RiscoFuncionario riscoFuncionario);

        void Atualizar(RiscoFuncionario riscoFuncionario);

        void Excluir(int id);

        IEnumerable<RiscoFuncionario> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
