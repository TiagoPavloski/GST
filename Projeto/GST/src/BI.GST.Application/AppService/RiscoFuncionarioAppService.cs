using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IService;
using AutoMapper;

namespace BI.GST.Application.AppService
{
    public class RiscoFuncionarioAppService : BaseAppService, IRiscoFuncionarioAppService
    {
        private readonly IRiscoFuncionarioService _riscoFuncionarioService;

        public RiscoFuncionarioAppService(IRiscoFuncionarioService riscoFuncionarioService)
        {
            _riscoFuncionarioService = riscoFuncionarioService;
        }

        public bool Adicionar(RiscoFuncionarioViewModel riscoFuncionarioViewModel)
        {
            var riscoFuncionario = Mapper.Map<RiscoFuncionarioViewModel, RiscoFuncionario>(riscoFuncionarioViewModel);

            var duplicado = _riscoFuncionarioService.Find(x => (x.Nome == riscoFuncionario.Nome)
                && (x.Delete == false)).Any();
            if (duplicado)
                return false;
            else
            {
                BeginTransaction();
                _riscoFuncionarioService.Adicionar(riscoFuncionario);
                Commit();
                return true;
            }
        }

        public bool Atualizar(RiscoFuncionarioViewModel riscoFuncionarioViewModel)
        {
            var riscoFuncionario = Mapper.Map<RiscoFuncionarioViewModel, RiscoFuncionario>(riscoFuncionarioViewModel);

            var duplicado = _riscoFuncionarioService.Find(x => (x.Nome == riscoFuncionario.Nome)
                            && (x.Delete == false)
                            && (x.RiscoFuncionarioId != riscoFuncionario.RiscoFuncionarioId)).Any();
            if (duplicado)
                return false;
            else
            {
                BeginTransaction();
                _riscoFuncionarioService.Atualizar(riscoFuncionario);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _riscoFuncionarioService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _riscoFuncionarioService.Find(e => e.RiscoFuncionarioId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var riscoFuncionario = _riscoFuncionarioService.ObterPorId(id);
                riscoFuncionario.Delete = true;
                _riscoFuncionarioService.Atualizar(riscoFuncionario);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<RiscoFuncionarioViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<RiscoFuncionario>, IEnumerable<RiscoFuncionarioViewModel>>(_riscoFuncionarioService.ObterGrid(page, pesquisa));

        }

        public RiscoFuncionarioViewModel ObterPorId(int id)
        {
            return Mapper.Map<RiscoFuncionario, RiscoFuncionarioViewModel>(_riscoFuncionarioService.ObterPorId(id));

        }

        public IEnumerable<RiscoFuncionarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<RiscoFuncionario>, IEnumerable<RiscoFuncionarioViewModel>>(_riscoFuncionarioService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _riscoFuncionarioService.ObterTotalRegistros(pesquisa);
        }
    }
}
