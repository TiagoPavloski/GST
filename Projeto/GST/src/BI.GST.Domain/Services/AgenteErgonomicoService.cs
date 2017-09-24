using BI.GST.Domain.Interface.IRepository;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Domain.Entities;
using System.Linq.Expressions;

namespace BI.GST.Domain.Services
{
    public class AgenteErgonomicoService : IAgenteErgonomicoService
    {
        private readonly IAgenteErgonomicoRepository _agenteErgonomicoRepository;

        public AgenteErgonomicoService(IAgenteErgonomicoRepository agenteErgonomicoRepository)
        {
            _agenteErgonomicoRepository = agenteErgonomicoRepository;
        }

        public void Adicionar(AgenteErgonomico agenteErgonomico)
        {
            _agenteErgonomicoRepository.Adicionar(agenteErgonomico);
        }

        public void Atualizar(AgenteErgonomico agenteErgonomico)
        {
            _agenteErgonomicoRepository.Atualizar(agenteErgonomico);
        }

        public void Dispose()
        {
            _agenteErgonomicoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _agenteErgonomicoRepository.Excluir(id);
        }

        public IEnumerable<AgenteErgonomico> Find(Expression<Func<AgenteErgonomico, bool>> predicate)
        {
            return _agenteErgonomicoRepository.Find(predicate);
        }

        public IEnumerable<AgenteErgonomico> ObterGrid(int page, string pesquisa)
        {
            return _agenteErgonomicoRepository.ObterGrid(page, pesquisa);
        }

        public AgenteErgonomico ObterPorId(int id)
        {
            return _agenteErgonomicoRepository.ObterPorId(id);
        }

        public IEnumerable<AgenteErgonomico> ObterTodos()
        {
            return _agenteErgonomicoRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteErgonomicoRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
