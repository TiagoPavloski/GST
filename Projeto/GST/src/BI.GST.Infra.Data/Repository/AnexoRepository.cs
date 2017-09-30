using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.Repository
{
    public class AnexoRepository : BaseRepository<Anexo>, IAnexoRepository
    {
        public IEnumerable<Anexo> ObterGrid(int page, string pesquisa, int idPPRA)
        {
            return DbSet.Where(x => (pesquisa != null ? x.Nome.Contains(pesquisa) : x.Nome != null) && (x.Delete == false)
                && (x.PPRAId == idPPRA))
               .OrderBy(u => u.Nome)
               .Skip((page) * 10)
               .Take(10);
        }

        public IEnumerable<Anexo> ObterTodos(int idPPRA)
        {
            return DbSet.Where(x => (x.Delete == false)
               && (x.PPRAId == idPPRA));
        }

        public int ObterTotalRegistros(string pesquisa, int idPPRA)
        {
            return DbSet.Count(x => (pesquisa != null ? x.Nome.Contains(pesquisa) : x.Nome != null) && (x.Delete == false)
                && (x.PPRAId == idPPRA));
        }
    }
}
