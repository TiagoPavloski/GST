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
    public class CertificadoService : ICertificadoService
    {
        private readonly ICertificadoRepository _certificadoRepository;

        public CertificadoService(ICertificadoRepository certificadoRepository)
        {
            _certificadoRepository = certificadoRepository;
        }

        public void Adicionar(Certificado certificado, int tipoCurso, string dataRealizacao)
        {
            _certificadoRepository.Adicionar(certificado, tipoCurso, dataRealizacao);
        }

        public void Atualizar(Certificado certificado)
        {
            _certificadoRepository.Atualizar(certificado);
        }

        public void Dispose()
        {
            _certificadoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _certificadoRepository.Excluir(id);
        }

        public IEnumerable<Certificado> Find(Expression<Func<Certificado, bool>> predicate)
        {
            return _certificadoRepository.Find(predicate);
        }

        public IEnumerable<Certificado> ObterGrid(int page, string pesquisa)
        {
            return _certificadoRepository.ObterGrid(page, pesquisa);
        }

        public Certificado ObterPorId(int id)
        {
            return _certificadoRepository.ObterPorId(id);
        }

        public IEnumerable<Certificado> ObterTodos()
        {
            return _certificadoRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _certificadoRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
