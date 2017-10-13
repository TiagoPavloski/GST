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
    public class AgentePPRAAppService : BaseAppService, IAgentePPRAAppService
    {
        private readonly IAgentePPRAService _agentePPRAService;

        public AgentePPRAAppService(IAgentePPRAService agentePPRAService)
        {
            _agentePPRAService = agentePPRAService;
        }

        public bool Adicionar(AgentePPRAViewModel agentePPRAViewModel)
        {
            var agentePPRA = Mapper.Map<AgentePPRAViewModel, AgentePPRA>(agentePPRAViewModel);

            var duplicado = _agentePPRAService.Find(x => (x.MeioPropagacaoId == agentePPRA.MeioPropagacaoId)
                && (x.AgenteAmbientalId == agentePPRA.AgenteAmbientalId)
                && (x.PPRAId == agentePPRA.PPRAId)
                && (x.Delete == false)).Any();
            if (duplicado)
                return false;
            else
            {
                BeginTransaction();
                _agentePPRAService.Adicionar(agentePPRA);
                Commit();
                return true;
            }

        }

        public bool Atualizar(AgentePPRAViewModel agentePPRAViewModel)
        {
            var agentePPRA = Mapper.Map<AgentePPRAViewModel, AgentePPRA>(agentePPRAViewModel);

            var duplicado = _agentePPRAService.Find(x => (x.MeioPropagacaoId == agentePPRA.MeioPropagacaoId)
                 && (x.AgenteAmbientalId == agentePPRA.AgenteAmbientalId)
                 && (x.PPRAId == agentePPRA.PPRAId)
                 && (x.Delete == false)
                 && (x.AgentePPRAId != agentePPRA.AgentePPRAId)).Any();
            if (duplicado)
                return false;
            else
            {
                BeginTransaction();
                _agentePPRAService.Atualizar(agentePPRA);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _agentePPRAService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _agentePPRAService.Find(e => e.AgentePPRAId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var agentePPRA = _agentePPRAService.ObterPorId(id);
                agentePPRA.Delete = true;
                _agentePPRAService.Atualizar(agentePPRA);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<AgentePPRAViewModel> ObterGrid(int page, string pesquisa, int ppraId)
        {
            return Mapper.Map<IEnumerable<AgentePPRA>, IEnumerable<AgentePPRAViewModel>>(_agentePPRAService.ObterGrid(page, pesquisa, ppraId));
        }

        public AgentePPRAViewModel ObterPorId(int id)
        {
            return Mapper.Map<AgentePPRA, AgentePPRAViewModel>(_agentePPRAService.ObterPorId(id));
        }

        public int ObterTotalRegistros(string pesquisa, int ppraId)
        {
            return _agentePPRAService.ObterTotalRegistros(pesquisa, ppraId);
        }
    }
}
