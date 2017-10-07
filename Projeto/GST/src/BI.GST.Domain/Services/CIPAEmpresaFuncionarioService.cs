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
    public class CIPAEmpresaFuncionarioService : ICIPAEmpresaFuncionarioService
    {
        private readonly ICIPAEmpresaFuncionarioRepository _CIPAEmpresaFuncionarioRepository;

        public CIPAEmpresaFuncionarioService(ICIPAEmpresaFuncionarioRepository cIPAEmpresaFuncionarioRepository)
        {
            _CIPAEmpresaFuncionarioRepository = cIPAEmpresaFuncionarioRepository;
        }

        public void Adicionar(CIPAEmpresaFuncionario cIPAEmpresaFuncionario)
        {
            _CIPAEmpresaFuncionarioRepository.Adicionar(cIPAEmpresaFuncionario);
        }

        public void Atualizar(CIPAEmpresaFuncionario cIPAEmpresaFuncionario)
        {
            _CIPAEmpresaFuncionarioRepository.Atualizar(cIPAEmpresaFuncionario);
        }

        public void Dispose()
        {
            _CIPAEmpresaFuncionarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _CIPAEmpresaFuncionarioRepository.Excluir(id);
        }

        public IEnumerable<CIPAEmpresaFuncionario> Find(Expression<Func<CIPAEmpresaFuncionario, bool>> predicate)
        {
            return _CIPAEmpresaFuncionarioRepository.Find(predicate);
        }

        public IEnumerable<CIPAEmpresaFuncionario> ObterGrid(int page, string pesquisa, int CIPAEmpresaId)
        {
            return _CIPAEmpresaFuncionarioRepository.ObterGrid(page, pesquisa, CIPAEmpresaId);
        }

        public CIPAEmpresaFuncionario ObterPorId(int id)
        {
            return _CIPAEmpresaFuncionarioRepository.ObterPorId(id);
        }

        public IEnumerable<CIPAEmpresaFuncionario> ObterTodos()
        {
            return _CIPAEmpresaFuncionarioRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa, int CIPAEmpresaId)
        {
            return _CIPAEmpresaFuncionarioRepository.ObterTotalRegistros(pesquisa, CIPAEmpresaId);
        }
    }
}
