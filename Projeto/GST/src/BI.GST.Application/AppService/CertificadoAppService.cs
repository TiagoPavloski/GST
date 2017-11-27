using AutoMapper;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BI.GST.Application.AppService
{
    public class CertificadoAppService : BaseAppService, ICertificadoAppService
    {
        private readonly ICertificadoService _certificadoService;
        private readonly IFuncionarioService _funcionarioService;

        public CertificadoAppService(ICertificadoService certificadoService, IFuncionarioService funcionarioservice)
        {
            _certificadoService = certificadoService;
            _funcionarioService = funcionarioservice;
        }
        public List<CertificadoViewModel> Adicionar(CertificadoViewModel certificadoViewModel, int[] funcionarios)
        {
            var certificado = Mapper.Map<CertificadoViewModel, Certificado>(certificadoViewModel);

            //Fazer validação de repetido

            List<CertificadoViewModel> certificados = new List<CertificadoViewModel>();
            CertificadoViewModel certificadovm;

            certificado.DataEmissao = DateTime.Now.Year.ToString() + "-"
                + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                certificado.InstituicaoCursoId = 1;

            BeginTransaction();
            foreach (var f in funcionarios)
            {
                certificado.FuncionarioId = f;
                _certificadoService.Adicionar(certificado, certificadoViewModel.TipoCursoId, certificadoViewModel.DataRealizacao);
                certificadovm = Mapper.Map<Certificado, CertificadoViewModel>(certificado);
                certificadovm.Funcionario = _funcionarioService.ObterPorId(f);
                certificados.Add(certificadovm);
            }
            Commit();

            return certificados;
        }

        public string GerarHtml(List<CertificadoViewModel> certificados)
        {
            string corpo = "oi";
            foreach (CertificadoViewModel c in certificados)
            {
                //corpo += 
            }

            return corpo;
        }

        public bool Atualizar(CertificadoViewModel cursoViewModel)
        {
            var Curso = Mapper.Map<CertificadoViewModel, Certificado>(cursoViewModel);

            BeginTransaction();
            _certificadoService.Atualizar(Curso);
            Commit();
            return true;
        }


        public void Dispose()
        {
            _certificadoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _certificadoService.Find(e => e.CertificadoId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var certificado = _certificadoService.ObterPorId(id);
                certificado.Delete = true;
                _certificadoService.Atualizar(certificado);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<CertificadoViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<Certificado>, IEnumerable<CertificadoViewModel>>(_certificadoService.ObterGrid(page, pesquisa));
        }

        public CertificadoViewModel ObterPorId(int id)
        {
            return Mapper.Map<Certificado, CertificadoViewModel>(_certificadoService.ObterPorId(id));
        }

        public IEnumerable<CertificadoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Certificado>, IEnumerable<CertificadoViewModel>>(_certificadoService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _certificadoService.ObterTotalRegistros(pesquisa);
        }
    }
}
