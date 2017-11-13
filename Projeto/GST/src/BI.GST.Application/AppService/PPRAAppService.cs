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
    public class PPRAAppService : BaseAppService, IPPRAAppService
    {
        private readonly IPPRAService _ppraService;
        private readonly IMeioPropagacaoAppService _meioPropagacaoAppService;
        private readonly IAgenteAmbientalAppService _agenteAmbientalAppService;

        public PPRAAppService(IPPRAService ppraService, IMeioPropagacaoAppService meioPropagacaoAppService, IAgenteAmbientalAppService agenteAmbientalAppService)
        {
            _ppraService               = ppraService;
            _meioPropagacaoAppService  = meioPropagacaoAppService;
            _agenteAmbientalAppService = agenteAmbientalAppService;
        }

        public bool Adicionar(PPRAViewModel pPRAViewModel, List<AgentePPRAViewModel> agentePPRAViewModel, List<CronogramaDeAcoesViewModel> cronogramaDeAcoesViewModel)
        {
            var ppra = Mapper.Map<PPRAViewModel, PPRA>(pPRAViewModel);

            ppra.AgentesPPRA = Mapper.Map<List<AgentePPRAViewModel>, List<AgentePPRA>>(agentePPRAViewModel);
            ppra.CronogramasDeAcao = Mapper.Map<List<CronogramaDeAcoesViewModel>, List<CronogramaDeAcoes>>(cronogramaDeAcoesViewModel);

            BeginTransaction();
            _ppraService.Adicionar(ppra);
            Commit();
            return true;
        }

        public bool Atualizar(PPRAViewModel pPRAViewModel)
        {
            var ppra = Mapper.Map<PPRAViewModel, PPRA>(pPRAViewModel);

            BeginTransaction();
            _ppraService.Atualizar(ppra);
            Commit();
            return true;
        }

        public void Dispose()
        {
            _ppraService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _ppraService.Find(e => e.PPRAId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var agenteAmbiental = _ppraService.ObterPorId(id);
                agenteAmbiental.Delete = true;
                _ppraService.Atualizar(agenteAmbiental);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<PPRAViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<PPRA>, IEnumerable<PPRAViewModel>>(_ppraService.ObterGrid(page, pesquisa));
        }

        public PPRAViewModel ObterPorId(int id)
        {
            return Mapper.Map<PPRA, PPRAViewModel>(_ppraService.ObterPorId(id));
        }

        public IEnumerable<PPRAViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<PPRA>, IEnumerable<PPRAViewModel>>(_ppraService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _ppraService.ObterTotalRegistros(pesquisa);
        }
    }
}
