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
    public class PPRAService : IPPRAService
    {
        private readonly IPPRARepository _PPRARepository;

        public PPRAService(IPPRARepository PPRARepository)
        {
            _PPRARepository = PPRARepository;
        }

        public void Adicionar(PPRA ppra)
        {
            _PPRARepository.Adicionar(ppra);
        }

        public void Atualizar(PPRA ppra)
        {
            _PPRARepository.Atualizar(ppra);
        }

        public void Dispose()
        {
            _PPRARepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _PPRARepository.Excluir(id);
        }

        public IEnumerable<PPRA> Find(Expression<Func<PPRA, bool>> predicate)
        {
            return _PPRARepository.Find(predicate);
        }

        public IEnumerable<PPRA> ObterGrid(int page, string pesquisa)
        {
            return _PPRARepository.ObterGrid(page, pesquisa);
        }

        public PPRA ObterPorId(int id)
        {
            return _PPRARepository.ObterPorId(id);
        }

        public IEnumerable<PPRA> ObterTodos()
        {
            return _PPRARepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _PPRARepository.ObterTotalRegistros(pesquisa);
        }
    }
}
