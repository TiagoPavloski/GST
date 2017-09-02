using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
  public interface ITipoExameService : IDisposable
  {
    IEnumerable<TipoExame> ObterTodos();

    TipoExame ObterPorId(int id);

    IEnumerable<TipoExame> Find(Expression<Func<TipoExame, bool>> predicate);

    void Adicionar(TipoExame cliente);

    void Atualizar(TipoExame cliente);

    void Excluir(int id);

    IEnumerable<TipoExame> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
