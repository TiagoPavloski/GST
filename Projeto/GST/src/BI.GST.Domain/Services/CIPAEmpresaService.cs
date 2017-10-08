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
    public class CIPAEmpresaService : ICIPAEmpresaService
    {
        private readonly ICIPAEmpresaRepository _CIPAEmpresaRepository;

        public CIPAEmpresaService(ICIPAEmpresaRepository CIPAEmpresaRepository)
        {
            _CIPAEmpresaRepository = CIPAEmpresaRepository;
        }

        public void Adicionar(CIPAEmpresa cIPAEmpresa)
        {
            _CIPAEmpresaRepository.Adicionar(cIPAEmpresa);
        }

        public void Atualizar(CIPAEmpresa cIPAEmpresa)
        {
            _CIPAEmpresaRepository.Atualizar(cIPAEmpresa);
        }

        public void Dispose()
        {
            _CIPAEmpresaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _CIPAEmpresaRepository.Excluir(id);
        }

        public IEnumerable<CIPAEmpresa> Find(Expression<Func<CIPAEmpresa, bool>> predicate)
        {
            return _CIPAEmpresaRepository.Find(predicate);
        }

        public IEnumerable<CIPAEmpresa> ObterGrid(int page, string pesquisa)
        {
            return _CIPAEmpresaRepository.ObterGrid(page, pesquisa);
        }

        public CIPAEmpresa ObterPorId(int id)
        {
            return _CIPAEmpresaRepository.ObterPorId(id);
        }

        public IEnumerable<CIPAEmpresa> ObterTodos()
        {
            return _CIPAEmpresaRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _CIPAEmpresaRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
