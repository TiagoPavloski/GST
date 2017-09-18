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
    public class SetorService : ISetorService
    {
        private readonly ISetorRepository _setorRepository;

        public SetorService(ISetorRepository setorRepository)
        {
            _setorRepository = setorRepository;
        }

        public void Adicionar(Setor setor)
        {
            _setorRepository.Adicionar(setor);
        }

        public void Atualizar(Setor setor)
        {
            _setorRepository.Atualizar(setor);
        }

        public void Dispose()
        {
            _setorRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _setorRepository.Excluir(id);
        }

        public IEnumerable<Setor> Find(Expression<Func<Setor, bool>> predicate)
        {
            return _setorRepository.Find(predicate);
        }

        public IEnumerable<Setor> ObterGrid(int page, string pesquisa)
        {
            return _setorRepository.ObterGrid(page, pesquisa);
        }

        public Setor ObterPorId(int id)
        {
            return _setorRepository.ObterPorId(id);
        }

        public IEnumerable<Setor> ObterTodos()
        {
            return _setorRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _setorRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
