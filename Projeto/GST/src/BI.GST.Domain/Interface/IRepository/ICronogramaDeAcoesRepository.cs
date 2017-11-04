using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IRepository
{
    public interface ICronogramaDeAcoesRepository : IBaseRepository<CronogramaDeAcoes>
    {
        IEnumerable<CronogramaDeAcoes> ObterGrid(int page, string pesquisa, int ppraId);

        int ObterTotalRegistros(string pesquisa, int ppraId);

        IEnumerable<CronogramaDeAcoes> ObterPorPPRA(int ppraId);
    }
}
