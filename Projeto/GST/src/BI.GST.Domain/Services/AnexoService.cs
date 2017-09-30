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
    public class AnexoService : IAnexoService
    {
        private readonly IAnexoRepository _anexoRepository;

        public AnexoService(IAnexoRepository anexoRepository)
        {
            _anexoRepository = anexoRepository;
        }

        public void Adicionar(Anexo anexo)
        {
            _anexoRepository.Adicionar(anexo);
        }

        public void Atualizar(Anexo anexo)
        {
            _anexoRepository.Atualizar(anexo);
        }

        public void Dispose()
        {
            _anexoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _anexoRepository.Excluir(id);
        }

        public IEnumerable<Anexo> Find(Expression<Func<Anexo, bool>> predicate)
        {
            return _anexoRepository.Find(predicate);
        }

        public IEnumerable<Anexo> ObterGrid(int page, string pesquisa, int idPPRA)
        {
            return _anexoRepository.ObterGrid(page, pesquisa, idPPRA);
        }

        public Anexo ObterPorId(int id)
        {
            return _anexoRepository.ObterPorId(id);
        }

        public IEnumerable<Anexo> ObterTodos(int idPPRA)
        {
            return _anexoRepository.ObterTodos(idPPRA);
        }

        public int ObterTotalRegistros(string pesquisa, int idPPRA)
        {
            return _anexoRepository.ObterTotalRegistros(pesquisa, idPPRA);
        }
    }
}
