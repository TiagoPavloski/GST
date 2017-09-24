using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.Repository
{
    public class MedicaoAgenteRepository : BaseRepository<MedicaoAgente>, IMedicaoAgenteRepository
    {
        public int ObterTotalRegistros(string pesquisa)
        {
            return DbSet.Count(x => (pesquisa != null ? x.Medicao.Contains(pesquisa) : x.Medicao != null) && (x.Delete == false));
        }

        public IEnumerable<MedicaoAgente> ObterGrid(int page, string pesquisa)
        {
            return DbSet.Where(x => (pesquisa != null ? x.Medicao.Contains(pesquisa) : x.Medicao != null) && (x.Delete == false))
                       .OrderBy(u => u.Medicao)
                       .Skip((page) * 10)
                       .Take(10);
        }
    }
}
