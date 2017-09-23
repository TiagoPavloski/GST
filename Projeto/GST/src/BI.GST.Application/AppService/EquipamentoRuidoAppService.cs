using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using AutoMapper;
using BI.GST.Domain.Entities;

namespace BI.GST.Application.AppService
{
    public class EquipamentoRuidoAppService : BaseAppService, IEquipamentoRuidoAppService
    {
        private readonly IEquipamentoRuidoService _equipamentoRuidoService;

        public EquipamentoRuidoAppService(IEquipamentoRuidoService equipamentoRuidoService)
        {
            _equipamentoRuidoService = equipamentoRuidoService;
        }

        public bool Adicionar(EquipamentoRuidoViewModel equipamentoRuidoViewModel)
        {
            var equipamentoRuido = Mapper.Map<EquipamentoRuidoViewModel, EquipamentoRuido>(equipamentoRuidoViewModel);

            BeginTransaction();
            _equipamentoRuidoService.Adicionar(equipamentoRuido);
            Commit();
            return true;
        }

        public bool Atualizar(EquipamentoRuidoViewModel equipamentoRuidoViewModel)
        {
            var equipamentoRuido = Mapper.Map<EquipamentoRuidoViewModel, EquipamentoRuido>(equipamentoRuidoViewModel);

            BeginTransaction();
            _equipamentoRuidoService.Atualizar(equipamentoRuido);
            Commit();
            return true;
        }

        public void Dispose()
        {
            _equipamentoRuidoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _equipamentoRuidoService.Find(e => e.EquipamentoRuidoId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var equipamentoRuido = _equipamentoRuidoService.ObterPorId(id);
                equipamentoRuido.Delete = true;
                _equipamentoRuidoService.Atualizar(equipamentoRuido);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<EquipamentoRuidoViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<EquipamentoRuido>, IEnumerable<EquipamentoRuidoViewModel>>(_equipamentoRuidoService.ObterGrid(page, pesquisa));
        }

        public EquipamentoRuidoViewModel ObterPorId(int id)
        {
            return Mapper.Map<EquipamentoRuido, EquipamentoRuidoViewModel>(_equipamentoRuidoService.ObterPorId(id));
        }

        public IEnumerable<EquipamentoRuidoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<EquipamentoRuido>, IEnumerable<EquipamentoRuidoViewModel>>(_equipamentoRuidoService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _equipamentoRuidoService.ObterTotalRegistros(pesquisa);
        }
    }
}
