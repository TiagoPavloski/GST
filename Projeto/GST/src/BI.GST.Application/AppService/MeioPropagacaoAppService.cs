using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using AutoMapper;
using BI.GST.Domain.Entities;

namespace BI.GST.Application.AppService
{
    public class MeioPropagacaoAppService : BaseAppService, IMeioPropagacaoAppService
    {
        private readonly IMeioPropagacaoService _meioPropagacaoService;

        public MeioPropagacaoAppService(IMeioPropagacaoService meioPropagacaoService)
        {
            _meioPropagacaoService = meioPropagacaoService;
        }

        public bool Adicionar(MeioPropagacaoViewModel meioPropagacaoViewModel)
        {
            var meioPropagacao = Mapper.Map<MeioPropagacaoViewModel, MeioPropagacao>(meioPropagacaoViewModel);
            var duplicado = _meioPropagacaoService.Find(e => e.Meio == meioPropagacao.Meio).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _meioPropagacaoService.Adicionar(meioPropagacao);
                Commit();
                return true;
            }
        }

        public bool Atualizar(MeioPropagacaoViewModel meioPropagacaoViewModel)
        {
            var meioPropagacao = Mapper.Map<MeioPropagacaoViewModel, MeioPropagacao>(meioPropagacaoViewModel);

            var duplicado = _meioPropagacaoService.Find(e => e.Meio == meioPropagacao.Meio && e.MeioPropagacaoId != meioPropagacao.MeioPropagacaoId).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _meioPropagacaoService.Atualizar(meioPropagacao);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _meioPropagacaoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _meioPropagacaoService.Find(e => e.MeioPropagacaoId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var meioPropagacao = _meioPropagacaoService.ObterPorId(id);
                meioPropagacao.Delete = true;
                _meioPropagacaoService.Atualizar(meioPropagacao);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<MeioPropagacaoViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<MeioPropagacao>, IEnumerable<MeioPropagacaoViewModel>>(_meioPropagacaoService.ObterGrid(page, pesquisa));
        }

        public MeioPropagacaoViewModel ObterPorId(int id)
        {
            return Mapper.Map<MeioPropagacao, MeioPropagacaoViewModel>(_meioPropagacaoService.ObterPorId(id));
        }

        public IEnumerable<MeioPropagacaoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<MeioPropagacao>, IEnumerable<MeioPropagacaoViewModel>>(_meioPropagacaoService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _meioPropagacaoService.ObterTotalRegistros(pesquisa);
        }
    }
}
