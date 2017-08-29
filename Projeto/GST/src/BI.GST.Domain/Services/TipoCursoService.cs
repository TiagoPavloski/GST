using BI.GST.Domain.Interface.IRepository;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;
using System.Linq.Expressions;

namespace BI.GST.Domain.Services
{
  public class TipoCursoService : ITipoCursoService
  {
    private readonly ITipoCursoRepository _tipoCursoRepository;

    public TipoCursoService(ITipoCursoRepository tipoCursoRepository)
    {
      _tipoCursoRepository = tipoCursoRepository;
    }


    public void Dispose()
    {
      _tipoCursoRepository.Dispose();
      GC.SuppressFinalize(this);
    }

    public IEnumerable<TipoCurso> ObterTodos()
    {
      return _tipoCursoRepository.ObterTodos();
    }

    public TipoCurso ObterPorId(int id)
    {
      return _tipoCursoRepository.ObterPorId(id);
    }

    public IEnumerable<TipoCurso> Find(Expression<Func<TipoCurso, bool>> predicate)
    {
      return _tipoCursoRepository.Find(predicate);
    }

    public void Adicionar(TipoCurso tipoCurso)
    {
      _tipoCursoRepository.Adicionar(tipoCurso);
    }

    public void Atualizar(TipoCurso tipoCurso)
    {
      _tipoCursoRepository.Atualizar(tipoCurso);
    }

    public void Excluir(int id)
    {
      _tipoCursoRepository.Excluir(id);
    }

    public IEnumerable<TipoCurso> ObterGrid(int page, string pesquisa)
    {
      return _tipoCursoRepository.ObterGrid(page, pesquisa);
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _tipoCursoRepository.ObterTotalRegistros(pesquisa);
    }
  }
}
