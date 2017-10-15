using AutoMapper;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BI.GST.Application.AppService
{
    public class CBOAppService : BaseAppService, ICBOAppService
    {
        private readonly ICBOService _cboService;
        private readonly IRiscoCBOService _riscoCBOService;
        private readonly ITipoCursoService _tipoCursoService;
        private readonly ITipoExameService _tipoExameService;
        private readonly ITipoVacinaService _tipoVacinaService;

        public CBOAppService(ICBOService cboService, IRiscoCBOService riscoCBOService, ITipoCursoService tipoCursoService, ITipoExameService tipoExameService, ITipoVacinaService tipoVacinaService)
        {
            _cboService = cboService;
            _riscoCBOService = riscoCBOService;
            _tipoCursoService = tipoCursoService;
            _tipoExameService = tipoExameService;
            _tipoVacinaService = tipoVacinaService;

        }
        public bool Adicionar(CBOViewModel cboViewModel, int[] riscoCBOId, int[] tipoCursoId, int[] tipoExameId, int[] tipoVacina)
        {
            var cbo = Mapper.Map<CBOViewModel, CBO>(cboViewModel);

            if (riscoCBOId != null)
            {
                foreach (var item in riscoCBOId)
                    cbo.RiscoCBOs.Add(new RiscoCBO { RiscoCBOId = item });
            }

            if (tipoCursoId != null)
            {
                foreach (var item in tipoCursoId)
                    cbo.TipoCursos.Add(new TipoCurso { TipoCursoId = item });
            }
            if (tipoExameId != null)
            {
                foreach (var item in tipoExameId)
                    cbo.TipoExames.Add(new TipoExame { TipoExameId = item });
            }
            if (tipoVacina != null)
            {
                foreach (var item in tipoVacina)
                    cbo.TipoVacinas.Add(new TipoVacina { TipoVacinaId = item });
            }
            BeginTransaction();
            _cboService.Adicionar(cbo);
            Commit();
            return true;
        }


        public bool Atualizar(CBOViewModel cboViewModel, int[] riscoCBOId, int[] tipoCursoId, int[] tipoExameId, int[] tipoVacina)
        {

            var cbo = Mapper.Map<CBOViewModel, CBO>(cboViewModel);

            foreach (var item in riscoCBOId)
                cbo.RiscoCBOs.Add(new RiscoCBO { RiscoCBOId = item });

            foreach (var item in tipoCursoId)
                cbo.TipoCursos.Add(new TipoCurso { TipoCursoId = item });

            foreach (var item in tipoExameId)
                cbo.TipoExames.Add(new TipoExame { TipoExameId = item });

            foreach (var item in tipoVacina)
                cbo.TipoVacinas.Add(new TipoVacina { TipoVacinaId = item });

            BeginTransaction();
            _cboService.Atualizar(cbo);
            Commit();
            return true;
        }


        public void Dispose()
        {
            _cboService.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            bool existente = _cboService.Find(e => e.CBOId == id).Any();
            var cbo = _cboService.ObterPorId(id);

            if (existente)
            {
                BeginTransaction();
                cbo.Delete = true;
                _cboService.Atualizar(cbo);

                Commit();
                return true;
            }
            return false;
        }

        public IEnumerable<CBOViewModel> ObterGrid(int page, string pesquisa)
        {
            return Mapper.Map<IEnumerable<CBO>, IEnumerable<CBOViewModel>>(_cboService.ObterGrid(page, pesquisa));
        }

        public CBOViewModel ObterPorId(int id)
        {
            return Mapper.Map<CBO, CBOViewModel>(_cboService.ObterPorId(id));
        }

        public IEnumerable<CBOViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<CBO>, IEnumerable<CBOViewModel>>(_cboService.ObterTodos());
        }

        public int ObterTotalRegistros(string pesquisa)
        {
            return _cboService.ObterTotalRegistros(pesquisa);
        }

        public bool AdicionarResponsavel(string CPF)
        {
            throw new NotImplementedException();
        }

        public bool DeletarResponsavel(int id)
        {
            throw new NotImplementedException();
        }
    }
}
