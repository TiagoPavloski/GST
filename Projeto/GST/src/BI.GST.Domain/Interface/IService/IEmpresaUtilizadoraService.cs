using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IEmpresaUtilizadoraService : IDisposable
    {
        IEnumerable<EmpresaUtilizadora> ObterTodos();

        EmpresaUtilizadora ObterPorId(int id);

        IEnumerable<EmpresaUtilizadora> Find(Expression<Func<EmpresaUtilizadora, bool>> predicate);

        void Adicionar(EmpresaUtilizadora empresaUtilizadora);

        void Atualizar(EmpresaUtilizadora empresaUtilizadora);

        void Excluir(int id);

        IEnumerable<EmpresaUtilizadora> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
