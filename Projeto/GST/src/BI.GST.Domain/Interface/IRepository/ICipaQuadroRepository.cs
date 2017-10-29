using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;

namespace BI.GST.Domain.Interface.IRepository
{
    public interface ICipaQuadroRepository : IBaseRepository<CipaQuadro>
    {
        CipaQuadro ObterCipaPorGrupo(int numeroFuncionarios, int grupoCipaID);
    }
}
