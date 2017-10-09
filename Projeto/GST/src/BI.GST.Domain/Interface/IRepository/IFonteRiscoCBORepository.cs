using BI.GST.Domain.Entities;

using System.Collections.Generic;

namespace BI.GST.Domain.Interface.IRepository
{
    public interface IFonteRiscoCBORepository : IBaseRepository<FonteRiscoCBO>
    {
        IEnumerable<FonteRiscoCBO> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
