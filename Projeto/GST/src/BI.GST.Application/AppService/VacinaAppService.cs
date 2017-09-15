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
  public class VacinaAppService : BaseAppService, IVacinaAppService
  {
    private readonly IVacinaService _vacinaService;

    public VacinaAppService(IVacinaService vacinaService)
    {
      _vacinaService = vacinaService;
    }
    public bool Adicionar(VacinaViewModel vacinaViewModel)
    {
      var vacina = Mapper.Map<VacinaViewModel, Vacina>(vacinaViewModel);

      BeginTransaction();
      _vacinaService.Adicionar(vacina);
      Commit();
      return true;
    }


    public bool Atualizar(VacinaViewModel vacinaViewModel)
    {
      var vacina = Mapper.Map<VacinaViewModel, Vacina>(vacinaViewModel);

      BeginTransaction();
      _vacinaService.Atualizar(vacina);
      Commit();
      return true;
    }


    public void Dispose()
    {
      _vacinaService.Dispose();
      GC.SuppressFinalize(this);
    }

    public bool Excluir(int id)
    {
      bool existente = _vacinaService.Find(e => e.VacinaId == id).Any();
      if (existente)
      {
        BeginTransaction();
        var tipoVacina = _vacinaService.ObterPorId(id);
        tipoVacina.Delete = true;
        _vacinaService.Atualizar(tipoVacina);
        Commit();
        return true;
      }
      return false;
    }

    public IEnumerable<VacinaViewModel> ObterGrid(int page, string pesquisa)
    {
      return Mapper.Map<IEnumerable<Vacina>, IEnumerable<VacinaViewModel>>(_vacinaService.ObterGrid(page, pesquisa));
    }

    public VacinaViewModel ObterPorId(int id)
    {
      return Mapper.Map<Vacina, VacinaViewModel>(_vacinaService.ObterPorId(id));
    }

    public IEnumerable<VacinaViewModel> ObterTodos()
    {
      return Mapper.Map<IEnumerable<Vacina>, IEnumerable<VacinaViewModel>>(_vacinaService.ObterTodos());
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _vacinaService.ObterTotalRegistros(pesquisa);
    }
  }
}
