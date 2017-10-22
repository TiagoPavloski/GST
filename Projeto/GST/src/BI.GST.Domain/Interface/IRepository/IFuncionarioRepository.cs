using BI.GST.Domain.Entities;
using System.Collections.Generic;

namespace BI.GST.Domain.Interface.IRepository
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        IEnumerable<Funcionario> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);

        IEnumerable<Funcionario> ObterPorEmpresa(int idEmpresa);

    }
}
