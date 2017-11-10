using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using BI.GST.Domain.Entities;
using AutoMapper;

namespace BI.GST.Application.AppService
{
  public class TipoCursoAppService : BaseAppService, ITipoCursoAppService
  {
    private readonly ITipoCursoService _tipoCursoService;
    private readonly ICursoService _cursoService;

    public TipoCursoAppService(ITipoCursoService tipoCursoService, ICursoService cursoService)
    {
      _tipoCursoService = tipoCursoService;
      _cursoService = cursoService;
    }

    public bool Adicionar(TipoCursoViewModel tipoCursoViewModel)
    {
      var tipoCurso = Mapper.Map<TipoCursoViewModel, TipoCurso>(tipoCursoViewModel);

      var duplicado = _tipoCursoService.Find(e => (e.Nome == tipoCurso.Nome) && (e.Delete == false)).Any();
      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _tipoCursoService.Adicionar(tipoCurso);
        Commit();
        return true;
      }
    }

    public bool Atualizar(TipoCursoViewModel tipoCursoViewModel)
    {
      var tipoCurso = Mapper.Map<TipoCursoViewModel, TipoCurso>(tipoCursoViewModel);

      var duplicado = _tipoCursoService.Find(e => (e.Nome == tipoCurso.Nome) && (e.TipoCursoId != tipoCurso.TipoCursoId) && (e.Delete == false)).Any();

      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _tipoCursoService.Atualizar(tipoCurso);
        Commit();
        return true;
      }

    }

    public void Dispose()
    {
      _tipoCursoService.Dispose();
      GC.SuppressFinalize(this);
    }

    public string Excluir(int id)
    {
      bool existente = _tipoCursoService.Find(e => (e.TipoCursoId) == id && (e.Delete == false)).Any();
      bool cursoUtiliza = _cursoService.Find(c => c.TipoCursoId == id && c.Delete == false).Any();

      if (existente && !cursoUtiliza)
      {
        BeginTransaction();
        var tipoCurso = _tipoCursoService.ObterPorId(id);
        tipoCurso.Delete = true;
        _tipoCursoService.Atualizar(tipoCurso);
        Commit();
        return "";
      }
      return "Exclusão negada! Existem cursos deste tipo.";
    }

    public IEnumerable<TipoCursoViewModel> ObterGrid(int page, string pesquisa)
    {
      return Mapper.Map<IEnumerable<TipoCurso>, IEnumerable<TipoCursoViewModel>>(_tipoCursoService.ObterGrid(page, pesquisa));
    }

    public TipoCursoViewModel ObterPorId(int id)
    {
      return Mapper.Map<TipoCurso, TipoCursoViewModel>(_tipoCursoService.ObterPorId(id));
    }

    public IEnumerable<TipoCursoViewModel> ObterTodos()
    {
      return Mapper.Map<IEnumerable<TipoCurso>, IEnumerable<TipoCursoViewModel>>(_tipoCursoService.ObterTodos());
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _tipoCursoService.ObterTotalRegistros(pesquisa);
    }
  }
}
