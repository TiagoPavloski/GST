using BI.GST.Domain.Entities;
using System.Collections.Generic;

namespace BI.GST.Domain.Interface.IRepository
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        IEnumerable<Funcionario> ObterGrid(string pesquisa, int page);

        int ObterTotalRegistros(string pesquisa);

        IEnumerable<Funcionario> ObterTotalAtivos();

        IEnumerable<Funcionario> ObterPorEmpresa(int idEmpresa);

        int ObterTotalPorEmpresa(int idEmpresa);

        IEnumerable<Funcionario> ObterFuncionariosEC(int idEmpresa, int idCurso);

    }
}
