using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
  public interface ITipoCursoService : IDisposable
  {
    IEnumerable<TipoCurso> ObterTodos();

    TipoCurso ObterPorId(int id);

    IEnumerable<TipoCurso> Find(Expression<Func<TipoCurso, bool>> predicate);

    void Adicionar(TipoCurso cliente);

    void Atualizar(TipoCurso cliente);

    void Excluir(int id);

    IEnumerable<TipoCurso> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
