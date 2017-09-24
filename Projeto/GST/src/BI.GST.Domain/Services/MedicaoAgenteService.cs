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
    public class MedicaoAgenteService : IMedicaoAgenteService
    {
        private readonly IMedicaoAgenteRepository _medicaoAgenteRepository;

        public MedicaoAgenteService(IMedicaoAgenteRepository medicaoAgenteRepository)
        {
            _medicaoAgenteRepository = medicaoAgenteRepository;
        }

        public void Adicionar(MedicaoAgente medicaoAgente)
        {
            _medicaoAgenteRepository.Adicionar(medicaoAgente);
        }

        public void Atualizar(MedicaoAgente medicaoAgente)
        {
            _medicaoAgenteRepository.Atualizar(medicaoAgente);
        }

        public void Dispose()
        {
            _medicaoAgenteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _medicaoAgenteRepository.Excluir(id);
        }

        public IEnumerable<MedicaoAgente> Find(Expression<Func<MedicaoAgente, bool>> predicate)
        {
            return _medicaoAgenteRepository.Find(predicate);
        }

        public IEnumerable<MedicaoAgente> ObterGrid(int page, string pesquisa)
        {
            return _medicaoAgenteRepository.ObterGrid(page, pesquisa);
        }

        public MedicaoAgente ObterPorId(int id)
        {
            return _medicaoAgenteRepository.ObterPorId(id);
        }

        public IEnumerable<MedicaoAgente> ObterTodos()
        {
            return _medicaoAgenteRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _medicaoAgenteRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
