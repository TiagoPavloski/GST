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
    public class CIPAEmpresaFuncionarioAppService : BaseAppService, ICIPAEmpresaFuncionarioAppService
    {
        private readonly ICIPAEmpresaFuncionarioService _cipaEmpresaFuncionarioService;

        public CIPAEmpresaFuncionarioAppService(ICIPAEmpresaFuncionarioService cipaEmpresaFuncionarioService)
        {
            _cipaEmpresaFuncionarioService = cipaEmpresaFuncionarioService;
        }

        public bool Adicionar(CIPAEmpresaFuncionarioViewModel cipaEmpresaFuncionarioViewModel)
        {
            var cipaEmpresaFunc = Mapper.Map<CIPAEmpresaFuncionarioViewModel, CIPAEmpresaFuncionario>(cipaEmpresaFuncionarioViewModel);

            var duplicado = _cipaEmpresaFuncionarioService.Find(e =>
                (e.Funcionario.CPF == cipaEmpresaFunc.Funcionario.CPF)
                && (e.CipaEmpresaId == cipaEmpresaFunc.CipaEmpresaId)
                && (e.CipaEmpresa.Delete == false)
                && (e.Delete == false)).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _cipaEmpresaFuncionarioService.Adicionar(cipaEmpresaFunc);
                Commit();
                return true;
            }
        }

        public bool Atualizar(CIPAEmpresaFuncionarioViewModel cipaEmpresaFuncionarioViewModel)
        {
            var cipaEmpresaFunc = Mapper.Map<CIPAEmpresaFuncionarioViewModel, CIPAEmpresaFuncionario>(cipaEmpresaFuncionarioViewModel);

            var duplicado = _cipaEmpresaFuncionarioService.Find(e =>
                (e.Funcionario.CPF == cipaEmpresaFunc.Funcionario.CPF)
                && (e.CipaEmpresaId == cipaEmpresaFunc.CipaEmpresaId)
                && (e.CipaEmpresa.Delete == false)
                && (e.Delete == false)
                &&(e.CIPAEmpresaFuncionarioId != cipaEmpresaFunc.CIPAEmpresaFuncionarioId)).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _cipaEmpresaFuncionarioService.Atualizar(cipaEmpresaFunc);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _cipaEmpresaFuncionarioService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _cipaEmpresaFuncionarioService.Find(e => e.CIPAEmpresaFuncionarioId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var cipaEmpresaFunc = _cipaEmpresaFuncionarioService.ObterPorId(id);
                cipaEmpresaFunc.Delete = true;
                _cipaEmpresaFuncionarioService.Atualizar(cipaEmpresaFunc);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<CIPAEmpresaFuncionarioViewModel> ObterGrid(int page, string pesquisa, int cipaEmpresaId)
        {
            return Mapper.Map<IEnumerable<CIPAEmpresaFuncionario>, IEnumerable<CIPAEmpresaFuncionarioViewModel>>(_cipaEmpresaFuncionarioService.ObterGrid(page, pesquisa, cipaEmpresaId));
        }

        public CIPAEmpresaFuncionarioViewModel ObterPorId(int id)
        {
            return Mapper.Map<CIPAEmpresaFuncionario, CIPAEmpresaFuncionarioViewModel>(_cipaEmpresaFuncionarioService.ObterPorId(id));
        }

        public int ObterTotalRegistros(string pesquisa, int cipaEmpresaId)
        {
            return _cipaEmpresaFuncionarioService.ObterTotalRegistros(pesquisa, cipaEmpresaId);
        }
    }
}
