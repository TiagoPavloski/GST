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
  public class AgenteCausadorCBOAppService : BaseAppService, IAgenteCausadorCBOAppService
  {
    private readonly IAgenteCausadorCBOService _agenteCausadorCBOService;

    // USAR ESTE QUANDO IMPLEMENTAR RISCOSCBO E RISCOSFUNCIONARIO
    //private readonly IRiscosCBOService _riscosCBOService;
    //private readonly IRiscosFuncionarioService _riscosFuncionarioService;

    //public AgenteCausadorCBOAppService(IAgenteCausadorCBOService agenteCausadorCBOService, IRiscosCBOService riscosCBOService, IRiscosFuncionarioService riscosFuncionarioService)
    //{
    //  _agenteCausadorCBOService = agenteCausadorCBOService;
    //  _riscosCBOService = riscosCBOService;
    //  _riscosFuncionarioService = riscosFuncionarioService;
    //}

    public AgenteCausadorCBOAppService(IAgenteCausadorCBOService agenteCausadorCBOService)
    {
        _agenteCausadorCBOService = agenteCausadorCBOService;
    }

    public bool Adicionar(AgenteCausadorCBOViewModel agenteCausadorCBOViewModel)
    {
      var agenteCausadorCBO = Mapper.Map<AgenteCausadorCBOViewModel, AgenteCausadorCBO>(agenteCausadorCBOViewModel);

      var duplicado = _agenteCausadorCBOService.Find(e => e.Nome == agenteCausadorCBO.Nome).Where(d => d.Delete == false).Any();
      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _agenteCausadorCBOService.Adicionar(agenteCausadorCBO);
        Commit();
        return true;
      }
    }

    public bool Atualizar(AgenteCausadorCBOViewModel agenteCausadorCBOViewModel)
    {
      var agenteCausadorCBO = Mapper.Map<AgenteCausadorCBOViewModel, AgenteCausadorCBO>(agenteCausadorCBOViewModel);

      var duplicado = _agenteCausadorCBOService.Find(e => e.Nome == agenteCausadorCBO.Nome && e.Delete == false && e.AgenteCausadorCBOId != agenteCausadorCBO.AgenteCausadorCBOId).Any();

      if (duplicado)
      {
        return false;
      }
      else
      {
        BeginTransaction();
        _agenteCausadorCBOService.Atualizar(agenteCausadorCBO);
        Commit();
        return true;
      }

    }

    public void Dispose()
    {
      _agenteCausadorCBOService.Dispose();
      GC.SuppressFinalize(this);
    }

    public bool Excluir(int id)
    {
      bool existente = _agenteCausadorCBOService.Find(e => e.AgenteCausadorCBOId == id).Any();
      //bool funcionarioUtiliza = _funcionarioService.Find(c => c.EscalaId == id && c.Delete == false).Any();

      //if (existente && !funcionarioUtiliza)
      if (existente)
      {
        BeginTransaction();
        var agenteCausadorCBO = _agenteCausadorCBOService.ObterPorId(id);
        agenteCausadorCBO.Delete = true;
        _agenteCausadorCBOService.Atualizar(agenteCausadorCBO);
        Commit();
        return true;
      }
      return false;
    }

    public IEnumerable<AgenteCausadorCBOViewModel> ObterGrid(int page, string pesquisa)
    {
      return Mapper.Map<IEnumerable<AgenteCausadorCBO>, IEnumerable<AgenteCausadorCBOViewModel>>(_agenteCausadorCBOService.ObterGrid(page, pesquisa));
    }

    public AgenteCausadorCBOViewModel ObterPorId(int id)
    {
      return Mapper.Map<AgenteCausadorCBO, AgenteCausadorCBOViewModel>(_agenteCausadorCBOService.ObterPorId(id));
    }

    public IEnumerable<AgenteCausadorCBOViewModel> ObterTodos()
    {
      return Mapper.Map<IEnumerable<AgenteCausadorCBO>, IEnumerable<AgenteCausadorCBOViewModel>>(_agenteCausadorCBOService.ObterTodos());
    }

    public int ObterTotalRegistros(string pesquisa)
    {
      return _agenteCausadorCBOService.ObterTotalRegistros(pesquisa);
    }
  }
}
