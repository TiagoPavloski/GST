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

        public IEnumerable<RiscoCBO> ObterGrid(string pesquisa, int page)
        {
            return DbSet.Where(x => (pesquisa != null ? x.Nome.Contains(pesquisa) : x.Nome != null) && (x.Delete == false))
                      .OrderBy(u => u.Nome)
                      .Skip((page) * 10)
                      .Take(10);
        }
    }
}
