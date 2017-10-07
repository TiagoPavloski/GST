using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace BI.GST.Domain.Interface.IService
{
    public interface ICIPAEmpresaService : IDisposable
    {
        IEnumerable<CIPAEmpresa> ObterTodos();

        CIPAEmpresa ObterPorId(int id);

        IEnumerable<CIPAEmpresa> Find(Expression<Func<CIPAEmpresa, bool>> predicate);

        void Adicionar(CIPAEmpresa cIPAEmpresa);

        void Atualizar(CIPAEmpresa cIPAEmpresa);

        void Excluir(int id);

        IEnumerable<CIPAEmpresa> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
