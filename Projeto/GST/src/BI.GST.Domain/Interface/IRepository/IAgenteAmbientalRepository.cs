using BI.GST.Domain.Entities;
using System.Collections.Generic;

namespace BI.GST.Domain.Interface.IRepository
{
    public interface IAgenteAmbientalRepository: IBaseRepository<AgenteAmbiental>
    {
        IEnumerable<AgenteAmbiental> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
