using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
  public interface IEscalaService : IDisposable
  {
    IEnumerable<Escala> ObterTodos();

    Escala ObterPorId(int id);

    IEnumerable<Escala> Find(Expression<Func<Escala, bool>> predicate);

    void Adicionar(Escala tipoCruso);

    void Atualizar(Escala tipoCurso);

    void Excluir(int id);

    IEnumerable<Escala> ObterGrid(int page, string pesquisa);

    int ObterTotalRegistros(string pesquisa);
  }
}
