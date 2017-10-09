using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BI.GST.Infra.Data.Repository
{
    public class SESMTEmpresaFuncionarioRepository : BaseRepository<SESMTEmpresaFuncionario>, ISESMTEmpresaFuncionarioRepository
    {
        public IEnumerable<SESMTEmpresaFuncionario> ObterGrid(int page, string pesquisa, int idSESMTEmpresa)
        {
            return DbSet.Where(x => (pesquisa != null ? x.FuncionarioEmpresa.Funcionario.Nome.Contains(pesquisa) : x.FuncionarioEmpresa.Funcionario.Nome != null)
                && (x.Delete == false) && (x.SESMTEmpresaId.Equals(idSESMTEmpresa)))
                    .OrderBy(u => u.FuncionarioEmpresa.Funcionario.Nome)
                    .Skip((page) * 10)
                    .Take(10);
        }

        public int ObterTotalRegistros(string pesquisa, int idSESMTEmpresa)
        {
            return DbSet.Count(x => (pesquisa != null ? x.FuncionarioEmpresa.Funcionario.Nome.Contains(pesquisa) : x.FuncionarioEmpresa.Funcionario.Nome != null)
                && (x.Delete == false) && (x.SESMTEmpresaId.Equals(idSESMTEmpresa)));
        }
    }
}
