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
    public class EPIAppService : BaseAppService, IEPIAppService
    {
        private readonly IEPIService _epiService;

        public EPIAppService(IEPIService epiService)
        {
            _epiService = epiService;
        }

        public bool Adicionar(EPIViewModel epiViewModel)
        {
            var epi = Mapper.Map<EPIViewModel, EPI>(epiViewModel);

            var duplicado = _epiService.Find(e => e.Nome == epi.Nome).Where(d => d.Delete == false).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _epiService.Adicionar(epi);
                Commit();
                return true;
            }
        }

        public bool Atualizar(EPIViewModel epiViewModel)
        {
            var epi = Mapper.Map<EPIViewModel, EPI>(epiViewModel);

            var duplicado = _epiService.Find(e => e.Nome == epi.Nome && e.Delete == false && e.EPIId != epi.EPIId).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _epiService.Atualizar(epi);
                Commit();
                return true;
            }

        }

        public void Dispose()
        {
            _epiService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _epiService.Find(e => e.EPIId == id).Any();
            //bool funcionarioUtiliza = _funcionarioService.Find(c => c.EscalaId == id && c.Delete == false).Any();

            //if (existente && !funcionarioUtiliza)
            if (existente)
            {
                BeginTransaction();
                var epi = _epiService.ObterPorId(id);
                epi.Delete = true;
                _epiService.Atualizar(epi);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<EPIViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<EPI>, IEnumerable<EPIViewModel>>(_epiService.ObterGrid(page, pesquisa));
        }

        public EPIViewModel ObterPorId(int id)
        {
            return Mapper.Map<EPI, EPIViewModel>(_epiService.ObterPorId(id));
        }

        public IEnumerable<EPIViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<EPI>, IEnumerable<EPIViewModel>>(_epiService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _epiService.ObterTotalRegistros(pesquisa);
        }
    }
}
