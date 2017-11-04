using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;

namespace BI.GST.Domain.Interface.IRepository
{
    public interface ICIPAEmpresaRepository : IBaseRepository<CIPAEmpresa>
    {
        IEnumerable<CIPAEmpresa> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);

        CIPAEmpresa ObterUltimaCipaPorEmpresa(int empresaId);

    }
}
