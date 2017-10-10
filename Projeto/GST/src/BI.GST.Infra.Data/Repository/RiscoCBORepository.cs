using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace BI.GST.Infra.Data.Repository
{
    public class RiscoCBORepository : BaseRepository<RiscoCBO>, IRiscoCBORepository
    {
        public int ObterTotalRegistros()
        {
            return DbSet.Count(x => x.Delete == false);
        }

        public IEnumerable<RiscoCBO> ObterGrid(int page)
        {
            return DbSet.Where(x => x.Delete == false)
                       .OrderBy(u => u.RiscoCBOId)
                       .Skip((page) * 10)
                       .Take(10);
        }
    }
}
