using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BI.GST.Infra.Data.Repository
{
    public class SesmtQuadroRepository : BaseRepository<SesmtQuadro>, ISesmtQuadroRepository
    {
        public SesmtQuadro ObterSesmtPorGrauDeRisco(int numeroFuncionarios, int grauDeRisco)
        {
            return DbSet.Where(x => (x.NumeroEmpregadosInicial <= numeroFuncionarios)
                        && (x.NumeroEmpregadosFinal >= numeroFuncionarios)
                        && (x.GrauDeRisco == grauDeRisco)).FirstOrDefault();
        }
    }
}
