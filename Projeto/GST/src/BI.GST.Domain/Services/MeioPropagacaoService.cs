using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;
using System.Linq.Expressions;
using BI.GST.Domain.Interface.IRepository;

namespace BI.GST.Domain.Services
{
    public class MeioPropagacaoService : IMeioPropagacaoService
    {
        private readonly IMeioPropagacaoRepository _meioPropagacaoRepository;

        public MeioPropagacaoService(IMeioPropagacaoRepository meioPropagacaoRepository)
        {
            _meioPropagacaoRepository = meioPropagacaoRepository;
        }

        public void Adicionar(MeioPropagacao meioPropagacao)
        {
            _meioPropagacaoRepository.Adicionar(meioPropagacao);
        }

        public void Atualizar(MeioPropagacao meioPropagacao)
        {
            _meioPropagacaoRepository.Atualizar(meioPropagacao);
        }

        public void Dispose()
        {
            _meioPropagacaoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _meioPropagacaoRepository.Excluir(id);
        }

        public IEnumerable<MeioPropagacao> Find(Expression<Func<MeioPropagacao, bool>> predicate)
        {
            return _meioPropagacaoRepository.Find(predicate);
        }

        public IEnumerable<MeioPropagacao> ObterGrid(int page, string pesquisa)
        {
            return _meioPropagacaoRepository.ObterGrid(page, pesquisa);
        }

        public MeioPropagacao ObterPorId(int id)
        {
            return _meioPropagacaoRepository.ObterPorId(id);
        }

        public IEnumerable<MeioPropagacao> ObterTodos()
        {
            return _meioPropagacaoRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _meioPropagacaoRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
