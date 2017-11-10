using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BI.GST.Domain.Entities;
using BI.GST.Infra.Data.Context;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;

namespace BI.GST.UI.MVC.Controllers
{
    public class RiscoCBOsController : Controller
    {
        private readonly IRiscoCBOAppService _riscoCBOAppService;
        private readonly IAgenteRiscoCBOAppService _agenteRiscoCBOAppService;
        private readonly IFonteRiscoCBOAppService _fonteRiscoCBOAppService;
        private readonly IAgenteCausadorCBOAppService _agenteCausadorCBOAppService;

        public RiscoCBOsController(IRiscoCBOAppService riscoCBOAppService, IAgenteRiscoCBOAppService agenteRiscoCBOService,
            IFonteRiscoCBOAppService fonteRiscoCBOAppService, IAgenteCausadorCBOAppService agenteCausadorCBOService)
        {
            _riscoCBOAppService = riscoCBOAppService;
            _agenteRiscoCBOAppService = agenteRiscoCBOService;
            _fonteRiscoCBOAppService = fonteRiscoCBOAppService;
            _agenteCausadorCBOAppService = agenteCausadorCBOService;
        }

        // GET: RiscoCBOs
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var riscoCBOViewModel = _riscoCBOAppService.ObterGrid(pesquisa, page);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "RiscoCBOs";
            ViewBag.TotalRegistros = _riscoCBOAppService.ObterTotalRegistros();

            return View(riscoCBOViewModel);
        }

        // GET: RiscoCBOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var riscoCBO = _riscoCBOAppService.ObterPorId(id.Value);
            if (riscoCBO == null)
            {
                return HttpNotFound();
            }
            return View(riscoCBO);
        }

        // GET: RiscoCBOs/Create
        public ActionResult Create()
        {
            ViewBag.AgenteRiscoCBOId = new SelectList(_agenteRiscoCBOAppService.ObterTodos(), "AgenteRiscoCBOId", "Nome");
            ViewBag.AgenteCausadorCBOId = new SelectList(_agenteCausadorCBOAppService.ObterTodos(), "AgenteCausadorCBOId", "Nome");
            ViewBag.FonteRiscoCBOId = new SelectList(_fonteRiscoCBOAppService.ObterTodos(), "FonteRiscoCBOId", "Nome");
            return View();
        }

        // POST: RiscoCBOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RiscoCBOViewModel riscoCBOViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_riscoCBOAppService.Adicionar(riscoCBOViewModel))
                {
                    TempData["Mensagem"] = "Atenção, um risco de CBO com o mesmo nome";
                }
                else
                    return RedirectToAction("Index");
            }

            ViewBag.AgenteRiscoCBOId = new SelectList(_agenteRiscoCBOAppService.ObterTodos(), "AgenteRiscoCBOId", "Nome", riscoCBOViewModel.AgenteRiscoCBOId);
            ViewBag.FonteRiscoCBOId = new SelectList(_fonteRiscoCBOAppService.ObterTodos(), "FonteRiscoCBOId", "Nome", riscoCBOViewModel.FonteRiscoCBOId);
            ViewBag.AgenteCausadorCBOId = new SelectList(_agenteCausadorCBOAppService.ObterTodos(), "AgenteCausadorCBOId", "Nome", riscoCBOViewModel.AgenteCausadorCBOId);

            return View(riscoCBOViewModel);
        }

        // GET: RiscoCBOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var riscoCBO = _riscoCBOAppService.ObterPorId(id.Value);
            if (riscoCBO == null)
            {
                return HttpNotFound();
            }

            ViewBag.AgenteRiscoCBOId = new SelectList(_agenteRiscoCBOAppService.ObterTodos(), "AgenteRiscoCBOId", "Nome", riscoCBO.AgenteRiscoCBOId);
            ViewBag.FonteRiscoCBOID = new SelectList(_fonteRiscoCBOAppService.ObterTodos(), "FonteRiscoCBOId", "Nome", riscoCBO.FonteRiscoCBOId);
            ViewBag.AgenteCausadorCBOID = new SelectList(_agenteCausadorCBOAppService.ObterTodos(), "AgenteCausadorCBOId", "Nome", riscoCBO.AgenteCausadorCBOId);

            return View(riscoCBO);
        }

        // POST: RiscoCBOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RiscoCBOViewModel riscoCBOViewModel)
        {
            ViewBag.AgenteRiscoCBOId = new SelectList(_agenteRiscoCBOAppService.ObterTodos(), "AgenteRiscoCBOId", "Nome", riscoCBOViewModel.AgenteRiscoCBOId);
            ViewBag.FonteRiscoCBOId = new SelectList(_fonteRiscoCBOAppService.ObterTodos(), "FonteRiscoCBOId", "Nome", riscoCBOViewModel.FonteRiscoCBOId);
            ViewBag.AgenteCausadorCBOId = new SelectList(_agenteCausadorCBOAppService.ObterTodos(), "AgenteCausadorCBOId", "Nome", riscoCBOViewModel.AgenteCausadorCBOId);

            if (ModelState.IsValid)
            {
                if (!_riscoCBOAppService.Atualizar(riscoCBOViewModel))
                {
                    TempData["Mensagem"] = "Atenção, um risco de CBO com o mesmo nome";
                }
                else
                    return RedirectToAction("Index");
            }
            return View(riscoCBOViewModel);
        }

        // GET: RiscoCBOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var riscoCBO = _riscoCBOAppService.ObterPorId(id.Value);
            if (riscoCBO == null)
            {
                return HttpNotFound();
            }
            return View(riscoCBO);
        }

        // POST: RiscoCBOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_riscoCBOAppService.Excluir(id))
            {
                TempData["Mensagem"] = "Erro, atualize a página";
                return null;
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _riscoCBOAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
