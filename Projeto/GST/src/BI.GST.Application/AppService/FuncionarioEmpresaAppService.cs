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
    public class FuncionarioEmpresaAppService : BaseAppService, IFuncionarioEmpresaAppService
    {
        private readonly IFuncionarioEmpresaService _funcionarioEmpresaService;

        public FuncionarioEmpresaAppService(IFuncionarioEmpresaService funcionarioEmpresaService)
        {
            _funcionarioEmpresaService = funcionarioEmpresaService;
        }

        public bool Adicionar(FuncionarioEmpresaViewModel funcionarioEmpresaViewModel)
        {
            var funcionarioEmpresa = Mapper.Map<FuncionarioEmpresaViewModel, FuncionarioEmpresa>(funcionarioEmpresaViewModel);

            var duplicado = _funcionarioEmpresaService.Find(e => (e.Funcionario.FuncionarioId == funcionarioEmpresa.Funcionario.FuncionarioId)
                                                            && (e.Empresa.EmpresaId == funcionarioEmpresa.Empresa.EmpresaId)
                                                            && (e.Demissao == null)).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _funcionarioEmpresaService.Adicionar(funcionarioEmpresa);
                Commit();
                return true;
            }
        }

        public bool Atualizar(FuncionarioEmpresaViewModel funcionarioEmpresaViewModel)
        {
            var funcionarioEmpresa = Mapper.Map<FuncionarioEmpresaViewModel, FuncionarioEmpresa>(funcionarioEmpresaViewModel);


            //Powered by Tiago®
            var duplicado = _funcionarioEmpresaService.Find(e => (e.Funcionario.FuncionarioId == funcionarioEmpresa.Funcionario.FuncionarioId)
                                                            && (e.Empresa.EmpresaId == funcionarioEmpresa.Empresa.EmpresaId)
                                                            && (e.Demissao == null) && (e.FuncionarioEmpresaId != funcionarioEmpresa.FuncionarioEmpresaId)).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _funcionarioEmpresaService.Atualizar(funcionarioEmpresa);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _funcionarioEmpresaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _funcionarioEmpresaService.Find(e => e.FuncionarioEmpresaId == id).Any();
            //EXCLUIR Cursos/Vacinas/Exames Vinculados ao Funcionario

            if (existente)
            {
                BeginTransaction();
                var funcionarioEmpresa = _funcionarioEmpresaService.ObterPorId(id);
                funcionarioEmpresa.Delete = true;
                _funcionarioEmpresaService.Atualizar(funcionarioEmpresa);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<FuncionarioEmpresaViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<FuncionarioEmpresa>, IEnumerable<FuncionarioEmpresaViewModel>>(_funcionarioEmpresaService.ObterGrid(page, pesquisa));
        }

        public FuncionarioEmpresaViewModel ObterPorId(int id)
        {
            return Mapper.Map<FuncionarioEmpresa, FuncionarioEmpresaViewModel>(_funcionarioEmpresaService.ObterPorId(id));
        }

        public IEnumerable<FuncionarioEmpresaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<FuncionarioEmpresa>, IEnumerable<FuncionarioEmpresaViewModel>>(_funcionarioEmpresaService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _funcionarioEmpresaService.ObterTotalRegistros(pesquisa);
        }
    }
}
