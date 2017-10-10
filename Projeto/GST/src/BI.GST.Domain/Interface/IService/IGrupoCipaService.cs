using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;
using System.Linq.Expressions;

namespace BI.GST.Domain.Interface.IService
{
    public interface IGrupoCipaService : IDisposable
    {
        IEnumerable<GrupoCipa> ObterTodos();

        GrupoCipa ObterPorId(int id);

        IEnumerable<GrupoCipa> Find(Expression<Func<GrupoCipa, bool>> predicate);
    }
}
