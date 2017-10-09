using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace BI.GST.Domain.Interface.IService
{
    public interface ISESMTEmpresaFuncionarioService : IDisposable
    {
        IEnumerable<SESMTEmpresaFuncionario> ObterTodos();

        SESMTEmpresaFuncionario ObterPorId(int id);

        IEnumerable<SESMTEmpresaFuncionario> Find(Expression<Func<SESMTEmpresaFuncionario, bool>> predicate);

        void Adicionar(SESMTEmpresaFuncionario sESMTEmpresaFuncionario);

        void Atualizar(SESMTEmpresaFuncionario sESMTEmpresaFuncionario);

        void Excluir(int id);

        IEnumerable<SESMTEmpresaFuncionario> ObterGrid(int page, string pesquisa, int SESMTEmpresaId);

        int ObterTotalRegistros(string pesquisa, int SESMTEmpresaId);
    }
}
