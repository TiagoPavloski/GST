using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;
using System.Linq.Expressions;
using BI.GST.Domain.Interface.IRepository;

namespace BI.GST.Domain.Services
{
    public class InstituicaoCursoService : IInstituicaoCursoService
    {
        private readonly IInstituicaoCursoRepository _instituicaoCursoRepository;

        public InstituicaoCursoService(IInstituicaoCursoRepository instituicaoCursoRepository)
        {
            _instituicaoCursoRepository = instituicaoCursoRepository;
        }

        public void Adicionar(InstituicaoCurso instituicaoCurso)
        {
            _instituicaoCursoRepository.Adicionar(instituicaoCurso);
        }

        public void Atualizar(InstituicaoCurso instituicaoCurso)
        {
            _instituicaoCursoRepository.Atualizar(instituicaoCurso);
        }

        public void Dispose()
        {
            _instituicaoCursoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _instituicaoCursoRepository.Excluir(id);
        }

        public IEnumerable<InstituicaoCurso> Find(Expression<Func<InstituicaoCurso, bool>> predicate)
        {
            return _instituicaoCursoRepository.Find(predicate);
        }

        public IEnumerable<InstituicaoCurso> ObterGrid(int page, string pesquisa)
        {
            return _instituicaoCursoRepository.ObterGrid(page, pesquisa);
        }

        public InstituicaoCurso ObterPorId(int id)
        {
            return _instituicaoCursoRepository.ObterPorId(id);
        }

        public IEnumerable<InstituicaoCurso> ObterTodos()
        {
            return _instituicaoCursoRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _instituicaoCursoRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
