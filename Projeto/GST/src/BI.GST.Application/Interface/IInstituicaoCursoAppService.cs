using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IInstituicaoCursoAppService : IDisposable
    {
        IEnumerable<InstituicaoCursoViewModel> ObterTodos();

        InstituicaoCursoViewModel ObterPorId(int id);

        bool Adicionar(InstituicaoCursoViewModel instituicaoCursoViewModel);

        bool Atualizar(InstituicaoCursoViewModel instituicaoCursoViewModel);

        bool Excluir(int id);

        IEnumerable<InstituicaoCursoViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}
