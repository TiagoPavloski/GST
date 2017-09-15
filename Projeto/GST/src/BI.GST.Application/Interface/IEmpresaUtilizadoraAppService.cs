using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IEmpresaUtilizadoraAppService : IDisposable
    {
        IEnumerable<EmpresaUtilizadoraViewModel> ObterTodos();

        EmpresaUtilizadoraViewModel ObterPorId(int id);

        bool Adicionar(EmpresaUtilizadoraViewModel empresaUtilizadoraViewModel);

        bool Atualizar(EmpresaUtilizadoraViewModel empresaUtilizadoraViewModel);

        bool Excluir(int id);

        IEnumerable<EmpresaUtilizadoraViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
