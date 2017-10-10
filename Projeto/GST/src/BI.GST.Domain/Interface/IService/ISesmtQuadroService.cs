using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;
using System.Linq.Expressions;

namespace BI.GST.Domain.Interface.IService
{
    public interface ISesmtQuadroService : IDisposable
    {
        IEnumerable<SesmtQuadro> ObterTodos();

        SesmtQuadro ObterPorId(int id);

        IEnumerable<SesmtQuadro> Find(Expression<Func<SesmtQuadro, bool>> predicate);
    }
}
