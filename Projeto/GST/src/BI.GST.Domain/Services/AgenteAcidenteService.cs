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
    public class AgenteAcidenteService : IAgenteAcidenteService
    {
        private readonly IAgenteAcidenteRepository _agenteAcidenteRepository;

        public AgenteAcidenteService(IAgenteAcidenteRepository agenteAcidenteRepository)
        {
            _agenteAcidenteRepository = agenteAcidenteRepository;
        }

        public void Adicionar(AgenteAcidente agenteAcidente)
        {
            _agenteAcidenteRepository.Adicionar(agenteAcidente);
        }

        public void Atualizar(AgenteAcidente agenteAcidente)
        {
            _agenteAcidenteRepository.Atualizar(agenteAcidente);
        }

        public void Dispose()
        {
            _agenteAcidenteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _agenteAcidenteRepository.Excluir(id);
        }

        public IEnumerable<AgenteAcidente> Find(Expression<Func<AgenteAcidente, bool>> predicate)
        {
            return _agenteAcidenteRepository.Find(predicate);
        }

        public IEnumerable<AgenteAcidente> ObterGrid(int page, string pesquisa)
        {
            return _agenteAcidenteRepository.ObterGrid(page, pesquisa);
        }

        public AgenteAcidente ObterPorId(int id)
        {
            return _agenteAcidenteRepository.ObterPorId(id);
        }

        public IEnumerable<AgenteAcidente> ObterTodos()
        {
            return _agenteAcidenteRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _agenteAcidenteRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
