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
        private readonly IFuncionarioService _funcionarioService;
        private readonly IRiscoCBOService _riscoCBOService;
        private readonly ITipoCursoService _tipoCursoService;
        private readonly ITipoExameService _tipoExameService;
        private readonly ITipoVacinaService _tipoVacinaService;

        public CBOAppService(ICBOService cboService, IFuncionarioService funcionarioService, IRiscoCBOService riscoCBOService, ITipoCursoService tipoCursoService, ITipoExameService tipoExameService, ITipoVacinaService tipoVacinaService)
        {
            _cboService = cboService;
            _funcionarioService = funcionarioService;
            _riscoCBOService = riscoCBOService;
            _tipoCursoService = tipoCursoService;
            _tipoExameService = tipoExameService;
            _tipoVacinaService = tipoVacinaService;

        }
        public string Adicionar(CBOViewModel cboViewModel, int[] riscoCBOId, int[] tipoCursoId, int[] tipoExameId, int[] tipoVacina)
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

            var duplicado = _cboService.Find(e => (e.Nome == cbo.Nome) && (e.Delete == false)).Any();

            if (duplicado)
            {
                return "Atenção, já existe um CBO com este nome.";
            }
            else
            {
                BeginTransaction();
                _cboService.Adicionar(cbo);
                Commit();

                return "";
            }
        }


        public string Atualizar(CBOViewModel cboViewModel, int[] riscoCBOId, int[] tipoCursoId, int[] tipoExameId, int[] tipoVacinaId)
        {

            var cbo = Mapper.Map<CBOViewModel, CBO>(cboViewModel);

            if (riscoCBOId != null)
            {
                foreach (var item in riscoCBOId)
                    cbo.RiscoCBOs.Add(new RiscoCBO { RiscoCBOId = item });
            }
            
            if(tipoCursoId != null)
            {
                foreach (var item in tipoCursoId)
                    cbo.TipoCursos.Add(new TipoCurso { TipoCursoId = item });
            }

            if(tipoExameId != null)
            {
                foreach (var item in tipoExameId)
                    cbo.TipoExames.Add(new TipoExame { TipoExameId = item });
            }

            if (tipoVacinaId != null) {
                foreach (var item in tipoVacinaId)
                    cbo.TipoVacinas.Add(new TipoVacina { TipoVacinaId = item });
            }

            var duplicado = _cboService.Find(e => (e.Nome == cbo.Nome) && (e.Delete == false)).Any();
            if (duplicado)
            {
                return "Atenção, já existe um CBO com este nome.";
            }
            else
            {
                BeginTransaction();
                _cboService.Atualizar(cbo);
                Commit();

                return "";
            }
            
        }


        public void Dispose()
        {
            _cboService.Dispose();
            GC.SuppressFinalize(this);
        }

        public string Excluir(int id)
        {
            bool existente = _cboService.Find(e => e.CBOId == id).Any();
            bool usado = _funcionarioService.Find(f => f.CBOId == id && f.Delete == false).Any();

            if (usado)
            {
                return "Operação negada, há funcionários ativos vinculados à esta função.";
            }
            
            var cbo = _cboService.ObterPorId(id);

            if (existente)
            {
                BeginTransaction();
                cbo.Delete = true;
                _cboService.Atualizar(cbo);

                Commit();
                return "";
            }
            else
            {
                return "Função não encontrada no banco, atualize a página.";
            }
            
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
