using BI.GST.Domain.Entities;
using System.Collections.Generic;

namespace BI.GST.Domain.Interface.IRepository
{
 public  interface IInstituicaoCursoRepository : IBaseRepository<InstituicaoCurso>
  {
    IEnumerable<InstituicaoCurso> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
