using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using AutoMapper;
using BI.GST.Domain.Entities;

namespace BI.GST.Application.AppService
{
  public class TipoExameAppService : BaseAppService, ITipoExameAppService
  {
    private readonly ITipoExameService _tipoExameService;
    private readonly IExameService _exameService;

    public TipoExameAppService(ITipoExameService tipoExameService, IExameService exameService)
    {
      _tipoExameService = tipoExameService;
      _exameService = exameService;
    }
    public bool Adicionar(TipoExameViewModel tipoExameViewModel)
    {
      var tipoExame = Mapper.Map<TipoExameViewModel, TipoExame>(tipoExameViewModel);

      var duplicado = _tipoExameService.Find(e => (e.Nome == tipoExame.Nome) && (e.Delete == false)).Any();
      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _tipoExameService.Adicionar(tipoExame);
        Commit();
        return true;
      }
    }

    public bool Atualizar(TipoExameViewModel tipoExameViewModel)
    {
      var tipoExame = Mapper.Map<TipoExameViewModel, TipoExame>(tipoExameViewModel);

      var duplicado = _tipoExameService.Find(e => (e.Nome == tipoExame.Nome) && (e.TipoExameId != tipoExame.TipoExameId) && (e.Delete == false)).Any();

      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _tipoExameService.Atualizar(tipoExame);
        Commit();
        return true;
      }
    }

    public void Dispose()
    {
      _tipoExameService.Dispose();
      GC.SuppressFinalize(this);
    }

    public bool Excluir(int id)
    {
      bool existente = _tipoExameService.Find(e => e.TipoExameId == id && (e.Delete == false)).Any();
      bool exameUtiliza = _exameService.Find(c => c.TipoExameId == id && c.Delete == false).Any();

      if (existente && !exameUtiliza)
      {
        BeginTransaction();
        var tipoExame = _tipoExameService.ObterPorId(id);
        tipoExame.Delete = true;
        _tipoExameService.Atualizar(tipoExame);
        Commit();
        return true;
      }
      return false;
    }

    public IEnumerable<TipoExameViewModel> ObterGrid(int page, string pesquisa)
    {
      return Mapper.Map<IEnumerable<TipoExame>, IEnumerable<TipoExameViewModel>>(_tipoExameService.ObterGrid(page, pesquisa));
  }

    public TipoExameViewModel ObterPorId(int id)
    {
      return Mapper.Map<TipoExame, TipoExameViewModel>(_tipoExameService.ObterPorId(id));
    }

    public IEnumerable<TipoExameViewModel> ObterTodos()
    {
      return Mapper.Map<IEnumerable<TipoExame>, IEnumerable<TipoExameViewModel>>(_tipoExameService.ObterTodos());
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _tipoExameService.ObterTotalRegistros(pesquisa);
    }
  }
}
