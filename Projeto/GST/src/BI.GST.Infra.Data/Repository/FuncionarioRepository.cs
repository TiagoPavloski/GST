using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.Repository
{
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        public int ObterTotalRegistros(string pesquisa)
        {
            return DbSet.Count(x => (pesquisa != null ? x.Nome.Contains(pesquisa) : x.Nome != null) && (x.Delete == false));
        }

        public IEnumerable<Funcionario> ObterGrid(string pesquisa, int page)
        {
            return DbSet.Where(x => (pesquisa != null ? x.Nome.Contains(pesquisa) : x.Nome != null) && (x.Delete == false))
                       .OrderBy(u => u.Nome)
                       .Skip((page) * 10)
                       .Take(10);
        }

        public IEnumerable<Funcionario> ObterPorEmpresa(int empresaId)
        {
            //Context.Configuration.LazyLoadingEnabled = false;
            return DbSet.Where(x => (x.EmpresaId == empresaId) && (x.Delete == false))
                       .OrderBy(u => u.Nome);
        }

        public int ObterTotalPorEmpresa(int idEmpresa)
        {
            return DbSet.Count(x => (x.EmpresaId == idEmpresa) && (x.Delete == false));
        }

        public IEnumerable<Funcionario> ObterTotalAtivos()
        {
            return DbSet.Where(f => (f.Delete == false) && (f.Status == 1))
                .OrderBy(x => x.Nome);
        }

        public IEnumerable<Funcionario> ObterFuncionariosEC(int idEmpresa, int idTipoCurso)
        {
            //foreach (var func in FuncionariosEmpresa)
            //{
            //    if (func.Cursos != null)
            //    {
            //        foreach (var curso in func.Cursos)
            //        {
            //            if (curso.TipoCursoId == idTipoCurso && curso.Delete == false)
            //            {
            //                funcionariosporra.Add(func);
            //                break;
            //            }

            //        }
            //    }
              
            //}



            return DbSet.Where(x => (x.EmpresaId == idEmpresa)
                                && (x.Delete == false)
                                && (x.Cursos.Where(c => c.TipoCurso.TipoCursoId == idTipoCurso
                                                   && c.Delete == false).Any())).OrderBy(u => u.Nome);

        }

    }
}
