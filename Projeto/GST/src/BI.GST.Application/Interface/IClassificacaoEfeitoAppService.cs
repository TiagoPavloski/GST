using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IClassificacaoEfeitoAppService : IDisposable
    {
        IEnumerable<ClassificacaoEfeitoViewModel> ObterTodos();

        ClassificacaoEfeitoViewModel ObterPorId(int id);

        bool Adicionar(ClassificacaoEfeitoViewModel classificacaoEfeitoViewModel);

        bool Atualizar(ClassificacaoEfeitoViewModel classificacaoEfeitoViewModel);

        bool Excluir(int id);

        IEnumerable<ClassificacaoEfeitoViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
