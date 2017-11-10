using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.Repository
{
	public class ExameRepository : BaseRepository<Exame>, IExameRepository
	{
		public int ObterTotalRegistros(string pesquisa)
		{
			return DbSet.Count(x => (pesquisa != null ? x.Funcionario.Nome.Contains(pesquisa) : x.Funcionario.Nome != null) && (x.Delete == false));
		}

		public IEnumerable<Exame> ObterGrid(int page, string pesquisa)
		{
			return DbSet.Where(x => (pesquisa != null ? x.Funcionario.Nome.Contains(pesquisa) : x.Funcionario.Nome != null) && (x.Delete == false))
					   .OrderBy(u => u.Funcionario.Nome)
					   .Skip((page) * 10)
					   .Take(10);
		}

		public IEnumerable<Exame> AlertaExames()
		{
			DateTime testDate = DateTime.Now.AddMonths(-1);
			return DbSet.Where(x => (x.Renovado == false) && (x.Delete == false))
						   .OrderBy(u => u.Funcionario.Nome);

		}
	}
}
