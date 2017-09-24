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
    public class AgenteBiologicoAppService : BaseAppService, IAgenteBiologicoAppService
    {
        private readonly IAgenteBiologicoService _agenteBiologicoService;

        public AgenteBiologicoAppService(IAgenteBiologicoService agenteBiologicoService)
        {
            _agenteBiologicoService = agenteBiologicoService;
        }

        public bool Adicionar(AgenteBiologicoViewModel agenteBiologicoViewModel)
        {
            var agenteBiologico = Mapper.Map<AgenteBiologicoViewModel, AgenteBiologico>(agenteBiologicoViewModel);
            var duplicado = _agenteBiologicoService.Find(e => e.Nome == agenteBiologico.Nome).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _agenteBiologicoService.Adicionar(agenteBiologico);
                Commit();
                return true;
            }
        }

        public bool Atualizar(AgenteBiologicoViewModel agenteBiologicoViewModel)
        {
            var agenteBiologico = Mapper.Map<AgenteBiologicoViewModel, AgenteBiologico>(agenteBiologicoViewModel);

            var duplicado = _agenteBiologicoService.Find(e => e.Nome == agenteBiologico.Nome && e.AgenteBiologicoId != agenteBiologico.AgenteBiologicoId).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _agenteBiologicoService.Atualizar(agenteBiologico);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _agenteBiologicoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _agenteBiologicoService.Find(e => e.AgenteBiologicoId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var agenteBiologico = _agenteBiologicoService.ObterPorId(id);
                agenteBiologico.Delete = true;
                _agenteBiologicoService.Atualizar(agenteBiologico);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<AgenteBiologicoViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<AgenteBiologico>, IEnumerable<AgenteBiologicoViewModel>>(_agenteBiologicoService.ObterGrid(page, pesquisa));
        }

        public AgenteBiologicoViewModel ObterPorId(int id)
        {
            return Mapper.Map<AgenteBiologico, AgenteBiologicoViewModel>(_agenteBiologicoService.ObterPorId(id));
        }

        public IEnumerable<AgenteBiologicoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<AgenteBiologico>, IEnumerable<AgenteBiologicoViewModel>>(_agenteBiologicoService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteBiologicoService.ObterTotalRegistros(pesquisa);
        }
    }
}
