using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface ICipaQuadroAppService : IDisposable
    {
        IEnumerable<CipaQuadroViewModel> ObterTodos();

        CipaQuadroViewModel ObterPorId(int id);

        CipaQuadroViewModel obterCipaPorGrupo(int numeroFuncionarios, int grupoCipaID);
    }
}
