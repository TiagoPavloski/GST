﻿using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BI.GST.Infra.Data.Repository
{
    public class ColaboradorRepository : BaseRepository<Colaborador>, IColaboradorRepository
    {
        public IEnumerable<Colaborador> ObterGrid(int page, string pesquisa)
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

        public IEnumerable<Colaborador> ObterTodosPorEmpresa(int EmpresaId)
        {
            Context.Configuration.LazyLoadingEnabled = false;
            return DbSet.Where(x => (x.EmpresaId == EmpresaId) && (x.Delete == false)).ToList();
        }

    }
}
