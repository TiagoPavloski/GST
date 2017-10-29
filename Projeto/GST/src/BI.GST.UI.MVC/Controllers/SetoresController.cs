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
    public class SetoresController : Controller
    {
        private readonly ISetorAppService _setorAppService;
        private readonly ITipoSetorAppService _tipoSetorAppService;
        private readonly IAgenteAcidenteAppService _agenteAcidenteAppService;
        private readonly IAgenteBiologicoAppService _agenteBiologicoAppService;
        private readonly IAgenteErgonomicoAppService _agenteErgonomicoAppService;
        private readonly IAgenteFisicoAppService _agenteFisicoAppService;
        private readonly IAgenteQuimicoAppService _agenteQuimicoAppService;
        

        public SetoresController(ISetorAppService setorAppService, ITipoSetorAppService tipoSetorAppService, IAgenteAcidenteAppService agenteAcidenteAppService,
            IAgenteBiologicoAppService agenteBiologicoAppService, IAgenteErgonomicoAppService agenteErgonomicoAppService,
            IAgenteFisicoAppService agenteFisicoAppService, IAgenteQuimicoAppService agenteQuimicoAppService)
        {
            _setorAppService = setorAppService;
            _tipoSetorAppService = tipoSetorAppService;
            _agenteAcidenteAppService = agenteAcidenteAppService;
            _agenteBiologicoAppService = agenteBiologicoAppService;
            _agenteErgonomicoAppService = agenteErgonomicoAppService;
            _agenteFisicoAppService = agenteFisicoAppService;
            _agenteQuimicoAppService = agenteQuimicoAppService;
        }

        // GET: setors
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var setorViewModel = _setorAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "setors";
            ViewBag.TotalRegistros = _setorAppService.ObterTotalRegistros(pesquisa);
            return View(setorViewModel);
        }

        // GET: setors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetorViewModel setor = _setorAppService.ObterPorId(id.Value);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // GET: setors/Create
        public ActionResult Create()
        {
            ViewBag.TipoSetorId = new SelectList(_tipoSetorAppService.ObterTodos(), "TipoSetorId", "Nome");
            ViewBag.AgenteAcidentes = new MultiSelectList(_agenteAcidenteAppService.ObterTodos(), "AgenteAcidenteId", "Nome");
            ViewBag.AgenteBiologicos = new MultiSelectList(_agenteBiologicoAppService.ObterTodos(), "AgenteBiologicoId", "Nome");
            ViewBag.AgenteErgonomicos = new MultiSelectList(_agenteErgonomicoAppService.ObterTodos(), "AgenteErgonomicoId", "Nome");
            ViewBag.AgenteFisicos = new MultiSelectList(_agenteFisicoAppService.ObterTodos(), "AgenteFisicoId", "Nome");
            ViewBag.AgenteQuimicos = new MultiSelectList(_agenteQuimicoAppService.ObterTodos(), "AgenteQuimicoId", "Nome");
            var setor = new SetorViewModel();

            return View(setor);
        }

        // POST: setors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SetorViewModel setorViewModel, int[] agenteAcidenteId, int[] agenteBiologicoId
            , int[] agenteErgonomicoId, int[] agenteFisicoId, int[] agenteQuimicoId)
        {
            if (ModelState.IsValid)
            {
                if (!_setorAppService.Adicionar(setorViewModel, agenteAcidenteId, agenteBiologicoId, agenteErgonomicoId, agenteFisicoId, agenteQuimicoId))
                {
                    ViewBag.TipoSetores = new SelectList(_tipoSetorAppService.ObterTodos(), "TipoSetorId", "Nome");
                    TempData["Mensagem"] = "Atenção, há um setor com os mesmos dados";
                }
                else
                    return RedirectToAction("Index");
            }
            ViewBag.AgenteAcidentes = new MultiSelectList(_agenteAcidenteAppService.ObterTodos(), "AgenteAcidenteId", "Nome");
            ViewBag.AgenteBiologicos = new MultiSelectList(_agenteBiologicoAppService.ObterTodos(), "AgenteBiologicoId", "Nome");
            ViewBag.AgenteErgonomicos = new MultiSelectList(_agenteErgonomicoAppService.ObterTodos(), "AgenteErgonomicoId", "Nome");
            ViewBag.AgenteFisicos = new MultiSelectList(_agenteFisicoAppService.ObterTodos(), "AgenteFisicoId", "Nome");
            ViewBag.AgenteQuimicos = new MultiSelectList(_agenteQuimicoAppService.ObterTodos(), "AgenteQuimicoId", "Nome");
            return View(setorViewModel);
        }

        // GET: setors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var setor = _setorAppService.ObterPorId(id.Value);
            if (setor == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoSetorId = new SelectList(_tipoSetorAppService.ObterTodos(), "TipoSetorId", "Nome", setor.TipoSetorId);
            ViewBag.AgenteAcidentes = new MultiSelectList(_agenteAcidenteAppService.ObterTodos(), "AgenteAcidenteId", "Nome", setor.AgenteAcidentes.Select(x => x.AgenteAcidenteId));
            ViewBag.AgenteBiologicos = new MultiSelectList(_agenteBiologicoAppService.ObterTodos(), "AgenteBiologicoId", "Nome", setor.AgenteBiologicos.Select(x => x.AgenteBiologicoId));
            ViewBag.AgenteErgonomicos = new MultiSelectList(_agenteErgonomicoAppService.ObterTodos(), "AgenteErgonomicoId", "Nome", setor.AgenteErgonomicos.Select(x => x.AgenteErgonomicoId));
            ViewBag.AgenteFisicos = new MultiSelectList(_agenteFisicoAppService.ObterTodos(), "AgenteFisicoId", "Nome", setor.AgenteFisicos.Select(x => x.AgenteFisicoId));
            ViewBag.AgenteQuimicos = new MultiSelectList(_agenteQuimicoAppService.ObterTodos(), "AgenteQuimicoId", "Nome", setor.AgenteQuimicos.Select(x => x.AgenteQuimicoId));
            return View(setor);
        }

        // POST: setors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SetorViewModel setorViewModel, int[] agenteAcidenteId, int[] agenteBiologicoId
            , int[] agenteErgonomicoId, int[] agenteFisicoId, int[] agenteQuimicoId)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TipoSetorId = new SelectList(_tipoSetorAppService.ObterTodos(), "TipoSetorId", "Nome", setorViewModel.TipoSetorId);
                if (!_setorAppService.Atualizar(setorViewModel, agenteAcidenteId, agenteBiologicoId, agenteErgonomicoId, agenteFisicoId, agenteQuimicoId))
                {
                    TempData["Mensagem"] = "Atenção, há um setor com os mesmos dados";
                }
                else
                    return RedirectToAction("Index");
            }
            ViewBag.AgenteAcidentes = new MultiSelectList(_agenteAcidenteAppService.ObterTodos(), "AgenteAcidenteId", "Nome");
            ViewBag.AgenteBiologicos = new MultiSelectList(_agenteBiologicoAppService.ObterTodos(), "AgenteBiologicoId", "Nome");
            ViewBag.AgenteErgonomicos = new MultiSelectList(_agenteErgonomicoAppService.ObterTodos(), "AgenteErgonomicoId", "Nome");
            ViewBag.AgenteFisicos = new MultiSelectList(_agenteFisicoAppService.ObterTodos(), "AgenteFisicoId", "Nome");
            ViewBag.AgenteQuimicos = new MultiSelectList(_agenteQuimicoAppService.ObterTodos(), "AgenteQuimicoId", "Nome");
            return View(setorViewModel);
        }

        // GET: setors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetorViewModel setor = _setorAppService.ObterPorId(id.Value);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // POST: setors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_setorAppService.Excluir(id))
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Erro')</SCRIPT>");
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
                _setorAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
