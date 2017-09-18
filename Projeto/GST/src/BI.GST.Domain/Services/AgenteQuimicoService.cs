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
    public class AgenteQuimicoService : IAgenteQuimicoService
    {
        private readonly IAgenteQuimicoRepository _agenteQuimicoRepository;

        public AgenteQuimicoService(IAgenteQuimicoRepository agenteQuimicoRepository)
        {
            _agenteQuimicoRepository = agenteQuimicoRepository;
        }

        public void Adicionar(AgenteQuimico agenteQuimico)
        {
            _agenteQuimicoRepository.Adicionar(agenteQuimico);
        }

        public void Atualizar(AgenteQuimico agenteQuimico)
        {
            _agenteQuimicoRepository.Atualizar(agenteQuimico);
        }

        public void Dispose()
        {
            _agenteQuimicoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _agenteQuimicoRepository.Excluir(id);
        }

        public IEnumerable<AgenteQuimico> Find(Expression<Func<AgenteQuimico, bool>> predicate)
        {
            return _agenteQuimicoRepository.Find(predicate);
        }

        public IEnumerable<AgenteQuimico> ObterGrid(int page, string pesquisa)
        {
            return _agenteQuimicoRepository.ObterGrid(page, pesquisa);
        }

        public AgenteQuimico ObterPorId(int id)
        {
            return _agenteQuimicoRepository.ObterPorId(id);
        }

        public IEnumerable<AgenteQuimico> ObterTodos()
        {
            return _agenteQuimicoRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteQuimicoRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
