using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Services
{
  public class CursoService : ICursoService
  {
    private readonly ICursoRepository _cursoRepository;

    public CursoService(ICursoRepository cursoRepository)
    {
      _cursoRepository = cursoRepository;
    }

    public void Adicionar(Curso curso)
    {
      _cursoRepository.Adicionar(curso);
    }

    public void Atualizar(Curso curso)
    {
      _cursoRepository.Atualizar(curso);
    }

    public void Dispose()
    {
      _cursoRepository.Dispose();
      GC.SuppressFinalize(this);
    }

    public void Excluir(int id)
    {
      _cursoRepository.Excluir(id);
    }

    public IEnumerable<Curso> Find(Expression<Func<Curso, bool>> predicate)
    {
      return _cursoRepository.Find(predicate);
    }

    public IEnumerable<Curso> ObterGrid(int page, string pesquisa)
    {
      return _cursoRepository.ObterGrid(page, pesquisa);
    }

    public Curso ObterPorId(int id)
    {
      return _cursoRepository.ObterPorId(id);
    }

    public IEnumerable<Curso> ObterTodos()
    {
      return _cursoRepository.ObterTodos();
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _cursoRepository.ObterTotalRegistros(pesquisa);
    }
  }
}
