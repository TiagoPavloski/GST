using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IFuncionarioEmpresaService : IDisposable
    {
        IEnumerable<FuncionarioEmpresa> ObterTodos();

        FuncionarioEmpresa ObterPorId(int id);

        IEnumerable<FuncionarioEmpresa> Find(Expression<Func<FuncionarioEmpresa, bool>> predicate);

        void Adicionar(FuncionarioEmpresa funcionarioEmpresa);

        void Atualizar(FuncionarioEmpresa funcionarioEmpresa);

        void Excluir(int id);

        IEnumerable<FuncionarioEmpresa> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
