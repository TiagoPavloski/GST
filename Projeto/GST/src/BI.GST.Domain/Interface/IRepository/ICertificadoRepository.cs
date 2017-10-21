using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IRepository
{
    public interface ICertificadoRepository : IBaseRepository<Certificado>
    {
        IEnumerable<Certificado> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
