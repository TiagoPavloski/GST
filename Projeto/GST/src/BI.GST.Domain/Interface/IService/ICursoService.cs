using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
  public interface ICursoService : IDisposable
  {
    IEnumerable<Curso> ObterTodos();

    Curso ObterPorId(int id);

    IEnumerable<Curso> Find(Expression<Func<Curso, bool>> predicate);

    void Adicionar(Curso curso);

    void Atualizar(Curso curso);

    void Excluir(int id);

    IEnumerable<Curso> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}

