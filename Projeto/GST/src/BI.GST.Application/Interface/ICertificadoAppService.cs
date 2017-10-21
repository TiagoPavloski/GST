using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface ICertificadoAppService : IDisposable
    {
        IEnumerable<CertificadoViewModel> ObterTodos();

        CertificadoViewModel ObterPorId(int id);

        bool Adicionar(CertificadoViewModel certificadoViewModel);

        bool Atualizar(CertificadoViewModel certificadoViewModel);

        bool Excluir(int id);

        IEnumerable<CertificadoViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
