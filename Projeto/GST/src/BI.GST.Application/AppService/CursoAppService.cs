using AutoMapper;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.AppService
{
  public class CursoAppService : BaseAppService, ICursoAppService
  {
    private readonly ICursoService _cursoService;

    public CursoAppService(ICursoService cursoService)
    {
      _cursoService = cursoService;
    }
    public bool Adicionar(CursoViewModel cursoViewModel)
    {
      var Curso = Mapper.Map<CursoViewModel, Curso>(cursoViewModel);

      BeginTransaction();
      _cursoService.Adicionar(Curso);
      Commit();
      return true;
    }


    public bool Atualizar(CursoViewModel cursoViewModel)
    {
      var Curso = Mapper.Map<CursoViewModel, Curso>(cursoViewModel);

      BeginTransaction();
      _cursoService.Atualizar(Curso);
      Commit();
      return true;
    }


    public void Dispose()
    {
      _cursoService.Dispose();
      GC.SuppressFinalize(this);
    }

    public bool Excluir(int id)
    {
      bool existente = _cursoService.Find(e => e.CursoId == id).Any();
      if (existente)
      {
        BeginTransaction();
        var tipoCurso = _cursoService.ObterPorId(id);
        tipoCurso.Delete = true;
        _cursoService.Atualizar(tipoCurso);
        Commit();
        return true;
      }
      return false;
    }

    public IEnumerable<CursoViewModel> ObterGrid(int page, string pesquisa)
    {
      return Mapper.Map<IEnumerable<Curso>, IEnumerable<CursoViewModel>>(_cursoService.ObterGrid(page, pesquisa));
    }

    public CursoViewModel ObterPorId(int id)
    {
      return Mapper.Map<Curso, CursoViewModel>(_cursoService.ObterPorId(id));
    }

    public IEnumerable<CursoViewModel> ObterTodos()
    {
      return Mapper.Map<IEnumerable<Curso>, IEnumerable<CursoViewModel>>(_cursoService.ObterTodos());
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _cursoService.ObterTotalRegistros(pesquisa);
    }
  }
}
