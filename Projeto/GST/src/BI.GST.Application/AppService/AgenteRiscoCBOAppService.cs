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
  public class AgenteRiscoCBOAppService : BaseAppService, IAgenteRiscoCBOAppService
  {
    private readonly IAgenteRiscoCBOService _agenteRiscoCBOService;

    // USAR ESTE QUANDO IMPLEMENTAR RISCOSCBO E RISCOSFUNCIONARIO
    //private readonly IRiscosCBOService _riscosCBOService;
    //private readonly IRiscosFuncionarioService _riscosFuncionarioService;

    //public AgenteCausadorCBOAppService(IAgenteCausadorCBOService agenteCausadorCBOService, IRiscosCBOService riscosCBOService, IRiscosFuncionarioService riscosFuncionarioService)
    //{
    //  _agenteCausadorCBOService = agenteCausadorCBOService;
    //  _riscosCBOService = riscosCBOService;
    //  _riscosFuncionarioService = riscosFuncionarioService;
    //}

    public AgenteRiscoCBOAppService(IAgenteRiscoCBOService agenteRiscoCBOService)
    {
        _agenteRiscoCBOService = agenteRiscoCBOService;
    }

    public bool Adicionar(AgenteRiscoCBOViewModel agenteRiscoCBOViewModel)
    {
      var agenteRiscoCBO = Mapper.Map<AgenteRiscoCBOViewModel, AgenteRiscoCBO>(agenteRiscoCBOViewModel);

      var duplicado = _agenteRiscoCBOService.Find(e => e.Nome == agenteRiscoCBO.Nome).Where(d => d.Delete == false).Any();
      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _agenteRiscoCBOService.Adicionar(agenteRiscoCBO);
        Commit();
        return true;
      }
    }

    public bool Atualizar(AgenteRiscoCBOViewModel agenteRiscoCBOViewModel)
    {
      var agenteRiscoCBO = Mapper.Map<AgenteRiscoCBOViewModel, AgenteRiscoCBO>(agenteRiscoCBOViewModel);

      var duplicado = _agenteRiscoCBOService.Find(e => e.Nome == agenteRiscoCBO.Nome && e.Delete == false && e.AgenteRiscoCBOId != agenteRiscoCBO.AgenteRiscoCBOId).Any();

      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _agenteRiscoCBOService.Atualizar(agenteRiscoCBO);
        Commit();
        return true;
      }

    }

    public void Dispose()
    {
      _agenteRiscoCBOService.Dispose();
      GC.SuppressFinalize(this);
    }

    public bool Excluir(int id)
    {
      bool existente = _agenteRiscoCBOService.Find(e => e.AgenteRiscoCBOId == id).Any();
      //bool funcionarioUtiliza = _funcionarioService.Find(c => c.EscalaId == id && c.Delete == false).Any();

      //if (existente && !funcionarioUtiliza)
      if (existente)
      {
        BeginTransaction();
        var agenteRiscoCBO = _agenteRiscoCBOService.ObterPorId(id);
        agenteRiscoCBO.Delete = true;
        _agenteRiscoCBOService.Atualizar(agenteRiscoCBO);
        Commit();
        return true;
      }
      return false;
    }

    public IEnumerable<AgenteRiscoCBOViewModel> ObterGrid(int page, string pesquisa)
    {
      return Mapper.Map<IEnumerable<AgenteRiscoCBO>, IEnumerable<AgenteRiscoCBOViewModel>>(_agenteRiscoCBOService.ObterGrid(page, pesquisa));
    }

    public AgenteRiscoCBOViewModel ObterPorId(int id)
    {
      return Mapper.Map<AgenteRiscoCBO, AgenteRiscoCBOViewModel>(_agenteRiscoCBOService.ObterPorId(id));
    }

    public IEnumerable<AgenteRiscoCBOViewModel> ObterTodos()
    {
      return Mapper.Map<IEnumerable<AgenteRiscoCBO>, IEnumerable<AgenteRiscoCBOViewModel>>(_agenteRiscoCBOService.ObterTodos());
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _agenteRiscoCBOService.ObterTotalRegistros(pesquisa);
    }
  }
}
