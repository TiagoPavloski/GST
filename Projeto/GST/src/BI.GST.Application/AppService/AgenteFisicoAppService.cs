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
    public class AgenteFisicoAppService : BaseAppService, IAgenteFisicoAppService
    {
        private readonly IAgenteFisicoService _agenteFisicoService;

        public AgenteFisicoAppService(IAgenteFisicoService agenteFisicoService)
        {
            _agenteFisicoService = agenteFisicoService;
        }

        public bool Adicionar(AgenteFisicoViewModel agenteFisicoViewModel)
        {
            var agenteFisico = Mapper.Map<AgenteFisicoViewModel, AgenteFisico>(agenteFisicoViewModel);
            var duplicado = _agenteFisicoService.Find(e => e.Nome == agenteFisico.Nome).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _agenteFisicoService.Adicionar(agenteFisico);
                Commit();
                return true;
            }
        }

        public bool Atualizar(AgenteFisicoViewModel agenteFisicoViewModel)
        {
            var agenteFisico = Mapper.Map<AgenteFisicoViewModel, AgenteFisico>(agenteFisicoViewModel);

            var duplicado = _agenteFisicoService.Find(e => e.Nome == agenteFisico.Nome && e.AgenteFisicoId != agenteFisico.AgenteFisicoId).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _agenteFisicoService.Atualizar(agenteFisico);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _agenteFisicoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _agenteFisicoService.Find(e => e.AgenteFisicoId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var agenteFisico = _agenteFisicoService.ObterPorId(id);
                agenteFisico.Delete = true;
                _agenteFisicoService.Atualizar(agenteFisico);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<AgenteFisicoViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<AgenteFisico>, IEnumerable<AgenteFisicoViewModel>>(_agenteFisicoService.ObterGrid(page, pesquisa));
        }

        public AgenteFisicoViewModel ObterPorId(int id)
        {
            return Mapper.Map<AgenteFisico, AgenteFisicoViewModel>(_agenteFisicoService.ObterPorId(id));
        }

        public IEnumerable<AgenteFisicoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<AgenteFisico>, IEnumerable<AgenteFisicoViewModel>>(_agenteFisicoService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteFisicoService.ObterTotalRegistros(pesquisa);
        }
    }
}
