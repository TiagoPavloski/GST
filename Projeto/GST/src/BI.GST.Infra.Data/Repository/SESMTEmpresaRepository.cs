using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BI.GST.Infra.Data.Repository
{
    public class SESMTEmpresaRepository : BaseRepository<SESMTEmpresa>, ISESMTEmpresaRepository
    {
        public IEnumerable<SESMTEmpresa> ObterGrid(int page, string pesquisa)
        {
            return DbSet.Where(x => (pesquisa != null ? x.Empresa.RazaoSocial.Contains(pesquisa) : x.Empresa.RazaoSocial != null) && (x.Delete == false))
                .OrderBy(u => u.Empresa.RazaoSocial)
                .Skip((page) * 10)
                .Take(10);
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return DbSet.Count(x => (pesquisa != null ? x.Empresa.RazaoSocial.Contains(pesquisa) : x.Empresa.RazaoSocial != null) && (x.Delete == false));
        }
    }
}
