using AutoMapper;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BI.GST.Application.AppService
{
  public class RiscoCBOAppService : BaseAppService, IRiscoCBOAppService
  {
    private readonly IRiscoCBOService _riscoCBOService;

    public RiscoCBOAppService(IRiscoCBOService riscoCBOService)
    {
      _riscoCBOService = riscoCBOService;
    }
    public bool Adicionar(RiscoCBOViewModel cursoViewModel)
    {
      var riscoCBO = Mapper.Map<RiscoCBOViewModel, RiscoCBO>(cursoViewModel);

      BeginTransaction();
      _riscoCBOService.Adicionar(riscoCBO);
      Commit();
      return true;
    }


    public bool Atualizar(RiscoCBOViewModel cursoViewModel)
    {
      var riscoCBO = Mapper.Map<RiscoCBOViewModel, RiscoCBO>(cursoViewModel);

      BeginTransaction();
      _riscoCBOService.Atualizar(riscoCBO);
      Commit();
      return true;
    }


    public void Dispose()
    {
      _riscoCBOService.Dispose();
      GC.SuppressFinalize(this);
    }

    public bool Excluir(int id)
    {
      bool existente = _riscoCBOService.Find(e => e.RiscoCBOId == id).Any();
      if (existente)
      {
        BeginTransaction();
        var riscoCBO = _riscoCBOService.ObterPorId(id);
        riscoCBO.Delete = true;
        _riscoCBOService.Atualizar(riscoCBO);
        Commit();
        return true;
      }
      return false;
    }

    public IEnumerable<RiscoCBOViewModel> ObterGrid(int page)
    {
      return Mapper.Map<IEnumerable<RiscoCBO>, IEnumerable<RiscoCBOViewModel>>(_riscoCBOService.ObterGrid(page));
    }

    public RiscoCBOViewModel ObterPorId(int id)
    {
      return Mapper.Map<RiscoCBO, RiscoCBOViewModel>(_riscoCBOService.ObterPorId(id));
    }

    public IEnumerable<RiscoCBOViewModel> ObterTodos()
    {
      return Mapper.Map<IEnumerable<RiscoCBO>, IEnumerable<RiscoCBOViewModel>>(_riscoCBOService.ObterTodos());
    }

    public int ObterTotalRegistros()
    {
      return _riscoCBOService.ObterTotalRegistros();
    }
  }
}
