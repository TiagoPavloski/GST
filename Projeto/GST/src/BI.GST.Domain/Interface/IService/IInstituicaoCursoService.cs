using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IInstituicaoCursoService : IDisposable
    {
        IEnumerable<InstituicaoCurso> ObterTodos();

        InstituicaoCurso ObterPorId(int id);

        IEnumerable<InstituicaoCurso> Find(Expression<Func<InstituicaoCurso, bool>> predicate);

        void Adicionar(InstituicaoCurso instituicaoCurso);

        void Atualizar(InstituicaoCurso instituicaoCurso);

        void Excluir(int id);

        IEnumerable<InstituicaoCurso> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
