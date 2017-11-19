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

        public string Adicionar(FinanceiroViewModel financeiroViewModel, List<FinanceiroParcelaViewModel> parcelaViewModel)
        {
           var financeiro = Mapper.Map<FinanceiroViewModel, Financeiro>(financeiroViewModel);
           var result = ValidarParcelas(ref financeiro, ref parcelaViewModel);

           if (result != "")
              return result;

            var duplicado = _financeiroService.Find(e => (e.Titulo == financeiro.Titulo)
                                                      && (e.Delete == false)).Any();
            if (duplicado)
            {
                return "Atenção, já existe um título com esses dados cadastrado";
            }
            else
            {
                BeginTransaction();
                _financeiroService.Adicionar(financeiro);
                Commit();
                return "";
            }
        }

        public string Atualizar(FinanceiroViewModel financeiroViewModel, List<FinanceiroParcelaViewModel> parcelaViewModel)
        {
            var financeiro = Mapper.Map<FinanceiroViewModel, Financeiro>(financeiroViewModel);
            var result = ValidarParcelas(ref financeiro, ref parcelaViewModel);

            if (result != "")
                return result;

            var duplicado = _financeiroService.Find(e => (e.Titulo == financeiro.Titulo)
                                                    && (e.FinanceiroId != financeiro.FinanceiroId)
                                                    && (e.Delete == false)).Any();
            if (duplicado)
            {
                return "Atenção, já existe um título com esses dados cadastrado";
            }
            else
            {
                BeginTransaction();
                _financeiroService.Atualizar(financeiro);
                Commit();
                return "";
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

        public string ValidarParcelas(ref Financeiro financeiro, ref List<FinanceiroParcelaViewModel> parcelaViewModel)
        {
            double valorTotalParcelas = 0;
            string errosParcelas = "";
            var dataOperacao = DateTime.Parse(financeiro.DataOperacao);
            Boolean parcelasPagas = true;

            if (parcelaViewModel == null)
            {
                return "Atenção, o título precisa ter no mínimo uma parcela";
            }

            List<FinanceiroParcela> parcelas = new List<FinanceiroParcela>();
            foreach (var item in parcelaViewModel)
            {
                if (item.ValorParcela <= 0)
                    errosParcelas = errosParcelas + "O valor da Parcela: " + item.Parcela + " tem que ser maior que zero ";
                DateTime dataQuitacao = new DateTime();
                DateTime dataVencimento = new DateTime();

                if (item.DataVencimento != null)
                    dataVencimento = DateTime.Parse(item.DataVencimento);

                if (item.DataQuitacao != null)
                    dataQuitacao = DateTime.Parse(item.DataQuitacao);

                if (dataVencimento < dataOperacao)
                    errosParcelas = errosParcelas + "Parcela: " + item.Parcela + " Tem data de vencimento anterior a data de operação do título. ";

                if (item.DataQuitacao != null)
                    item.Pago = true;
                else
                {
                    parcelasPagas = false;
                    item.Pago = false;
                }
                   
                if (dataQuitacao < dataOperacao && item.DataQuitacao != null)
                    errosParcelas = errosParcelas + "Parcela: " + item.Parcela + " Tem data de quitação preenchida anterior a data de operação do título. ";

                valorTotalParcelas = valorTotalParcelas + item.ValorParcela;
                parcelas.Add(Mapper.Map<FinanceiroParcelaViewModel, FinanceiroParcela>(item));
            }

            if (parcelasPagas == true)
                financeiro.Status = "1";
            else
                financeiro.Status = "0";

            financeiro.Parcelas = parcelas;

            if (errosParcelas != "")
            {
                return errosParcelas;
            }

            if (valorTotalParcelas != financeiro.Valor)
            {
                return "Atenção, a soma do valor das parcelas não condiz com o valor do título";
            }

            return "";
        }
    }
}
