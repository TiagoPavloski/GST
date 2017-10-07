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
    public class SESMTEmpresaFuncionarioService : ISESMTEmpresaFuncionarioService
    {
        private readonly ISESMTEmpresaFuncionarioRepository _SESMTEmpresaFuncionarioRepository;

        public SESMTEmpresaFuncionarioService(ISESMTEmpresaFuncionarioRepository sESMTEmpresaFuncionarioRepository)
        {
            _SESMTEmpresaFuncionarioRepository = sESMTEmpresaFuncionarioRepository;
        }

        public void Adicionar(SESMTEmpresaFuncionario sESMTEmpresaFuncionario)
        {
            _SESMTEmpresaFuncionarioRepository.Adicionar(sESMTEmpresaFuncionario);
        }

        public void Atualizar(SESMTEmpresaFuncionario sESMTEmpresaFuncionario)
        {
            _SESMTEmpresaFuncionarioRepository.Atualizar(sESMTEmpresaFuncionario);
        }

        public void Dispose()
        {
            _SESMTEmpresaFuncionarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _SESMTEmpresaFuncionarioRepository.Excluir(id);
        }

        public IEnumerable<SESMTEmpresaFuncionario> Find(Expression<Func<SESMTEmpresaFuncionario, bool>> predicate)
        {
            return _SESMTEmpresaFuncionarioRepository.Find(predicate);
        }

        public IEnumerable<SESMTEmpresaFuncionario> ObterGrid(int page, string pesquisa, int SESMTEmpresaId)
        {
            return _SESMTEmpresaFuncionarioRepository.ObterGrid(page, pesquisa, SESMTEmpresaId);
        }

        public SESMTEmpresaFuncionario ObterPorId(int id)
        {
            return _SESMTEmpresaFuncionarioRepository.ObterPorId(id);
        }

        public IEnumerable<SESMTEmpresaFuncionario> ObterTodos()
        {
            return _SESMTEmpresaFuncionarioRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa, int SESMTEmpresaId)
        {
            return _SESMTEmpresaFuncionarioRepository.ObterTotalRegistros(pesquisa, SESMTEmpresaId);
        }
    }
}
