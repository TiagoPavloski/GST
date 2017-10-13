using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using AutoMapper;
using BI.GST.Domain.Entities;

namespace BI.GST.Application.AppService
{
    public class ColaboradorAppService : BaseAppService, IColaboradorAppService
    {
        private readonly IColaboradorService _colaboradorService;

        public ColaboradorAppService(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        public bool Adicionar(ColaboradorViewModel colaboradorViewModel)
        {
            var colaborador = Mapper.Map<ColaboradorViewModel, Colaborador>(colaboradorViewModel);

            var duplicado = _colaboradorService.Find(x => (x.CPF == colaborador.CPF)
                                && (x.Delete == false)).Any();
            if (duplicado)
                return false;
            else
            {
                BeginTransaction();
                _colaboradorService.Adicionar(colaborador);
                Commit();
                return true;
            }
        }

        public bool Atualizar(ColaboradorViewModel colaboradorViewModel)
        {
            var colaborador = Mapper.Map<ColaboradorViewModel, Colaborador>(colaboradorViewModel);

            var duplicado = _colaboradorService.Find(x => (x.CPF == colaborador.CPF)
                                && (x.Delete == false)
                                && (x.ColaboradorId != colaborador.ColaboradorId)).Any();
            if (duplicado)
                return false;
            else
            {
                BeginTransaction();
                _colaboradorService.Atualizar(colaborador);
                Commit();
                return true;
            }
        }

        public void Dispose()
        {
            _colaboradorService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _colaboradorService.Find(e => e.ColaboradorId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var colaborador = _colaboradorService.ObterPorId(id);
                colaborador.Delete = true;
                _colaboradorService.Atualizar(colaborador);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<ColaboradorViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<Colaborador>, IEnumerable<ColaboradorViewModel>>(_colaboradorService.ObterGrid(page, pesquisa));
        }

        public ColaboradorViewModel ObterPorId(int id)
        {
            return Mapper.Map<Colaborador, ColaboradorViewModel>(_colaboradorService.ObterPorId(id));
        }

        public IEnumerable<ColaboradorViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Colaborador>, IEnumerable<ColaboradorViewModel>>(_colaboradorService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _colaboradorService.ObterTotalRegistros(pesquisa);
        }
    }
}
