using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using BI.GST.Domain.Entities;
using AutoMapper;

namespace BI.GST.Application.AppService
{
  public class FonteRiscoCBOAppService : BaseAppService, IFonteRiscoCBOAppService
  {
    private readonly IFonteRiscoCBOService _fonteRiscoCBOService;

    // USAR ESTE QUANDO IMPLEMENTAR RISCOSCBO E RISCOSFUNCIONARIO
    //private readonly IRiscosCBOService _riscosCBOService;
    //private readonly IRiscosFuncionarioService _riscosFuncionarioService;

    //public AgenteCausadorCBOAppService(IAgenteCausadorCBOService agenteCausadorCBOService, IRiscosCBOService riscosCBOService, IRiscosFuncionarioService riscosFuncionarioService)
    //{
    //  _agenteCausadorCBOService = agenteCausadorCBOService;
    //  _riscosCBOService = riscosCBOService;
    //  _riscosFuncionarioService = riscosFuncionarioService;
    //}

    public FonteRiscoCBOAppService(IFonteRiscoCBOService fonteRiscoCBOService)
    {
        _fonteRiscoCBOService = fonteRiscoCBOService;
    }

    public bool Adicionar(FonteRiscoCBOViewModel fonteRiscoCBOViewModel)
    {
      var fonteRiscoCBO = Mapper.Map<FonteRiscoCBOViewModel, FonteRiscoCBO>(fonteRiscoCBOViewModel);

      var duplicado = _fonteRiscoCBOService.Find(e => e.Nome == fonteRiscoCBO.Nome).Where(d => d.Delete == false).Any();
      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _fonteRiscoCBOService.Adicionar(fonteRiscoCBO);
        Commit();
        return true;
      }
    }

    public bool Atualizar(FonteRiscoCBOViewModel fonteRiscoCBOViewModel)
    {
      var agenteCausadorCBO = Mapper.Map<FonteRiscoCBOViewModel, FonteRiscoCBO>(fonteRiscoCBOViewModel);

      var duplicado = _fonteRiscoCBOService.Find(e => e.Nome == agenteCausadorCBO.Nome && e.Delete == false && e.FonteRiscoCBOId != agenteCausadorCBO.FonteRiscoCBOId).Any();

      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _fonteRiscoCBOService.Atualizar(agenteCausadorCBO);
        Commit();
        return true;
      }

    }

    public void Dispose()
    {
      _fonteRiscoCBOService.Dispose();
      GC.SuppressFinalize(this);
    }

    public bool Excluir(int id)
    {
      bool existente = _fonteRiscoCBOService.Find(e => e.FonteRiscoCBOId == id).Any();
      //bool funcionarioUtiliza = _funcionarioService.Find(c => c.EscalaId == id && c.Delete == false).Any();

      //if (existente && !funcionarioUtiliza)
      if (existente)
      {
        BeginTransaction();
        var fonteRiscoCBO = _fonteRiscoCBOService.ObterPorId(id);
        fonteRiscoCBO.Delete = true;
        _fonteRiscoCBOService.Atualizar(fonteRiscoCBO);
        Commit();
        return true;
      }
      return false;
    }

    public IEnumerable<FonteRiscoCBOViewModel> ObterGrid(int page, string pesquisa)
    {
      return Mapper.Map<IEnumerable<FonteRiscoCBO>, IEnumerable<FonteRiscoCBOViewModel>>(_fonteRiscoCBOService.ObterGrid(page, pesquisa));
    }

    public FonteRiscoCBOViewModel ObterPorId(int id)
    {
      return Mapper.Map<FonteRiscoCBO, FonteRiscoCBOViewModel>(_fonteRiscoCBOService.ObterPorId(id));
    }

    public IEnumerable<FonteRiscoCBOViewModel> ObterTodos()
    {
      return Mapper.Map<IEnumerable<FonteRiscoCBO>, IEnumerable<FonteRiscoCBOViewModel>>(_fonteRiscoCBOService.ObterTodos());
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _fonteRiscoCBOService.ObterTotalRegistros(pesquisa);
    }
  }
}
