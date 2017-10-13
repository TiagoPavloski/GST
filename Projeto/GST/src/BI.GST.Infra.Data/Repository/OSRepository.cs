using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.Repository
{
	public class OSRepository : BaseRepository<OS>, IOSRepository
	{
		public int ObterTotalRegistros(string pesquisa)
		{
			return DbSet.Count(x => (pesquisa != null ? x.FuncionarioEmpresa.Funcionario.Nome.Contains(pesquisa) : x.FuncionarioEmpresa.Funcionario.Nome != null) && (x.Delete == false));
		}

		public IEnumerable<OS> ObterGrid(int page, string pesquisa)
		{
			return DbSet.Where(x => (pesquisa != null ? x.FuncionarioEmpresa.Funcionario.Nome.Contains(pesquisa) : x.FuncionarioEmpresa.Funcionario.Nome != null) && (x.Delete == false))
					   .OrderBy(u => u.FuncionarioEmpresa.Funcionario.Nome)
					   .Skip((page) * 10)
					   .Take(10);
		}
	}
}
