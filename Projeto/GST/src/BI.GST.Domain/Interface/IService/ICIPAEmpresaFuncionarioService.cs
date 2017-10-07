using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface ICIPAEmpresaFuncionarioService : IDisposable
    {
        IEnumerable<CIPAEmpresaFuncionario> ObterTodos();

        CIPAEmpresaFuncionario ObterPorId(int id);

        IEnumerable<CIPAEmpresaFuncionario> Find(Expression<Func<CIPAEmpresaFuncionario, bool>> predicate);

        void Adicionar(CIPAEmpresaFuncionario cIPAEmpresaFuncionario);

        void Atualizar(CIPAEmpresaFuncionario cIPAEmpresaFuncionario);

        void Excluir(int id);

        IEnumerable<CIPAEmpresaFuncionario> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
