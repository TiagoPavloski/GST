using AutoMapper;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.AppService
{
    public class EmpresaUtilizadoraAppService : BaseAppService, IEmpresaUtilizadoraAppService
    {
        private readonly IEmpresaUtilizadoraService _empresaUtilizadoraService;

        public EmpresaUtilizadoraAppService(IEmpresaUtilizadoraService empresaUtilizadoraService)
        {
            _empresaUtilizadoraService = empresaUtilizadoraService;
        }
        public bool Adicionar(EmpresaUtilizadoraViewModel empresaUtilizadoraViewModel)
        {
            var empresaUtilizadora = Mapper.Map<EmpresaUtilizadoraViewModel, EmpresaUtilizadora>(empresaUtilizadoraViewModel);

            var duplicado = _empresaUtilizadoraService.Find(e => e.NomeFantasia == empresaUtilizadora.NomeFantasia).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _empresaUtilizadoraService.Adicionar(empresaUtilizadora);
                Commit();
                return true;
            }
        }

        public bool Atualizar(EmpresaUtilizadoraViewModel empresaUtilizadoraViewModel)
        {
            var empresaUtilizadora = Mapper.Map<EmpresaUtilizadoraViewModel, EmpresaUtilizadora>(empresaUtilizadoraViewModel);

            var duplicado = _empresaUtilizadoraService.Find(e => e.NomeFantasia == empresaUtilizadora.NomeFantasia && e.EmpresaUtilizadoraId != empresaUtilizadora.EmpresaUtilizadoraId).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _empresaUtilizadoraService.Atualizar(empresaUtilizadora);
                Commit();
                return true;
            }

        }

        public void Dispose()
        {
            _empresaUtilizadoraService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _empresaUtilizadoraService.Find(e => e.EmpresaUtilizadoraId == id).Any();

            if (existente)
            {
                BeginTransaction();
                var empresaUtilizadora = _empresaUtilizadoraService.ObterPorId(id);
                empresaUtilizadora.Delete = true;
                _empresaUtilizadoraService.Atualizar(empresaUtilizadora);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<EmpresaUtilizadoraViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<EmpresaUtilizadora>, IEnumerable<EmpresaUtilizadoraViewModel>>(_empresaUtilizadoraService.ObterGrid(page, pesquisa));
        }

        public EmpresaUtilizadoraViewModel ObterPorId(int id)
        {
            return Mapper.Map<EmpresaUtilizadora, EmpresaUtilizadoraViewModel>(_empresaUtilizadoraService.ObterPorId(id));
        }

        public IEnumerable<EmpresaUtilizadoraViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<EmpresaUtilizadora>, IEnumerable<EmpresaUtilizadoraViewModel>>(_empresaUtilizadoraService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _empresaUtilizadoraService.ObterTotalRegistros(pesquisa);
        }
    }
}
