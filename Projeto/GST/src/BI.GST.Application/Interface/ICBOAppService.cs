using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
	public interface ICBOAppService : IDisposable
	{
		IEnumerable<CBOViewModel> ObterTodos();

        CBOViewModel ObterPorId(int id);

		bool Adicionar(CBOViewModel cboViewModel, int[] riscoCBOId, int[] TipoCursoId, int[] TipoExameId, int[] TipoVacina);

		bool Atualizar(CBOViewModel cboViewModel, int[] riscoCBOId, int[] TipoCursoId, int[] TipoExameId, int[] TipoVacina);

		bool Excluir(int id);

		IEnumerable<CBOViewModel> ObterGrid(int page, string pesquisa);

		bool AdicionarResponsavel(string CPF);

		bool DeletarResponsavel(int id);

		int ObterTotalRegistros(string pesquisa);
	}
}
