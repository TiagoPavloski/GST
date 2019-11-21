using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
    public interface ICertificadoService : IDisposable
    {
        IEnumerable<Certificado> ObterTodos();

        Certificado ObterPorId(int id);

        IEnumerable<Certificado> Find(Expression<Func<Certificado, bool>> predicate);

        void Adicionar(Certificado certificado, int tipoCurso, string dataRealizacao);

        void Atualizar(Certificado certificado);

        void Excluir(int id);

        IEnumerable<Certificado> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
