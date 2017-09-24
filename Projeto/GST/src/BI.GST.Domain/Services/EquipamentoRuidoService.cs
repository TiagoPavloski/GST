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
    public class EquipamentoRuidoService : IEquipamentoRuidoService
    {
        private readonly IEquipamentoRuidoRepository _equipamentoRuidoRepository;

        public EquipamentoRuidoService(IEquipamentoRuidoRepository equipamentoRuidoRepository)
        {
            _equipamentoRuidoRepository = equipamentoRuidoRepository;
        }

        public void Adicionar(EquipamentoRuido equipamentoRuido)
        {
            _equipamentoRuidoRepository.Adicionar(equipamentoRuido);
        }

        public void Atualizar(EquipamentoRuido equipamentoRuido)
        {
            _equipamentoRuidoRepository.Atualizar(equipamentoRuido);
        }

        public void Dispose()
        {
            _equipamentoRuidoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            _equipamentoRuidoRepository.Excluir(id);
        }

        public IEnumerable<EquipamentoRuido> Find(Expression<Func<EquipamentoRuido, bool>> predicate)
        {
            return _equipamentoRuidoRepository.Find(predicate);
        }

        public IEnumerable<EquipamentoRuido> ObterGrid(int page, string pesquisa)
        {
            return _equipamentoRuidoRepository.ObterGrid(page, pesquisa);
        }

        public EquipamentoRuido ObterPorId(int id)
        {
            return _equipamentoRuidoRepository.ObterPorId(id);
        }

        public IEnumerable<EquipamentoRuido> ObterTodos()
        {
            return _equipamentoRuidoRepository.ObterTodos();
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _equipamentoRuidoRepository.ObterTotalRegistros(pesquisa);
        }
    }
}
