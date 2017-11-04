using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using BI.GST.Domain.Entities;
using AutoMapper;

namespace BI.GST.Application.AppService
{
    public class EscalaAppService : BaseAppService, IEscalaAppService
    {
        private readonly IEscalaService _escalaService;
        private readonly IFuncionarioService _funcionarioService;

        public EscalaAppService(IEscalaService escalaService, IFuncionarioService funcionarioService)
        {
            _escalaService = escalaService;
            _funcionarioService = funcionarioService;
        }

        public string Adicionar(EscalaViewModel escalaViewModel)
        {
            var escala = Mapper.Map<EscalaViewModel, Escala>(escalaViewModel);

            var duplicado = _escalaService.Find(e => (e.Nome == escala.Nome) && (e.Delete == false)).Any();
            if (duplicado)
            {
                return "Já existe uma escala com este nome.";
            }
            else
            {
                BeginTransaction();
                _escalaService.Adicionar(escala);
                Commit();
                return "";
            }
        }

        public string Atualizar(EscalaViewModel escalaViewModel)
        {
            var escala = Mapper.Map<EscalaViewModel, Escala>(escalaViewModel);

            var duplicado = _escalaService.Find(e => (e.Nome == escala.Nome) &&
              (e.EscalaId != escala.EscalaId) && (e.Delete == false)).Any();

            if (duplicado)
            {
                return "Já existe uma escala com este nome.";
            }
            else
            {
                BeginTransaction();
                _escalaService.Atualizar(escala);
                Commit();
                return "";
            }

        }

        public void Dispose()
        {
            _escalaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public string Excluir(int id)
        {
            bool existente = _escalaService.Find(e => e.EscalaId == id).Any();
            bool funcionarioUtiliza = _funcionarioService.Find(c => (c.EscalaId == id) && (c.Delete == false)).Any();

            if (funcionarioUtiliza)
            {
                return "Operação negada! Existem funcionários ativos usando esta escala.";
            }
            if (existente)
            {
                BeginTransaction();
                var escala = _escalaService.ObterPorId(id);
                escala.Delete = true;
                _escalaService.Atualizar(escala);
                Commit();
                return "";
            }
            else
            {
                return "Erro ao excluir, atualize a página.";
            }
            
        }

        public IEnumerable<EscalaViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<Escala>, IEnumerable<EscalaViewModel>>(_escalaService.ObterGrid(page, pesquisa));
        }

        public EscalaViewModel ObterPorId(int id)
        {
            return Mapper.Map<Escala, EscalaViewModel>(_escalaService.ObterPorId(id));
        }

        public IEnumerable<EscalaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Escala>, IEnumerable<EscalaViewModel>>(_escalaService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _escalaService.ObterTotalRegistros(pesquisa);
        }
    }
}
