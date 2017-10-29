using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;
using System.Linq.Expressions;
using BI.GST.Application.ViewModels;

namespace BI.GST.Application.Interface
{
    public interface ISesmtQuadroAppService : IDisposable
    {
        IEnumerable<SesmtQuadroViewModel> ObterTodos();

        SesmtQuadroViewModel ObterPorId(int id);

        SesmtQuadroViewModel ObterSesmtPorGrauDeRisco (int numeroFuncionarios, int grauDeRisco);
    }
}
