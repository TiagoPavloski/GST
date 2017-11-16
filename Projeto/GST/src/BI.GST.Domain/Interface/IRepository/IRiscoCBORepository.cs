using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IRepository
{
  public interface IRiscoCBORepository : IBaseRepository<RiscoCBO>
  {
    IEnumerable<RiscoCBO> ObterGrid(string pesquisa, int page);

    int ObterTotalRegistros();
  }
}
