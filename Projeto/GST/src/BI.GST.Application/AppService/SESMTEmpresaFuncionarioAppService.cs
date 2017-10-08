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
    public class SESMTEmpresaFuncionarioAppService : BaseAppService, ISESMTEmpresaFuncionarioAppService
    {
        private readonly ISESMTEmpresaFuncionarioService _sesmtEmpresaFuncionarioService;

        public SESMTEmpresaFuncionarioAppService(ISESMTEmpresaFuncionarioService sesmtEmpresaFuncionariolService)
        {
            _sesmtEmpresaFuncionarioService = sesmtEmpresaFuncionariolService;
        }

        public bool Adicionar(SESMTEmpresaFuncionarioViewModel sesmtEmpresaFuncionarioViewModel)
        {
            var sesmtEmpresaFunc = Mapper.Map<SESMTEmpresaFuncionarioViewModel, SESMTEmpresaFuncionario>(sesmtEmpresaFuncionarioViewModel);

            var duplicado = _sesmtEmpresaFuncionarioService.Find(e => 
                (e.FuncionarioEmpresa.Funcionario.CPF == sesmtEmpresaFunc.FuncionarioEmpresa.Funcionario.CPF)
                && (e.SESMTEmpresaId == sesmtEmpresaFunc.SESMTEmpresaId)
                && (e.SESMTEmpresa.Delete == false)
                && (e.Delete == false)).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _sesmtEmpresaFuncionarioService.Adicionar(sesmtEmpresaFunc);
                Commit();
                return true;
            }
        }

        public bool Atualizar(SESMTEmpresaFuncionarioViewModel sesmtEmpresaFuncionarioViewModel)
        {
            var sesmtEmpresaFunc = Mapper.Map<SESMTEmpresaFuncionarioViewModel, SESMTEmpresaFuncionario>(sesmtEmpresaFuncionarioViewModel);

            var duplicado = _sesmtEmpresaFuncionarioService.Find(e => 
                (e.FuncionarioEmpresa.Funcionario.CPF == sesmtEmpresaFunc.FuncionarioEmpresa.Funcionario.CPF) 
                && (e.SESMTEmpresaId == sesmtEmpresaFunc.SESMTEmpresaId)
                && (e.SESMTEmpresa.Delete == false)
                && (e.Delete == false)).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _sesmtEmpresaFuncionarioService.Atualizar(sesmtEmpresaFunc);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _sesmtEmpresaFuncionarioService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _sesmtEmpresaFuncionarioService.Find(e => e.SESMTEmpresaFuncionarioId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var sesmtEmpresaFunc = _sesmtEmpresaFuncionarioService.ObterPorId(id);
                sesmtEmpresaFunc.Delete = true;
                _sesmtEmpresaFuncionarioService.Atualizar(sesmtEmpresaFunc);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<SESMTEmpresaFuncionarioViewModel> ObterGrid(int page, string pesquisa, int SESMTEmpresaId)
        {
            return Mapper.Map<IEnumerable<SESMTEmpresaFuncionario>, IEnumerable<SESMTEmpresaFuncionarioViewModel>>(_sesmtEmpresaFuncionarioService.ObterGrid(page, pesquisa, SESMTEmpresaId));
        }

        public SESMTEmpresaFuncionarioViewModel ObterPorId(int id)
        {
            return Mapper.Map<SESMTEmpresaFuncionario, SESMTEmpresaFuncionarioViewModel>(_sesmtEmpresaFuncionarioService.ObterPorId(id));
        }

        public int ObterTotalRegistros(string pesquisa, int SESMTEmpresaId)
        {
            return _sesmtEmpresaFuncionarioService.ObterTotalRegistros(pesquisa, SESMTEmpresaId);
        }
    }
}
