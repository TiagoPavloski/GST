using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BI.GST.Domain.Interface.IService
{
    public interface IEPIService : IDisposable
    {
        IEnumerable<EPI> ObterTodos();

        EPI ObterPorId(int id);

        IEnumerable<EPI> Find(Expression<Func<EPI, bool>> predicate);

        void Adicionar(EPI epi);

        void Atualizar(EPI epi);

        void Excluir(int id);

        IEnumerable<EPI> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
