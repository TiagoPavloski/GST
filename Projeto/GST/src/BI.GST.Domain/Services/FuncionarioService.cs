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
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public void Adicionar(Funcionario funcionario)
        {
            _funcionarioRepository.Adicionar(funcionario);
        }

        public void Atualizar(Funcionario funcionario)
        {
            _funcionarioRepository.Atualizar(funcionario);
        }

        public void Dispose()
        {
            _funcionarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _funcionarioRepository.Excluir(id);
        }

        public IEnumerable<Funcionario> Find(Expression<Func<Funcionario, bool>> predicate)
        {
            return _funcionarioRepository.Find(predicate);
        }

        public IEnumerable<Funcionario> ObterGrid(string pesquisa, int page)
        {
            return _funcionarioRepository.ObterGrid(pesquisa, page);
        }

        public Funcionario ObterPorId(int id)
        {
            return _funcionarioRepository.ObterPorId(id);
        }

        public IEnumerable<Funcionario> ObterPorEmpresa(int empresaId)
        {
            return _funcionarioRepository.ObterPorEmpresa(empresaId);
        }

        public IEnumerable<Funcionario> ObterFuncionariosEC(int empresaId, int cursoId)
        {
            return _funcionarioRepository.ObterFuncionariosEC(empresaId, cursoId);
        }

        public IEnumerable<Funcionario> ObterTodos()
        {
            return _funcionarioRepository.ObterTodos();
        }

        public IEnumerable<Funcionario> ObterTodosAtivos()
        {
            return _funcionarioRepository.ObterTotalAtivos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _funcionarioRepository.ObterTotalRegistros(pesquisa);
        }

        public int ObterTotalPorEmpresa(int idEmpresa)
        {
            return _funcionarioRepository.ObterTotalPorEmpresa(idEmpresa);
        }
    }
}
