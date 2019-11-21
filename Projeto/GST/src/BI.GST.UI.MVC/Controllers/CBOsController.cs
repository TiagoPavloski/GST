﻿using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using BI.GST.Domain.Entities;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using System.Linq;

namespace BI.GST.UI.MVC.Controllers
{
    public class CBOsController : Controller
    {
        private readonly ICBOAppService _cboAppService;
        private readonly IRiscoCBOAppService _riscoCBOAppService;
        private readonly ITipoCursoAppService _tipoCursoAppService;
        private readonly ITipoExameAppService _tipoExameAppService;
        private readonly ITipoVacinaAppService _tipoVacinaAppService;

        public CBOsController(ICBOAppService cboAppService, IRiscoCBOAppService riscoCBOAppService,
            ITipoCursoAppService tipoCursoAppService, ITipoExameAppService tipoExameAppService, ITipoVacinaAppService tipoVacinaAppService)
        {
            _cboAppService = cboAppService;
            _riscoCBOAppService = riscoCBOAppService;
            _tipoCursoAppService = tipoCursoAppService;
            _tipoExameAppService = tipoExameAppService;
            _tipoVacinaAppService = tipoVacinaAppService;

        }

        // GET: CBOs
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var cboViewModel = _cboAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "CBOs";
            ViewBag.TotalRegistros = _cboAppService.ObterTotalRegistros(pesquisa);

            return View(cboViewModel);
        }

        // GET: CBOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cbo = _cboAppService.ObterPorId(id.Value);
            if (cbo == null)
            {
                return HttpNotFound();
            }
            return View(cbo);
        }

        // GET: CBOs/Create
        public ActionResult Create()
        {
            ViewBag.RiscoCBOList = new SelectList(_riscoCBOAppService.ObterTodos(), "RiscoCBOId", "Nome");
            ViewBag.TipoCursoList = new SelectList(_tipoCursoAppService.ObterTodos(), "TipoCursoId", "Nome");
            ViewBag.TipoExameList = new SelectList(_tipoExameAppService.ObterTodos(), "TipoExameId", "Nome");
            ViewBag.TipoVacinaList = new SelectList(_tipoVacinaAppService.ObterTodos(), "TipoVacinaId", "Nome");

            var cboViewModel = new CBOViewModel();
            return View(cboViewModel);
        }

        // POST: CBOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CBOViewModel cboViewModel, int[] riscoCBOId, int[] tipoCursoId, int[] tipoExameId, int[] tipoVacina)
        {
            ViewBag.RiscoCBOList = new SelectList(_riscoCBOAppService.ObterTodos(), "RiscoCBOId", "Nome");
            ViewBag.TipoCursoList = new SelectList(_tipoCursoAppService.ObterTodos(), "TipoCursoId", "Nome");
            ViewBag.TipoExameList = new SelectList(_tipoExameAppService.ObterTodos(), "TipoExameId", "Nome");
            ViewBag.TipoVacinaList = new SelectList(_tipoVacinaAppService.ObterTodos(), "TipoVacinaId", "Nome");

            if (ModelState.IsValid)
            {
                var result = _cboAppService.Adicionar(cboViewModel, riscoCBOId, tipoCursoId, tipoExameId, tipoVacina);
                if (result != "")
                {
                    TempData["Mensagem"] = result;

                }
                else
                    return RedirectToAction("Index");
            }
            return View(cboViewModel);
        }

        // GET: CBOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cbo = _cboAppService.ObterPorId(id.Value);
            if (cbo == null)
            {
                return HttpNotFound();
            }
 
            ViewBag.RiscoCBOList = new MultiSelectList(_riscoCBOAppService.ObterTodos(), "RiscoCBOId", "Nome", cbo.RiscoCBOs.Select(x => x.RiscoCBOId));
            ViewBag.TipoCursoList = new MultiSelectList(_tipoCursoAppService.ObterTodos(), "TipoCursoId", "Nome", cbo.TipoCursos.Select(x => x.TipoCursoId));
            ViewBag.TipoExameList = new MultiSelectList(_tipoExameAppService.ObterTodos(), "TipoExameId", "Nome", cbo.TipoExames.Select(x => x.TipoExameId));
            ViewBag.TipoVacinaList = new MultiSelectList(_tipoVacinaAppService.ObterTodos(), "TipoVacinaId", "Nome", cbo.TipoVacinas.Select(x => x.TipoVacinaId));

            return View(cbo);
        }

        // POST: CBOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CBOViewModel cboViewModel, int[] riscoCBOId, int[] tipoCursoId, int[] tipoExameId, int[] tipoVacina)
        {
            if (ModelState.IsValid)
            {
                ViewBag.RiscoCBOList = new SelectList(_riscoCBOAppService.ObterTodos(), "RiscoCBOId", "Nome");
                ViewBag.TipoCursoList = new SelectList(_tipoCursoAppService.ObterTodos(), "TipoCursoId", "Nome");
                ViewBag.TipoExameList = new SelectList(_tipoExameAppService.ObterTodos(), "TipoExameId", "Nome");
                ViewBag.TipoVacinaList = new SelectList(_tipoVacinaAppService.ObterTodos(), "TipoVacinaId", "Nome");

                var result = _cboAppService.Atualizar(cboViewModel, riscoCBOId, tipoCursoId, tipoExameId, tipoVacina);
                if (result != "")
                {
                    TempData["Mensagem"] = result;

                }
                else
                    return RedirectToAction("Index");
            }
            return View(cboViewModel);
        }

        // GET: CBOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cbo = _cboAppService.ObterPorId(id.Value);
            if (cbo == null)
            {
                return HttpNotFound();
            }
            return View(cbo);
        }

        // POST: CBOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var result = _cboAppService.Excluir(id);
            if (result != "")
            {
                TempData["Mensagem"] = result;
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cboAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
