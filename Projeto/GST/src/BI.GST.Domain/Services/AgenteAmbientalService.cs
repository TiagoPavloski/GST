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
    public class AgenteAmbientalService : IAgenteAmbientalService
    {
        private readonly IAgenteAmbientalRepository _agenteAmbientalRepository;
         
        public AgenteAmbientalService(IAgenteAmbientalRepository agenteAmbientalRepository)
        {
            _agenteAmbientalRepository = agenteAmbientalRepository;
        }

        public void Adicionar(AgenteAmbiental agenteAmbiental)
        {
            _agenteAmbientalRepository.Adicionar(agenteAmbiental);
        }

        public void Atualizar(AgenteAmbiental agenteAmbiental)
        {
            _agenteAmbientalRepository.Atualizar(agenteAmbiental);
        }

        public void Dispose()
        {
            _agenteAmbientalRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _agenteAmbientalRepository.Excluir(id);
        }

        public IEnumerable<AgenteAmbiental> Find(Expression<Func<AgenteAmbiental, bool>> predicate)
        {
            return _agenteAmbientalRepository.Find(predicate);
        }

        public IEnumerable<AgenteAmbiental> ObterGrid(int page, string pesquisa)
        {
            return _agenteAmbientalRepository.ObterGrid(page, pesquisa);
        }

        public AgenteAmbiental ObterPorId(int id)
        {
            return _agenteAmbientalRepository.ObterPorId(id);
        }

        public IEnumerable<AgenteAmbiental> ObterTodos()
        {
            return _agenteAmbientalRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteAmbientalRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
