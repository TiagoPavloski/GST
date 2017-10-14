using BI.GST.Domain.Entities;
using System.Collections.Generic;


namespace BI.GST.Domain.Interface.IRepository
{
    public interface IColaboradorRepository : IBaseRepository<Colaborador>
    {
        IEnumerable<Colaborador> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
