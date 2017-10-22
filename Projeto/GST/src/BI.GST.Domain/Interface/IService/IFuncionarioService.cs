using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IFuncionarioService : IDisposable
    {
        IEnumerable<Funcionario> ObterTodos();

        Funcionario ObterPorId(int id);

        IEnumerable<Funcionario> Find(Expression<Func<Funcionario, bool>> predicate);

        void Adicionar(Funcionario funcionario);

        void Atualizar(Funcionario funcionario);

        void Excluir(int id);

        IEnumerable<Funcionario> ObterGrid(string pesquisa, int page);

        IEnumerable<Funcionario> ObterPorEmpresa(int empresaId);

        int ObterTotalRegistros(string pesquisa);
    }
}
