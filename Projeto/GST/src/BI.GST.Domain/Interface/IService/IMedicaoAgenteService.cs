using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IMedicaoAgenteService : IDisposable
    {
        IEnumerable<MedicaoAgente> ObterTodos();

        MedicaoAgente ObterPorId(int id);

        IEnumerable<MedicaoAgente> Find(Expression<Func<MedicaoAgente, bool>> predicate);

        void Adicionar(MedicaoAgente MedicaoAgente);

        void Atualizar(MedicaoAgente MedicaoAgente);

        void Excluir(int id);

        IEnumerable<MedicaoAgente> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
