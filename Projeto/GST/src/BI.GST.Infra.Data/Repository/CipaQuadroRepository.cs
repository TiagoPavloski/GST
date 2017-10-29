using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BI.GST.Infra.Data.Repository
{
    public class CipaQuadroRepository : BaseRepository<CipaQuadro>, ICipaQuadroRepository
    {
        public CipaQuadro ObterCipaPorGrupo(int numeroFuncionarios, int grupoCipaID)
        {
            return DbSet.Where(x => (x.NumeroEmpregadosInicial <= numeroFuncionarios)
                                    && (x.NumeroEmpregadosFinal >= numeroFuncionarios)
                                    && (x.GrupoCipa.GrupoCipaId == grupoCipaID)).FirstOrDefault();
        }
    }
}
