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
    public class TipoSetorAppService : BaseAppService, ITipoSetorAppService
    {
        private readonly ITipoSetorService _tipoSetorService;
        private readonly ISetorService _SetorService;

        public TipoSetorAppService(ITipoSetorService tipoSetorService, ISetorService SetorService)
        {
            _tipoSetorService = tipoSetorService;
            _SetorService = SetorService;
        }

        public bool Adicionar(TipoSetorViewModel tipoSetorViewModel)
        {
            var tipoSetor = Mapper.Map<TipoSetorViewModel, TipoSetor>(tipoSetorViewModel);

            var duplicado = _tipoSetorService.Find(e => (e.Nome == tipoSetor.Nome) && (e.Delete == false)).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _tipoSetorService.Adicionar(tipoSetor);
                Commit();
                return true;
            }
        }

        public bool Atualizar(TipoSetorViewModel tipoSetorViewModel)
        {
            var tipoSetor = Mapper.Map<TipoSetorViewModel, TipoSetor>(tipoSetorViewModel);

            var duplicado = _tipoSetorService.Find(e => (e.Nome == tipoSetor.Nome) && (e.TipoSetorId != tipoSetor.TipoSetorId) && (e.Delete == false)).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _tipoSetorService.Atualizar(tipoSetor);
                Commit();
                return true;
            }

        }

        public void Dispose()
        {
            _tipoSetorService.Dispose();
            GC.SuppressFinalize(this);
        }

        public string Excluir(int id)
        {
            bool existente = _tipoSetorService.Find(e => (e.TipoSetorId) == id && (e.Delete == false)).Any();
            bool SetorUtiliza = _SetorService.Find(c => c.TipoSetorId == id && c.Delete == false).Any();

            if (existente && !SetorUtiliza)
            {
                BeginTransaction();
                var tipoSetor = _tipoSetorService.ObterPorId(id);
                tipoSetor.Delete = true;
                _tipoSetorService.Atualizar(tipoSetor);
                Commit();
                return "";
            }
            return "Exclusão negada! Existem setores que usam este tipo";
        }

        public IEnumerable<TipoSetorViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<TipoSetor>, IEnumerable<TipoSetorViewModel>>(_tipoSetorService.ObterGrid(page, pesquisa));
        }

        public TipoSetorViewModel ObterPorId(int id)
        {
            return Mapper.Map<TipoSetor, TipoSetorViewModel>(_tipoSetorService.ObterPorId(id));
        }

        public IEnumerable<TipoSetorViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<TipoSetor>, IEnumerable<TipoSetorViewModel>>(_tipoSetorService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _tipoSetorService.ObterTotalRegistros(pesquisa);
        }
    }
}
