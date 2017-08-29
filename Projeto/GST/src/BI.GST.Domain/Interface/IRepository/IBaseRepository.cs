using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IRepository
{
  public interface IBaseRepository<TEntity> : IDisposable where TEntity : class //Recebe entidade genérica <TEntity>, Herda de IDisposable, where TEntity trata como uma class e não objeto
  {
    IEnumerable<TEntity> ObterTodos();

    TEntity ObterPorId(Guid id);

    TEntity ObterPorId(int id);

    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    void Adicionar(TEntity obj);

    void Atualizar(TEntity obj);

    void Excluir(Guid id);

    void Excluir(int id);

    void SaveChanges();
  }
}
