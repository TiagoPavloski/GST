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
    public class MedicaoAgenteAppService : BaseAppService, IMedicaoAgenteAppService
    {
        private readonly IMedicaoAgenteService _medicaoAgenteService;

        public MedicaoAgenteAppService(IMedicaoAgenteService medicaoAgenteService)
        {
            _medicaoAgenteService = medicaoAgenteService;
        }

        public bool Adicionar(MedicaoAgenteViewModel medicaoAgenteViewModel)
        {
            var medicao = Mapper.Map<MedicaoAgenteViewModel, MedicaoAgente>(medicaoAgenteViewModel);

            BeginTransaction();
            _medicaoAgenteService.Adicionar(medicao);
            Commit();
            return true;
        }

        public bool Atualizar(MedicaoAgenteViewModel medicaoAgenteViewModel)
        {
            var medicao = Mapper.Map<MedicaoAgenteViewModel, MedicaoAgente>(medicaoAgenteViewModel);

            BeginTransaction();
            _medicaoAgenteService.Atualizar(medicao);
            Commit();
            return true;
        }

        public void Dispose()
        {
            _medicaoAgenteService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _medicaoAgenteService.Find(e => e.MedicaoAgenteId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var medicaoAgente = _medicaoAgenteService.ObterPorId(id);
                medicaoAgente.Delete = true;
                _medicaoAgenteService.Atualizar(medicaoAgente);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<MedicaoAgenteViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<MedicaoAgente>, IEnumerable<MedicaoAgenteViewModel>>(_medicaoAgenteService.ObterGrid(page, pesquisa));
        }

        public MedicaoAgenteViewModel ObterPorId(int id)
        {
            return Mapper.Map<MedicaoAgente, MedicaoAgenteViewModel>(_medicaoAgenteService.ObterPorId(id));
        }

        public IEnumerable<MedicaoAgenteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<MedicaoAgente>, IEnumerable<MedicaoAgenteViewModel>>(_medicaoAgenteService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _medicaoAgenteService.ObterTotalRegistros(pesquisa);
        }
    }
}
