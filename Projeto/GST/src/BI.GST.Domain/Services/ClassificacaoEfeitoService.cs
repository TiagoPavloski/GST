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
    public class ClassificacaoEfeitoService : IClassificacaoEfeitoService
    {
        private readonly IClassificacaoEfeitoRepositiry _classificacaoEfeitoRepository;

        public ClassificacaoEfeitoService(IClassificacaoEfeitoRepositiry classificacaoEfeitoRepository)
        {
            _classificacaoEfeitoRepository = classificacaoEfeitoRepository;
        }

        public void Adicionar(ClassificacaoEfeito classificacaoEfeito)
        {
            _classificacaoEfeitoRepository.Adicionar(classificacaoEfeito);
        }

        public void Atualizar(ClassificacaoEfeito classificacaoEfeito)
        {
            _classificacaoEfeitoRepository.Atualizar(classificacaoEfeito);
        }

        public void Dispose()
        {
            _classificacaoEfeitoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _classificacaoEfeitoRepository.Excluir(id);
        }

        public IEnumerable<ClassificacaoEfeito> Find(Expression<Func<ClassificacaoEfeito, bool>> predicate)
        {
            return _classificacaoEfeitoRepository.Find(predicate);
        }

        public IEnumerable<ClassificacaoEfeito> ObterGrid(int page, string pesquisa)
        {
            return _classificacaoEfeitoRepository.ObterGrid(page, pesquisa);
        }

        public ClassificacaoEfeito ObterPorId(int id)
        {
            return _classificacaoEfeitoRepository.ObterPorId(id);
        }

        public IEnumerable<ClassificacaoEfeito> ObterTodos()
        {
            return _classificacaoEfeitoRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _classificacaoEfeitoRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
