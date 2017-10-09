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
    public class SESMTEmpresaService : ISESMTEmpresaService
    {
        private readonly ISESMTEmpresaRepository _SESMTEmpresaRepository;

        public SESMTEmpresaService(ISESMTEmpresaRepository SESMTEmpresaRepository)
        {
            _SESMTEmpresaRepository = SESMTEmpresaRepository;
        }

        public void Adicionar(SESMTEmpresa sESMTEmpresa)
        {
            _SESMTEmpresaRepository.Adicionar(sESMTEmpresa);
        }

        public void Atualizar(SESMTEmpresa sESMTEmpresa)
        {
            _SESMTEmpresaRepository.Atualizar(sESMTEmpresa);
        }

        public void Dispose()
        {
            _SESMTEmpresaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _SESMTEmpresaRepository.Excluir(id);
        }

        public IEnumerable<SESMTEmpresa> Find(Expression<Func<SESMTEmpresa, bool>> predicate)
        {
            return _SESMTEmpresaRepository.Find(predicate);
        }

        public IEnumerable<SESMTEmpresa> ObterGrid(int page, string pesquisa)
        {
            return _SESMTEmpresaRepository.ObterGrid(page, pesquisa);
        }

        public SESMTEmpresa ObterPorId(int id)
        {
            return _SESMTEmpresaRepository.ObterPorId(id);
        }

        public IEnumerable<SESMTEmpresa> ObterTodos()
        {
            return _SESMTEmpresaRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _SESMTEmpresaRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
