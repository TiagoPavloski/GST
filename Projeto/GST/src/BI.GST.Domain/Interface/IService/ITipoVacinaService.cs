using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
  public interface ITipoVacinaService : IDisposable
  {
    IEnumerable<TipoVacina> ObterTodos();

    TipoVacina ObterPorId(int id);

    IEnumerable<TipoVacina> Find(Expression<Func<TipoVacina, bool>> predicate);

    void Adicionar(TipoVacina tipoVacina);

    void Atualizar(TipoVacina tipoVacina);

    void Excluir(int id);

    IEnumerable<TipoVacina> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
