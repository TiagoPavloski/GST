using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Services
{
    public class FuncionarioEmpresaService : IFuncionarioEmpresaService
    {
        private readonly IFuncionarioEmpresaRepository _funcionarioEmpresaRepository;

        public FuncionarioEmpresaService(IFuncionarioEmpresaRepository funcionarioEmpresaRepository)
        {
            _funcionarioEmpresaRepository = funcionarioEmpresaRepository;
        }

        public void Adicionar(FuncionarioEmpresa funcionarioEmpresa)
        {
            _funcionarioEmpresaRepository.Adicionar(funcionarioEmpresa);
        }

        public void Atualizar(FuncionarioEmpresa funcionario)
        {
            _funcionarioEmpresaRepository.Atualizar(funcionario);
        }

        public void Dispose()
        {
            _funcionarioEmpresaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _funcionarioEmpresaRepository.Excluir(id);
        }

        public IEnumerable<FuncionarioEmpresa> Find(Expression<Func<FuncionarioEmpresa, bool>> predicate)
        {
            return _funcionarioEmpresaRepository.Find(predicate);
        }

        public IEnumerable<FuncionarioEmpresa> ObterGrid(int page, string pesquisa)
        {
            return _funcionarioEmpresaRepository.ObterGrid(page, pesquisa);
        }

        public FuncionarioEmpresa ObterPorId(int id)
        {
            return _funcionarioEmpresaRepository.ObterPorId(id);
        }

        public IEnumerable<FuncionarioEmpresa> ObterTodos()
        {
            return _funcionarioEmpresaRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _funcionarioEmpresaRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
