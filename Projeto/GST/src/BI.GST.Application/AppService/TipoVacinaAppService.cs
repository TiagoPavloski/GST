using AutoMapper;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.AppService
{
  public class TipoVacinaAppService : BaseAppService, ITipoVacinaAppService
  {
    private readonly ITipoVacinaService _tipoVacinaService;

    public TipoVacinaAppService(ITipoVacinaService tipoVacinaService)
    {
      _tipoVacinaService = tipoVacinaService;
    }
    public bool Adicionar(TipoVacinaViewModel tipoVacinaViewModel)
    {
      var tipoVacina = Mapper.Map<TipoVacinaViewModel, TipoVacina>(tipoVacinaViewModel);

      var duplicado = _tipoVacinaService.Find(e => e.Nome == tipoVacina.Nome).Any();
      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _tipoVacinaService.Adicionar(tipoVacina);
        Commit();
        return true;
      }
    }

    public bool Atualizar(TipoVacinaViewModel TipoVacinaViewModel)
    {
      var tipoVacina = Mapper.Map<TipoVacinaViewModel, TipoVacina>(TipoVacinaViewModel);

      var duplicado = _tipoVacinaService.Find(e => e.Nome == tipoVacina.Nome && e.TipoVacinaId != tipoVacina.TipoVacinaId).Any();

      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _tipoVacinaService.Atualizar(tipoVacina);
        Commit();
        return true;
      }
    }

    public void Dispose()
    {
      _tipoVacinaService.Dispose();
      GC.SuppressFinalize(this);
    }

    public bool Excluir(int id)
    {
      bool existente = _tipoVacinaService.Find(e => e.TipoVacinaId == id).Any();
      if (existente)
      {
        BeginTransaction();
        var tipoVacina = _tipoVacinaService.ObterPorId(id);
        tipoVacina.Delete = true;
        _tipoVacinaService.Atualizar(tipoVacina);
        Commit();
        return true;
      }
      return false;
    }

    public IEnumerable<TipoVacinaViewModel> ObterGrid(int page, string pesquisa)
    {
      return Mapper.Map<IEnumerable<TipoVacina>, IEnumerable<TipoVacinaViewModel>>(_tipoVacinaService.ObterGrid(page, pesquisa));
    }

    public TipoVacinaViewModel ObterPorId(int id)
    {
      return Mapper.Map<TipoVacina, TipoVacinaViewModel>(_tipoVacinaService.ObterPorId(id));
    }

    public IEnumerable<TipoVacinaViewModel> ObterTodos()
    {
      return Mapper.Map<IEnumerable<TipoVacina>, IEnumerable<TipoVacinaViewModel>>(_tipoVacinaService.ObterTodos());
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _tipoVacinaService.ObterTotalRegistros(pesquisa);
    }
  }
}
