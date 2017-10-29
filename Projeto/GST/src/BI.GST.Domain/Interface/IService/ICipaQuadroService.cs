using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;
using System.Linq.Expressions;

namespace BI.GST.Domain.Interface.IService
{
    public interface ICipaQuadroService : IDisposable
    {
        IEnumerable<CipaQuadro> ObterTodos();

        CipaQuadro ObterPorId(int id);

        CipaQuadro obterCipaPorGrupo(int numeroFuncionarios, int grupoCipaID);

    }
}
