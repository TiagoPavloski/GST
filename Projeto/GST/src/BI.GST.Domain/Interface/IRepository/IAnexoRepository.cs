using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IRepository
{
    public interface IAnexoRepository : IBaseRepository<Anexo>
    {
        IEnumerable<Anexo> ObterGrid(int page, string pesquisa, int idPPRA);

        int ObterTotalRegistros(string pesquisa, int idPPRA);

        IEnumerable<Anexo> ObterTodos(int idPPRA);
    }
}
