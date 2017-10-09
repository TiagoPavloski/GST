using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;

namespace BI.GST.Domain.Interface.IRepository
{
    public interface ICIPAEmpresaFuncionarioRepository : IBaseRepository<CIPAEmpresaFuncionario>
    {
        IEnumerable<CIPAEmpresaFuncionario> ObterGrid(int page, string pesquisa, int idCIPAEmpresa);

        int ObterTotalRegistros(string pesquisa, int idCIPAEmpresa);
    }
}
