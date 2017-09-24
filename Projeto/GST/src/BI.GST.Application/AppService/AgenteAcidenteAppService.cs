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
    public class AgenteAcidenteAppService : BaseAppService, IAgenteAcidenteAppService
    {
        private readonly IAgenteAcidenteService _agenteAcidenteService;

        public AgenteAcidenteAppService(IAgenteAcidenteService agenteAcidenteService)
        {
            _agenteAcidenteService = agenteAcidenteService;
        }

        public bool Adicionar(AgenteAcidenteViewModel agenteAcidenteViewModel)
        {
            var agenteAcidente = Mapper.Map<AgenteAcidenteViewModel, AgenteAcidente>(agenteAcidenteViewModel);
            var duplicado = _agenteAcidenteService.Find(e => e.Nome == agenteAcidente.Nome).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _agenteAcidenteService.Adicionar(agenteAcidente);
                Commit();
                return true;
            }
        }

        public bool Atualizar(AgenteAcidenteViewModel agenteAcidenteViewModel)
        {
            var agenteAcidente = Mapper.Map<AgenteAcidenteViewModel, AgenteAcidente>(agenteAcidenteViewModel);

            var duplicado = _agenteAcidenteService.Find(e => e.Nome == agenteAcidente.Nome && e.AgenteAcidenteId != agenteAcidente.AgenteAcidenteId).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _agenteAcidenteService.Atualizar(agenteAcidente);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _agenteAcidenteService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _agenteAcidenteService.Find(e => e.AgenteAcidenteId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var agenteAcidente = _agenteAcidenteService.ObterPorId(id);
                agenteAcidente.Delete = true;
                _agenteAcidenteService.Atualizar(agenteAcidente);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<AgenteAcidenteViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<AgenteAcidente>, IEnumerable<AgenteAcidenteViewModel>>(_agenteAcidenteService.ObterGrid(page, pesquisa));
        }

        public AgenteAcidenteViewModel ObterPorId(int id)
        {
            return Mapper.Map<AgenteAcidente, AgenteAcidenteViewModel>(_agenteAcidenteService.ObterPorId(id));
        }

        public IEnumerable<AgenteAcidenteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<AgenteAcidente>, IEnumerable<AgenteAcidenteViewModel>>(_agenteAcidenteService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteAcidenteService.ObterTotalRegistros(pesquisa);
        }
    }
}
