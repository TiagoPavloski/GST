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
    public class AgenteQuimicoAppService : BaseAppService, IAgenteQuimicoAppService
    {
        private readonly IAgenteQuimicoService _agenteQuimicoService;

        public AgenteQuimicoAppService(IAgenteQuimicoService agenteQuimicoService)
        {
            _agenteQuimicoService = agenteQuimicoService;
        }

        public bool Adicionar(AgenteQuimicoViewModel agenteQuimicoViewModel)
        {
            var agenteQuimico = Mapper.Map<AgenteQuimicoViewModel, AgenteQuimico>(agenteQuimicoViewModel);
            var duplicado = _agenteQuimicoService.Find(e => e.Nome == agenteQuimico.Nome).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _agenteQuimicoService.Adicionar(agenteQuimico);
                Commit();
                return true;
            }
        }

        public bool Atualizar(AgenteQuimicoViewModel agenteQuimicoViewModel)
        {
            var agenteQuimico = Mapper.Map<AgenteQuimicoViewModel, AgenteQuimico>(agenteQuimicoViewModel);

            var duplicado = _agenteQuimicoService.Find(e => e.Nome == agenteQuimico.Nome && e.AgenteQuimicoId != agenteQuimico.AgenteQuimicoId).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _agenteQuimicoService.Atualizar(agenteQuimico);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _agenteQuimicoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _agenteQuimicoService.Find(e => e.AgenteQuimicoId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var agenteQuimico = _agenteQuimicoService.ObterPorId(id);
                agenteQuimico.Delete = true;
                _agenteQuimicoService.Atualizar(agenteQuimico);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<AgenteQuimicoViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<AgenteQuimico>, IEnumerable<AgenteQuimicoViewModel>>(_agenteQuimicoService.ObterGrid(page, pesquisa));
        }

        public AgenteQuimicoViewModel ObterPorId(int id)
        {
            return Mapper.Map<AgenteQuimico, AgenteQuimicoViewModel>(_agenteQuimicoService.ObterPorId(id));
        }

        public IEnumerable<AgenteQuimicoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<AgenteQuimico>, IEnumerable<AgenteQuimicoViewModel>>(_agenteQuimicoService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteQuimicoService.ObterTotalRegistros(pesquisa);
        }
    }
}
