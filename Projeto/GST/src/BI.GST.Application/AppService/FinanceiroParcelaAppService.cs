using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using BI.GST.Domain.Entities;
using AutoMapper;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;

namespace BI.GST.Application.AppService
{
    public class FinanceiroParcelaAppService : BaseAppService, IFinanceiroParcelaAppService
    {
        private readonly IFinanceiroParcelaService _financeiroParcelaService;

        public FinanceiroParcelaAppService(IFinanceiroParcelaService financeiroParcelaService)
        {
            _financeiroParcelaService = financeiroParcelaService;
        }

        public bool Adicionar(FinanceiroParcelaViewModel financeiroParcelaViewModel)
        {
            var parcela = Mapper.Map<FinanceiroParcelaViewModel, FinanceiroParcela>(financeiroParcelaViewModel);

            var duplicado = _financeiroParcelaService.Find(e => (e.Parcela == parcela.Parcela)
                                                           && (e.FinanceiroId == parcela.FinanceiroId)).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _financeiroParcelaService.Adicionar(parcela);
                Commit();
                return true;
            }
        }

        public bool Atualizar(FinanceiroParcelaViewModel financeiroParcelaViewModel)
        {
            var parcela = Mapper.Map<FinanceiroParcelaViewModel, FinanceiroParcela>(financeiroParcelaViewModel);

            var duplicado = _financeiroParcelaService.Find(e => (e.Parcela == parcela.Parcela)
                                                           && (e.FinanceiroId == parcela.FinanceiroId)
                                                           && (e.FinanceiroParcelaId != parcela.FinanceiroParcelaId)).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _financeiroParcelaService.Atualizar(parcela);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _financeiroParcelaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _financeiroParcelaService.Find(e => e.FinanceiroParcelaId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var parcela = _financeiroParcelaService.ObterPorId(id);
                parcela.Delete = true;
                _financeiroParcelaService.Atualizar(parcela);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<FinanceiroParcelaViewModel> ObterGrid(int page, string pesquisa, int idFinanceiro)
        {
            return Mapper.Map<IEnumerable<FinanceiroParcela>, IEnumerable<FinanceiroParcelaViewModel>>(_financeiroParcelaService.ObterGrid(page, pesquisa, idFinanceiro));
        }

        public int ObterTotalRegistros(string pesquisa, int idFinanceiro)
        {
            return _financeiroParcelaService.ObterTotalRegistros(pesquisa, idFinanceiro);
        }
    }
}
