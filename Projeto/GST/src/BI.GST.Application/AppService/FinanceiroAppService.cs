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
    public class FinanceiroAppService : BaseAppService, IFinanceiroAppService
    {
        private readonly IFinanceiroService _financeiroService;

        public FinanceiroAppService(IFinanceiroService financeiroService)
        {
            _financeiroService = financeiroService;
        }

        public bool Adicionar(FinanceiroViewModel financeiroViewModel)
        {
            var financeiro = Mapper.Map<FinanceiroViewModel, Financeiro>(financeiroViewModel);

            var duplicado = _financeiroService.Find(e => e.Titulo == financeiro.Titulo).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                financeiro.Status = "0";
                _financeiroService.Adicionar(financeiro);
                Commit();
                return true;
            }
        }

        public bool Atualizar(FinanceiroViewModel financeiroViewModel)
        {
            var financeiro = Mapper.Map<FinanceiroViewModel, Financeiro>(financeiroViewModel);

            var duplicado = _financeiroService.Find(e => e.Titulo == financeiro.Titulo &&  e.FinanceiroId != financeiro.FinanceiroId).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _financeiroService.Atualizar(financeiro);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _financeiroService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _financeiroService.Find(e => e.FinanceiroId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var financeiro = _financeiroService.ObterPorId(id);
                financeiro.Delete = true;
                _financeiroService.Atualizar(financeiro);
                Commit();
                return true;
            }
            return false;
        }

        public List<FinanceiroViewModel> ObterContasPorDataVencimento(string dataInicial, string dataFinal)
        {
            return Mapper.Map<List<Financeiro>, List<FinanceiroViewModel>>(_financeiroService.ObterContasPorDataVencimento(dataInicial, dataFinal));
        }

        public FinanceiroViewModel ObterContasPorId(int id)
        {
            return Mapper.Map<Financeiro, FinanceiroViewModel>(_financeiroService.ObterPorId(id));
        }

        public List<FinanceiroViewModel> ObterContasPorInstituicao(string instituicao)
        {
            return Mapper.Map<List<Financeiro>, List<FinanceiroViewModel>>(_financeiroService.ObterContasPorInstituicao(instituicao));
        }

        public List<FinanceiroViewModel> ObterContasPorOperacao(int operacao)
        {
            return Mapper.Map<List<Financeiro>, List<FinanceiroViewModel>>(_financeiroService.ObterContasPorOperacao(operacao));
        }

        public IEnumerable<FinanceiroViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<Financeiro>, IEnumerable<FinanceiroViewModel>>(_financeiroService.ObterGrid(page, pesquisa));
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _financeiroService.ObterTotalRegistros(pesquisa);
        }
    }
}
