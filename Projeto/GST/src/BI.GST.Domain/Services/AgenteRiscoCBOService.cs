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
    public class AgenteRiscoCBOService : IAgenteRiscoCBOService
    {
        private readonly IAgenteRiscoCBORepository _agenteRiscoCBORepository;

        public AgenteRiscoCBOService(IAgenteRiscoCBORepository agenteRiscoCBORepository)
        {
            _agenteRiscoCBORepository = agenteRiscoCBORepository;
        }

        public void Adicionar(AgenteRiscoCBO agenteRiscoCBO)
        {
            _agenteRiscoCBORepository.Adicionar(agenteRiscoCBO);
        }

        public void Atualizar(AgenteRiscoCBO agenteRiscoCBO)
        {
            _agenteRiscoCBORepository.Atualizar(agenteRiscoCBO);
        }

        public void Dispose()
        {
            _agenteRiscoCBORepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _agenteRiscoCBORepository.Excluir(id);
        }

        public IEnumerable<AgenteRiscoCBO> Find(Expression<Func<AgenteRiscoCBO, bool>> predicate)
        {
            return _agenteRiscoCBORepository.Find(predicate);
        }

        public IEnumerable<AgenteRiscoCBO> ObterGrid(int page, string pesquisa)
        {
            return _agenteRiscoCBORepository.ObterGrid(page, pesquisa);
        }

        public AgenteRiscoCBO ObterPorId(int id)
        {
            return _agenteRiscoCBORepository.ObterPorId(id);
        }

        public IEnumerable<AgenteRiscoCBO> ObterTodos()
        {
            return _agenteRiscoCBORepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteRiscoCBORepository.ObterTotalRegistros(pesquisa);
        }
    }
}
