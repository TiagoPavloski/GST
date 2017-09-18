using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using BI.GST.Domain.Entities;
using AutoMapper;

namespace BI.GST.Application.AppService
{
    public class SetorAppService : BaseAppService, ISetorAppService
    {
        private readonly ISetorService _setorService;

        public SetorAppService(ISetorService setorService)
        {
            _setorService = setorService;
        }

        public bool Adicionar(SetorViewModel setorViewModel)
        {
            var setor = Mapper.Map<SetorViewModel, Setor>(setorViewModel);
            var duplicado = _setorService.Find(e => e.Nome == setor.Nome).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _setorService.Adicionar(setor);
                Commit();
                return true;
            }
        }

        public bool Atualizar(SetorViewModel setorViewModel)
        {
            var setor = Mapper.Map<SetorViewModel, Setor>(setorViewModel);

            var duplicado = _setorService.Find(e => e.Nome == setor.Nome && e.SetorId != setor.SetorId).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _setorService.Atualizar(setor);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _setorService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _setorService.Find(e => e.SetorId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var setor = _setorService.ObterPorId(id);
                setor.Delete = true;
                _setorService.Atualizar(setor);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<SetorViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<Setor>, IEnumerable<SetorViewModel>>(_setorService.ObterGrid(page, pesquisa));
        }

        public SetorViewModel ObterPorId(int id)
        {
            return Mapper.Map<Setor, SetorViewModel>(_setorService.ObterPorId(id));
        }

        public IEnumerable<SetorViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Setor>, IEnumerable<SetorViewModel>>(_setorService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _setorService.ObterTotalRegistros(pesquisa);
        }
    }
}
