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
    public class FonteRiscoCBOService : IFonteRiscoCBOService
    {
        private readonly IFonteRiscoCBORepository _fonteRiscoCBORepository;

        public FonteRiscoCBOService(IFonteRiscoCBORepository fonteRiscoCBORepository)
        {
            _fonteRiscoCBORepository = fonteRiscoCBORepository;
        }

        public void Adicionar(FonteRiscoCBO fonteRiscoCBO)
        {
            _fonteRiscoCBORepository.Adicionar(fonteRiscoCBO);
        }

        public void Atualizar(FonteRiscoCBO fonteRiscoCBO)
        {
            _fonteRiscoCBORepository.Atualizar(fonteRiscoCBO);
        }

        public void Dispose()
        {
            _fonteRiscoCBORepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _fonteRiscoCBORepository.Excluir(id);
        }

        public IEnumerable<FonteRiscoCBO> Find(Expression<Func<FonteRiscoCBO, bool>> predicate)
        {
            return _fonteRiscoCBORepository.Find(predicate);
        }

        public IEnumerable<FonteRiscoCBO> ObterGrid(int page, string pesquisa)
        {
            return _fonteRiscoCBORepository.ObterGrid(page, pesquisa);
        }

        public FonteRiscoCBO ObterPorId(int id)
        {
            return _fonteRiscoCBORepository.ObterPorId(id);
        }

        public IEnumerable<FonteRiscoCBO> ObterTodos()
        {
            return _fonteRiscoCBORepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _fonteRiscoCBORepository.ObterTotalRegistros(pesquisa);
        }
    }
}
