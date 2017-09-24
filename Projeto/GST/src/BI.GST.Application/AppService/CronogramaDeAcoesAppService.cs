﻿using BI.GST.Application.Interface;
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
    public class CronogramaDeAcoesAppService : BaseAppService, ICronogramaDeAcoesAppService
    {

        private readonly ICronogramaDeAcoesService _cronogramaDeAcoesService;

        public CronogramaDeAcoesAppService(ICronogramaDeAcoesService cronogramaDeAcoesService)
        {
            _cronogramaDeAcoesService = cronogramaDeAcoesService;
        }

        public bool Adicionar(CronogramaDeAcoesViewModel cronogramaDeAcoesViewModel)
        {
            var Cronograma = Mapper.Map<CronogramaDeAcoesViewModel, CronogramaDeAcoes>(cronogramaDeAcoesViewModel);

            BeginTransaction();
            _cronogramaDeAcoesService.Adicionar(Cronograma);
            Commit();
            return true;
        }

        public bool Atualizar(CronogramaDeAcoesViewModel cronogramaDeAcoesViewModel)
        {
            var cronograma = Mapper.Map<CronogramaDeAcoesViewModel, CronogramaDeAcoes>(cronogramaDeAcoesViewModel);

            BeginTransaction();
            _cronogramaDeAcoesService.Atualizar(cronograma);
            Commit();
            return true;
        }

        public void Dispose()
        {
            _cronogramaDeAcoesService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _cronogramaDeAcoesService.Find(e => e.CronogramaDeAcoesId == id).Any();
            if (existente)
            {
                BeginTransaction();
                var cronograma = _cronogramaDeAcoesService.ObterPorId(id);
                cronograma.Delete = true;
                _cronogramaDeAcoesService.Atualizar(cronograma);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<CronogramaDeAcoesViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<CronogramaDeAcoes>, IEnumerable<CronogramaDeAcoesViewModel>>(_cronogramaDeAcoesService.ObterGrid(page, pesquisa));
        }

        public CronogramaDeAcoesViewModel ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CronogramaDeAcoesViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<CronogramaDeAcoes>, IEnumerable<CronogramaDeAcoesViewModel>>(_cronogramaDeAcoesService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _cronogramaDeAcoesService.ObterTotalRegistros(pesquisa);
        }
    }
}
