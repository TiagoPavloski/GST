using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BI.GST.Infra.Data.Repository
{
    public class CIPAEmpresaFuncionarioRepository : BaseRepository<CIPAEmpresaFuncionario>, ICIPAEmpresaFuncionarioRepository
    {

        public IEnumerable<CIPAEmpresaFuncionario> ObterGrid(int page, string pesquisa, int idCIPAEmpresa)
        {
            return DbSet.Where(x => (pesquisa != null ? x.FuncionarioEmpresa.Funcionario.Nome.Contains(pesquisa) : x.FuncionarioEmpresa.Funcionario.Nome != null) 
                && (x.Delete == false) && (x.CipaEmpresaId.Equals(idCIPAEmpresa)))
                    .OrderBy(u => u.FuncionarioEmpresa.Funcionario.Nome)
                    .Skip((page) * 10)
                    .Take(10);
        }

        public int ObterTotalRegistros(string pesquisa, int idCIPAEmpresa)
        {
            return DbSet.Count(x => (pesquisa != null ? x.FuncionarioEmpresa.Funcionario.Nome.Contains(pesquisa) : x.FuncionarioEmpresa.Funcionario.Nome != null) 
                && (x.Delete == false) && (x.CipaEmpresaId.Equals(idCIPAEmpresa)));
        }
    }
}
