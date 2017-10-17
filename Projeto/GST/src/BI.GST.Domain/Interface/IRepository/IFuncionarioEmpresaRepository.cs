using BI.GST.Domain.Entities;
using System.Collections.Generic;

namespace BI.GST.Domain.Interface.IRepository
{
 public  interface IFuncionarioEmpresaRepository : IBaseRepository<FuncionarioEmpresa>
  {
    IEnumerable<FuncionarioEmpresa> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
