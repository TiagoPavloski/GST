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
    public class RiscoFuncionarioService : IRiscoFuncionarioService
    {
        private readonly IRiscoFuncionarioRepository _riscoFuncionarioRepository;

        public RiscoFuncionarioService(IRiscoFuncionarioRepository riscoFuncionarioRepository)
        {
            _riscoFuncionarioRepository = riscoFuncionarioRepository;
        }

        public void Adicionar(RiscoFuncionario riscoFuncionario)
        {
            _riscoFuncionarioRepository.Adicionar(riscoFuncionario);
        }

        public void Atualizar(RiscoFuncionario riscoFuncionario)
        {
            _riscoFuncionarioRepository.Atualizar(riscoFuncionario);
        }

        public void Dispose()
        {
            _riscoFuncionarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _riscoFuncionarioRepository.Excluir(id);
        }

        public IEnumerable<RiscoFuncionario> Find(Expression<Func<RiscoFuncionario, bool>> predicate)
        {
            return _riscoFuncionarioRepository.Find(predicate);
        }

        public IEnumerable<RiscoFuncionario> ObterGrid(int page, string pesquisa)
        {
            return _riscoFuncionarioRepository.ObterGrid(page, pesquisa);
        }

        public RiscoFuncionario ObterPorId(int id)
        {
            return _riscoFuncionarioRepository.ObterPorId(id);
        }

        public IEnumerable<RiscoFuncionario> ObterTodos()
        {
            return _riscoFuncionarioRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _riscoFuncionarioRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
