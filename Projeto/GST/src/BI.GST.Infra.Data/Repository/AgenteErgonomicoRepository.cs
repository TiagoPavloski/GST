﻿using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.Repository
{
    public class AgenteErgonomicoRepository : BaseRepository<AgenteErgonomico>, IAgenteErgonomicoRepository
    {
        public IEnumerable<AgenteErgonomico> ObterGrid(int page, string pesquisa)
        {

            return DbSet.Where(x => (pesquisa != null ? x.Nome.Contains(pesquisa) : x.Nome != null) && (x.Delete == false))
                 .OrderBy(u => u.Nome)
                 .Skip((page) * 10)
                 .Take(10);
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return DbSet.Count(x => (pesquisa != null ? x.Nome.Contains(pesquisa) : x.Nome != null) && (x.Delete == false));
        }
    }
}
