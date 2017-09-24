using BI.GST.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BI.GST.Infra.Data.Context;
using System.Data.Entity;
using Microsoft.Practices.ServiceLocation;
using BI.GST.Infra.Data.Interface;

namespace BI.GST.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : Conversor, IBaseRepository<TEntity> where TEntity : class
    {
        protected ProjetoContext Context;
        protected DbSet<TEntity> DbSet;
        private readonly ContextManager _contextManager = ServiceLocator.Current.GetInstance<IContextManager>() as ContextManager;

        public BaseRepository()
        {
            Context = _contextManager.GetContext();
            DbSet = Context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            Context.Configuration.LazyLoadingEnabled = false;
            return DbSet.AsNoTracking().ToList();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Atualizar(TEntity obj)
        {
            var entry = Context.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual void Excluir(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual void Excluir(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
