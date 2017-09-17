using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
  public interface IVacinaService : IDisposable
  {
    IEnumerable<Vacina> ObterTodos();

    Vacina ObterPorId(int id);

    IEnumerable<Vacina> Find(Expression<Func<Vacina, bool>> predicate);

    void Adicionar(Vacina vacina);

    void Atualizar(Vacina vacina);

    void Excluir(int id);

    IEnumerable<Vacina> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
