using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface IAnexoService : IDisposable
    {
        IEnumerable<Anexo> ObterTodos(int idPPRA);

        Anexo ObterPorId(int id);

        IEnumerable<Anexo> Find(Expression<Func<Anexo, bool>> predicate);

        void Adicionar(Anexo anexo);

        void Atualizar(Anexo anexo);

        void Excluir(int id);

        IEnumerable<Anexo> ObterGrid(int page, string pesquisa, int idPPRA);

        int ObterTotalRegistros(string pesquisa, int idPPRA);
    }
}
