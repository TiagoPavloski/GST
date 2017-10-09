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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public UsuarioService(IUsuarioRepository UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }

        public void Adicionar(Usuario Usuario)
        {
            _UsuarioRepository.Adicionar(Usuario);
        }

        public void Atualizar(Usuario Usuario)
        {
            _UsuarioRepository.Atualizar(Usuario);
        }

        public void Dispose()
        {
            _UsuarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _UsuarioRepository.Excluir(id);
        }

        public IEnumerable<Usuario> Find(Expression<Func<Usuario, bool>> predicate)
        {
            return _UsuarioRepository.Find(predicate);
        }

        public IEnumerable<Usuario> ObterGrid(int page, string pesquisa)
        {
            return _UsuarioRepository.ObterGrid(page, pesquisa);
        }

        public Usuario ObterPorId(int id)
        {
            return _UsuarioRepository.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _UsuarioRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _UsuarioRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
