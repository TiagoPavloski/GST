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
    public class SESMTEmpresaAppService : BaseAppService, ISESMTEmpresaAppService
    {
        private readonly ISESMTEmpresaService _sesmtEmpresaService;

        public SESMTEmpresaAppService(ISESMTEmpresaService sesmtEmpresaService)
        {
            _sesmtEmpresaService = sesmtEmpresaService;
        }

        public bool Adicionar(SESMTEmpresaViewModel sesmtEmpresaViewModel)
        {
            var sesmtEmpresa = Mapper.Map<SESMTEmpresaViewModel, SESMTEmpresa>(sesmtEmpresaViewModel);

            var duplicado = _sesmtEmpresaService.Find(e =>
                (e.EmpresaId == sesmtEmpresa.EmpresaId)
                && (e.Ano == sesmtEmpresa.Ano)
                && (e.Delete == false)).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _sesmtEmpresaService.Adicionar(sesmtEmpresa);
                Commit();
                return true;
            }
        }

        public bool Atualizar(SESMTEmpresaViewModel sesmtEmpresaViewModel)
        {
            var sesmtEmpresa = Mapper.Map<SESMTEmpresaViewModel, SESMTEmpresa>(sesmtEmpresaViewModel);

            var duplicado = _sesmtEmpresaService.Find(e =>
                (e.EmpresaId == sesmtEmpresa.EmpresaId)
                && (e.Ano == sesmtEmpresa.Ano)
                && (e.Delete == false)
                &&(e.SESMTEmpresaID != sesmtEmpresa.SESMTEmpresaID)).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _sesmtEmpresaService.Atualizar(sesmtEmpresa);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _sesmtEmpresaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _sesmtEmpresaService.Find(e => e.SESMTEmpresaID == id).Any();
            if (existente)
            {
                BeginTransaction();
                var sesmtEmpresa = _sesmtEmpresaService.ObterPorId(id);
                sesmtEmpresa.Delete = true;
                _sesmtEmpresaService.Atualizar(sesmtEmpresa);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<SESMTEmpresaViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<SESMTEmpresa>, IEnumerable<SESMTEmpresaViewModel>>(_sesmtEmpresaService.ObterGrid(page, pesquisa));
        }

        public SESMTEmpresaViewModel ObterPorId(int id)
        {
            return Mapper.Map<SESMTEmpresa, SESMTEmpresaViewModel>(_sesmtEmpresaService.ObterPorId(id));
        }

        public IEnumerable<SESMTEmpresaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<SESMTEmpresa>, IEnumerable<SESMTEmpresaViewModel>>(_sesmtEmpresaService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _sesmtEmpresaService.ObterTotalRegistros(pesquisa);
        }
    }
}
