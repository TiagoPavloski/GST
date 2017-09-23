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
    public class AgenteAmbientalAppService : BaseAppService, IAgenteAmbientalAppService
    {
        private readonly IAgenteAmbientalService _agenteAmbientalService;

        public AgenteAmbientalAppService(IAgenteAmbientalService agenteAmbientalService)
        {
            _agenteAmbientalService = agenteAmbientalService;
        }

        public bool Adicionar(AgenteAmbientalViewModel agenteAmbientalViewModel)
        {
            var agenteAmbiental = Mapper.Map<AgenteAmbientalViewModel, AgenteAmbiental>(agenteAmbientalViewModel);

            BeginTransaction();
            _agenteAmbientalService.Adicionar(agenteAmbiental);
            Commit();
            return true;
        }

        public bool Atualizar(AgenteAmbientalViewModel agenteAmbientalViewModel)
        {
            var agenteAmbiental = Mapper.Map<AgenteAmbientalViewModel, AgenteAmbiental>(agenteAmbientalViewModel);

            BeginTransaction();
            _agenteAmbientalService.Atualizar(agenteAmbiental);
            Commit();
            return true;
        }

        public void Dispose()
        {
            _agenteAmbientalService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _agenteAmbientalService.Find(e => e.AgenteAmbientalId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var agenteAmbiental = _agenteAmbientalService.ObterPorId(id);
                agenteAmbiental.Delete = true;
                _agenteAmbientalService.Atualizar(agenteAmbiental);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<AgenteAmbientalViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<AgenteAmbiental>, IEnumerable<AgenteAmbientalViewModel>>(_agenteAmbientalService.ObterGrid(page, pesquisa));
        }

        public AgenteAmbientalViewModel ObterPorId(int id)
        {
            return Mapper.Map<AgenteAmbiental, AgenteAmbientalViewModel>(_agenteAmbientalService.ObterPorId(id));
        }

        public IEnumerable<AgenteAmbientalViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<AgenteAmbiental>, IEnumerable<AgenteAmbientalViewModel>>(_agenteAmbientalService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteAmbientalService.ObterTotalRegistros(pesquisa);
        }
    }
}
