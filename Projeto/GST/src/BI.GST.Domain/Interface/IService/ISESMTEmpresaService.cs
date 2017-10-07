using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface ISESMTEmpresaService : IDisposable
    {
        IEnumerable<SESMTEmpresa> ObterTodos();

        SESMTEmpresa ObterPorId(int id);

        IEnumerable<SESMTEmpresa> Find(Expression<Func<SESMTEmpresa, bool>> predicate);

        void Adicionar(SESMTEmpresa sESMTEmpresa);

        void Atualizar(SESMTEmpresa sESMTEmpresa);

        void Excluir(int id);

        IEnumerable<SESMTEmpresa> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
