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

        public CIPAEmpresaAppService(ICIPAEmpresaService cipaEmpresaService)
        {
            _cipaEmpresaService = cipaEmpresaService;
        }

        public bool Adicionar(CIPAEmpresaViewModel cipaEmpresaViewModel)
        {
            var cipaEmpresa = Mapper.Map<CIPAEmpresaViewModel, CIPAEmpresa>(cipaEmpresaViewModel);

            var duplicado = _cipaEmpresaService.Find(e =>
                (e.EmpresaId == cipaEmpresa.EmpresaId)
                && (e.Ano == cipaEmpresa.Ano)
                && (e.Delete == false)).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _cipaEmpresaService.Adicionar(cipaEmpresa);
                Commit();
                return true;
            }
        }

        public bool Atualizar(CIPAEmpresaViewModel cipaEmpresaViewModel)
        {
            var cipaEmpresa = Mapper.Map<CIPAEmpresaViewModel, CIPAEmpresa>(cipaEmpresaViewModel);

            var duplicado = _cipaEmpresaService.Find(e =>
                (e.EmpresaId == cipaEmpresa.EmpresaId)
                && (e.Ano == cipaEmpresa.Ano)
                && (e.Delete == false)
                &&(e.CipaEmpresaID != cipaEmpresa.CipaEmpresaID)).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _cipaEmpresaService.Atualizar(cipaEmpresa);
                Commit();
                return true;
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
    }
}
