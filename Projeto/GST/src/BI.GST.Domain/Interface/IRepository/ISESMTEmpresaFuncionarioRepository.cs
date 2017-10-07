using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IRepository
{
    public interface ISESMTEmpresaFuncionarioRepository : IBaseRepository<SESMTEmpresaFuncionario>
    {
        IEnumerable<SESMTEmpresaFuncionario> ObterGrid(int page, string pesquisa,int idSESMTEmpresa);

        int ObterTotalRegistros(string pesquisa, int idSESMTEmpresa);
    }
}
