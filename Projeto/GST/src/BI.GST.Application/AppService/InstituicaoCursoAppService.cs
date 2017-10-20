using BI.GST.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using BI.GST.Domain.Entities;
using AutoMapper;

namespace BI.GST.Application.AppService
{
    public class InstituicaoCursoAppService : BaseAppService, IInstituicaoCursoAppService
    {
        private readonly IInstituicaoCursoService _instituicaoCursoService;

        public InstituicaoCursoAppService(IInstituicaoCursoService instituicaoCursoCBOService)
        {
            _instituicaoCursoService = instituicaoCursoCBOService;
        }

        public bool Adicionar(InstituicaoCursoViewModel instituicaoCursoViewModel)
        {
            var instituicaoCurso = Mapper.Map<InstituicaoCursoViewModel, InstituicaoCurso>(instituicaoCursoViewModel);

            var duplicado = _instituicaoCursoService.Find(e => e.Nome == instituicaoCurso.Nome).Where(d => d.Delete == false).Any();
            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _instituicaoCursoService.Adicionar(instituicaoCurso);
                Commit();
                return true;
            }
        }

        public bool Atualizar(InstituicaoCursoViewModel instituicaoCursoViewModel)
        {
            var instituicaoCurso = Mapper.Map<InstituicaoCursoViewModel, InstituicaoCurso>(instituicaoCursoViewModel);

            var duplicado = _instituicaoCursoService.Find(e => e.Nome == instituicaoCurso.Nome && e.Delete == false && e.InstituicaoCursoId != instituicaoCurso.InstituicaoCursoId).Any();

            if (duplicado)
            {
                return false;
            }
            else
            {
                BeginTransaction();
                _instituicaoCursoService.Atualizar(instituicaoCurso);
                Commit();
                return true;
            }

        }

        public void Dispose()
        {
            _instituicaoCursoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _instituicaoCursoService.Find(e => e.InstituicaoCursoId == id).Any();

            if (existente)
            {
                BeginTransaction();
                var agenteCausadorCBO = _instituicaoCursoService.ObterPorId(id);
                agenteCausadorCBO.Delete = true;
                _instituicaoCursoService.Atualizar(agenteCausadorCBO);
                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<InstituicaoCursoViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<InstituicaoCurso>, IEnumerable<InstituicaoCursoViewModel>>(_instituicaoCursoService.ObterGrid(page, pesquisa));
        }

        public InstituicaoCursoViewModel ObterPorId(int id)
        {
            return Mapper.Map<InstituicaoCurso, InstituicaoCursoViewModel>(_instituicaoCursoService.ObterPorId(id));
        }

        public IEnumerable<InstituicaoCursoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<InstituicaoCurso>, IEnumerable<InstituicaoCursoViewModel>>(_instituicaoCursoService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _instituicaoCursoService.ObterTotalRegistros(pesquisa);
        }
    }
}
