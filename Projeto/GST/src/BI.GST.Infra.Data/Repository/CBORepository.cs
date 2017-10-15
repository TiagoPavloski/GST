using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace BI.GST.Infra.Data.Repository
{
	public class CBORepository : BaseRepository<CBO>, ICBORepository
	{
		public int ObterTotalRegistros(string pesquisa)
		{
			return DbSet.Count(x => (pesquisa != null ? x.Nome.Contains(pesquisa) : x.Nome != null) && (x.Delete == false));
		}

		public IEnumerable<CBO> ObterGrid(int page, string pesquisa)
		{
			return DbSet.Where(x => (pesquisa != null ? x.Nome.Contains(pesquisa) : x.Nome != null) && (x.Delete == false))
					   .OrderBy(u => u.Nome)
					   .Skip((page) * 10)
					   .Take(10);
		}

		public override void Adicionar(CBO obj)
		{
			//Adiciona lista de Riscos de Função (CBO)
			List<RiscoCBO> riscoCBOs = new List<RiscoCBO>();
			foreach (var item in obj.RiscoCBOs)
                riscoCBOs.Add(new RiscoCBORepository().ObterPorId(item.RiscoCBOId));
			obj.RiscoCBOs = riscoCBOs;

			//Adiciona lista de cursos completa
			List<TipoCurso> tipoCursos = new List<TipoCurso>();
			foreach (var item in obj.TipoCursos)
                tipoCursos.Add(new TipoCursoRepository().ObterPorId(item.TipoCursoId));
			obj.TipoCursos = tipoCursos;

			//Adiciona lista de Exames completa
			List<TipoExame> tipoExames = new List<TipoExame>();
			foreach (var item in obj.TipoExames)
                tipoExames.Add(new TipoExameRepository().ObterPorId(item.TipoExameId));
			obj.TipoExames = tipoExames;

			base.Adicionar(obj);
		}

		public override void Atualizar(CBO obj)
		{
            //Adiciona lista de cnae completa com o cnae Id que foi pego na tela
            List<RiscoCBO> riscoCBOs = new List<RiscoCBO>();
            foreach (var item in obj.RiscoCBOs)
                riscoCBOs.Add(new RiscoCBORepository().ObterPorId(item.RiscoCBOId));
            obj.RiscoCBOs = riscoCBOs;

            //Adiciona lista de cursos completa
            List<TipoCurso> tipoCursos = new List<TipoCurso>();
            foreach (var item in obj.TipoCursos)
                tipoCursos.Add(new TipoCursoRepository().ObterPorId(item.TipoCursoId));
            obj.TipoCursos = tipoCursos;

            //Adiciona lista de Exames completa
            List<TipoExame> tipoExames = new List<TipoExame>();
            foreach (var item in obj.TipoExames)
                tipoExames.Add(new TipoExameRepository().ObterPorId(item.TipoExameId));
            obj.TipoExames = tipoExames;

            base.Atualizar(obj);

		}
	}
}
