using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Infra.Data.Repository
{
    public class CertificadoRepository : BaseRepository<Certificado>, ICertificadoRepository
    {
        public int ObterTotalRegistros(string pesquisa)
        {
            return DbSet.Count(x => (pesquisa != null ? x.Funcionario.Nome.Contains(pesquisa) : x.Funcionario.Nome != null) && (x.Delete == false));
        }

        public IEnumerable<Certificado> ObterGrid(int page, string pesquisa)
        {
            return DbSet.Where(x => (pesquisa != null ? x.Funcionario.Nome.Contains(pesquisa) : x.Funcionario.Nome != null) && (x.Delete == false))
                       .OrderBy(u => u.Funcionario.Nome)
                       .Skip((page) * 10)
                       .Take(10);
        }

        public void Adicionar(Certificado obj, int tipoCurso, string dataRealizacao)
        {
            CursoRepository c = new CursoRepository();

            var curso = c.ObterCursoCertificado(obj.FuncionarioId, dataRealizacao, tipoCurso);
            obj.Curso = curso;



            base.Adicionar(obj);

            base.SaveChanges();
        }

    }
}
