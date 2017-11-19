using AutoMapper;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BI.GST.Application.AppService
{
    public class FuncionarioAppService : BaseAppService, IFuncionarioAppService
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioAppService(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }
        public bool Adicionar(FuncionarioViewModel funcionarioViewModel)
        {
            var funcionario = Mapper.Map<FuncionarioViewModel, Funcionario>(funcionarioViewModel);

            var duplicado = _funcionarioService.Find(e => e.CPF == funcionario.CPF && e.FuncionarioId != funcionario.FuncionarioId && e.Delete == false).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _funcionarioService.Adicionar(funcionario);
                Commit();
                return true;
            }
        }


        public bool Atualizar(FuncionarioViewModel funcionarioViewModel)
        {
            var funcionario = Mapper.Map<FuncionarioViewModel, Funcionario>(funcionarioViewModel);

            var duplicado = _funcionarioService.Find(e => e.CPF == funcionario.CPF && e.FuncionarioId != funcionario.FuncionarioId && e.Delete == false).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _funcionarioService.Atualizar(funcionario);
                Commit();
                return true;
            }

        }

        public void Dispose()
        {
            _funcionarioService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _funcionarioService.Find(e => e.FuncionarioId == id).Any();

            if (existente)
            {
                BeginTransaction();
                var funcionario = _funcionarioService.ObterPorId(id);
                funcionario.Delete = true;
                _funcionarioService.Atualizar(funcionario);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<FuncionarioViewModel> ObterGrid(string pesquisa, int page, int usuarioId)
        {
            return Mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(_funcionarioService.ObterGrid(pesquisa, page, usuarioId));
        }

        public FuncionarioViewModel ObterPorId(int id)
        {
            return Mapper.Map<Funcionario, FuncionarioViewModel>(_funcionarioService.ObterPorId(id));
        }

        public IEnumerable<FuncionarioViewModel> ObterPorEmpresa(int empresaId)
        {
            return Mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>> (_funcionarioService.ObterPorEmpresa(empresaId));
        }

        public IEnumerable<FuncionarioViewModel> ObterFuncionariosEC(int empresaId, int cursoId)
        {
            return Mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(_funcionarioService.ObterFuncionariosEC(empresaId, cursoId));
        }

        public IEnumerable<FuncionarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(_funcionarioService.ObterTodos());
        }

        public IEnumerable<FuncionarioViewModel> ObterTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(_funcionarioService.ObterTodosAtivos());
        }

        public int ObterTotalRegistros(string pesquisa, int usuarioId)
        {
            return _funcionarioService.ObterTotalRegistros(pesquisa, usuarioId);
        }

        public int ObterTotalPorEmpresa(int empresaId)
        {
            return _funcionarioService.ObterTotalPorEmpresa(empresaId);
            
        }
    }
}
