using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IRepository
{
	public interface IVacinaRepository : IBaseRepository<Vacina>
	{
		IEnumerable<Vacina> ObterGrid(int page, string pesquisa);

		int ObterTotalRegistros(string pesquisa);

		IEnumerable<Vacina> AlertaVacinas();
	}
}
