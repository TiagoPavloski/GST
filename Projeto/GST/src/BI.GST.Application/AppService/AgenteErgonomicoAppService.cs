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
    public class AgenteErgonomicoAppService : BaseAppService, IAgenteErgonomicoAppService
     {
        private readonly IAgenteErgonomicoService _agenteErgonomicoService;

        public AgenteErgonomicoAppService(IAgenteErgonomicoService agenteErgonomicoService)
        {
            _agenteErgonomicoService = agenteErgonomicoService;
        }

        public bool Adicionar(AgenteErgonomicoViewModel agenteErgonomicoViewModel)
        {
            var agenteErgonomico = Mapper.Map<AgenteErgonomicoViewModel, AgenteErgonomico>(agenteErgonomicoViewModel);
            var duplicado = _agenteErgonomicoService.Find(e => e.Nome == agenteErgonomico.Nome).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _agenteErgonomicoService.Adicionar(agenteErgonomico);
                Commit();
                return true;
            }
        }
        public bool Atualizar(AgenteErgonomicoViewModel agenteErgonomicoViewModel)
        {
            var agenteErgonomico = Mapper.Map<AgenteErgonomicoViewModel, AgenteErgonomico>(agenteErgonomicoViewModel);

            var duplicado = _agenteErgonomicoService.Find(e => e.Nome == agenteErgonomico.Nome && e.AgenteErgonomicoId != agenteErgonomico.AgenteErgonomicoId).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _agenteErgonomicoService.Atualizar(agenteErgonomico);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _agenteErgonomicoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _agenteErgonomicoService.Find(e => e.AgenteErgonomicoId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var agenteErgonomico = _agenteErgonomicoService.ObterPorId(id);
                agenteErgonomico.Delete = true;
                _agenteErgonomicoService.Atualizar(agenteErgonomico);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<AgenteErgonomicoViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<AgenteErgonomico>, IEnumerable<AgenteErgonomicoViewModel>>(_agenteErgonomicoService.ObterGrid(page, pesquisa));
        }

        public AgenteErgonomicoViewModel ObterPorId(int id)
        {
            return Mapper.Map<AgenteErgonomico, AgenteErgonomicoViewModel>(_agenteErgonomicoService.ObterPorId(id));
        }

        public IEnumerable<AgenteErgonomicoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<AgenteErgonomico>, IEnumerable<AgenteErgonomicoViewModel>>(_agenteErgonomicoService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteErgonomicoService.ObterTotalRegistros(pesquisa);
        }
    }
}
