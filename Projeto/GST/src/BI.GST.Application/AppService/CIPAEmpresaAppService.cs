using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using AutoMapper;
using BI.GST.Domain.Entities;

namespace BI.GST.Application.AppService
{
    public class CIPAEmpresaAppService : BaseAppService, ICIPAEmpresaAppService
    {
        private readonly ICIPAEmpresaService _cipaEmpresaService;
        private readonly ICIPAEmpresaFuncionarioAppService _cipaEmpresaFuncionarioAppService;
        private readonly IFuncionarioAppService _funcionarioAppService;

        public CIPAEmpresaAppService(ICIPAEmpresaService cipaEmpresaService, ICIPAEmpresaFuncionarioAppService cipaEmpresaFuncionarioAppService, IFuncionarioAppService funcionarioAppService)
        {
            _cipaEmpresaService = cipaEmpresaService;
            _cipaEmpresaFuncionarioAppService = cipaEmpresaFuncionarioAppService;
            _funcionarioAppService = funcionarioAppService;

        }

        public string Adicionar(ref CIPAEmpresaViewModel cipaEmpresaViewModel, int[] FuncionariosEfetivos, int[] FuncionariosSuplentes)
        {
            var cipaEmpresa = Mapper.Map<CIPAEmpresaViewModel, CIPAEmpresa>(cipaEmpresaViewModel);

            var result = VerificarFuncionarios(ref cipaEmpresa, FuncionariosEfetivos, FuncionariosSuplentes);

            if (result != "")
            {
                return result;
            }

            var duplicado = _cipaEmpresaService.Find(e =>
                (e.EmpresaId == cipaEmpresa.EmpresaId)
                && (e.Ano == cipaEmpresa.Ano)
                && (e.Delete == false)).Any();
            if (duplicado)
            {
                return "CIPA já cadastrada para esta empresa e ano";
            }
            else
            {
                BeginTransaction();
                _cipaEmpresaService.Adicionar(cipaEmpresa);
                Commit();
                return "";
            }
        }

        public string Atualizar(ref CIPAEmpresaViewModel cipaEmpresaViewModel, int[] FuncionariosEfetivos, int[] FuncionariosSuplentes)
        {
            var cipaEmpresa = Mapper.Map<CIPAEmpresaViewModel, CIPAEmpresa>(cipaEmpresaViewModel);

            var result = VerificarFuncionarios(ref cipaEmpresa, FuncionariosEfetivos, FuncionariosSuplentes);

            if (result != "")
            {
                return result;
            }

            var duplicado = _cipaEmpresaService.Find(e =>
                (e.EmpresaId == cipaEmpresa.EmpresaId)
                && (e.Ano == cipaEmpresa.Ano)
                && (e.Delete == false)
                && (e.CipaEmpresaID != cipaEmpresa.CipaEmpresaID)).Any();
            if (duplicado)
            {
                return "CIPA já cadastrada para esta empresa e ano";
            }
            else
            {
                BeginTransaction();
                _cipaEmpresaService.Atualizar(cipaEmpresa);
                Commit();
                return "";
            }
        }

        public void Dispose()
        {
            _cipaEmpresaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _cipaEmpresaService.Find(e => e.CipaEmpresaID == id).Any();
            if (existente)
            {
                BeginTransaction();
                var cipaEmpresa = _cipaEmpresaService.ObterPorId(id);
                cipaEmpresa.Delete = true;
                _cipaEmpresaService.Atualizar(cipaEmpresa);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<CIPAEmpresaViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<CIPAEmpresa>, IEnumerable<CIPAEmpresaViewModel>>(_cipaEmpresaService.ObterGrid(page, pesquisa));
        }

        public CIPAEmpresaViewModel ObterPorId(int id)
        {
            return Mapper.Map<CIPAEmpresa, CIPAEmpresaViewModel>(_cipaEmpresaService.ObterPorId(id));
        }

        public IEnumerable<CIPAEmpresaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<CIPAEmpresa>, IEnumerable<CIPAEmpresaViewModel>>(_cipaEmpresaService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _cipaEmpresaService.ObterTotalRegistros(pesquisa);
        }

        public string VerificarFuncionarios(ref CIPAEmpresa cipaEmpresa, int[] FuncionariosEfetivos, int[] FuncionariosSuplentes)
        {
            Funcionario funcionario = new Funcionario();

            if (FuncionariosEfetivos.Count() != cipaEmpresa.NumeroFuncionariosEfetivos)
                return "Quantidade de funcionários efetivos selecionados incompatível com número indicado";

            if (FuncionariosSuplentes.Count() != cipaEmpresa.NumeroFuncionariosSuplentes)
                return "Quantidade de funcionários suplentes selecionados incompatível com número indicado";

            foreach (var id in FuncionariosEfetivos)
            {
                bool reeleito = false;
                bool eleito = false;

                funcionario = Mapper.Map<FuncionarioViewModel, Funcionario>(_funcionarioAppService.ObterPorId(id));
                if (FuncionariosSuplentes.Contains(id))
                    return funcionario.Nome + " não pode estar na lista de efetivos e suplentes da CIPA ao mesmo tempo";

                var listaFuncionariosCipa = _cipaEmpresaFuncionarioAppService.BuscarFuncionarioCIPAPorEmpresa(cipaEmpresa.EmpresaId, id);

                foreach (var funcionarioCipa in listaFuncionariosCipa)
                {
                    if (funcionarioCipa.CipaEmpresaId != cipaEmpresa.CipaEmpresaID)
                    {
                        eleito = true;
                        if (funcionarioCipa.Reeleito)
                            reeleito = true;
                    }

                    if (reeleito)
                        return funcionario.Nome + " não pode ser selecionado como efetivo pois ele já foi reeleito na cipa do ano: " + funcionarioCipa.CipaEmpresa.Ano;
                }

                CIPAEmpresaFuncionario cipaFuncionario = new CIPAEmpresaFuncionario();
                cipaFuncionario.FuncionarioId = funcionario.FuncionarioId;
                cipaFuncionario.Efetivo = true;
                cipaFuncionario.Reeleito = eleito;
                cipaEmpresa.CIPAEmpresaFuncionarios.Add(cipaFuncionario);
            }

            foreach (var id in FuncionariosSuplentes)
            {
                bool reeleito = false;
                bool eleito = false;

                funcionario = Mapper.Map<FuncionarioViewModel, Funcionario>(_funcionarioAppService.ObterPorId(id));

                var listaFuncionariosCipa = _cipaEmpresaFuncionarioAppService.BuscarFuncionarioCIPAPorEmpresa(cipaEmpresa.EmpresaId, id);

                foreach (var funcionarioCipa in listaFuncionariosCipa)
                {
                    if (funcionarioCipa.CipaEmpresaId != cipaEmpresa.CipaEmpresaID)
                    {
                        eleito = true;
                        if (funcionarioCipa.Reeleito)
                            reeleito = true;
                    }
                    if (reeleito)
                        return funcionario.Nome + " não pode ser selecionado como suplente pois ele já foi reeleito na cipa do ano: " + funcionarioCipa.CipaEmpresa.Ano;
                }

                CIPAEmpresaFuncionario cipaFuncionario = new CIPAEmpresaFuncionario();
                cipaFuncionario.FuncionarioId = funcionario.FuncionarioId;
                cipaFuncionario.Efetivo = false;
                cipaFuncionario.Reeleito = eleito;
                cipaEmpresa.CIPAEmpresaFuncionarios.Add(cipaFuncionario);
            }

            return "";
        }
    }
}
