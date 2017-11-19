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
    public class AgenteFisicosController : Controller
    {
        private readonly IAgenteFisicoAppService _agenteFisicoAppService;
        private readonly IClassificacaoEfeitoAppService _classificacaoEfeitoAppService;

        public AgenteFisicosController(IAgenteFisicoAppService agenteFisicoAppService, IClassificacaoEfeitoAppService clasificacaoEfeitoAppService)
        {
            _agenteFisicoAppService = agenteFisicoAppService;
            _classificacaoEfeitoAppService = clasificacaoEfeitoAppService;
        }

        // GET: agenteFisicos
        public ActionResult Index(string pesquisa, int page = 0)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            var agenteFisicoViewModel = _agenteFisicoAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "agenteFisicos";
            ViewBag.TotalRegistros = _agenteFisicoAppService.ObterTotalRegistros(pesquisa);
            return View(agenteFisicoViewModel);
        }

        // GET: agenteFisicos/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteFisicoViewModel agenteFisico = _agenteFisicoAppService.ObterPorId(id.Value);
            if (agenteFisico == null)
            {
                return HttpNotFound();
            }
            return View(agenteFisico);
        }

        // GET: agenteFisicos/Create
        public ActionResult Create()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            ViewBag.ClassificacaoEfeitoId = new SelectList(_classificacaoEfeitoAppService.ObterTodos(), "ClassificacaoEfeitoId", "Classificacao");
            var agenteFisicoViewModel = new AgenteFisicoViewModel();
            return View(agenteFisicoViewModel);
        }

        // POST: agenteFisicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgenteFisicoViewModel agenteFisicoViewModel)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (ModelState.IsValid)
            {
                if (!_agenteFisicoAppService.Adicionar(agenteFisicoViewModel))
                {
                    ViewBag.ClassificacaoEfeitoId = new SelectList(_classificacaoEfeitoAppService.ObterTodos(), "ClassificacaoEfeitoId", "Classificacao");
                    TempData["Mensagem"] = "Atenção, há um Agente Fisico com os mesmos dados";
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agenteFisico com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(agenteFisicoViewModel);
        }

        // GET: agenteFisicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteFisicoViewModel = _agenteFisicoAppService.ObterPorId(id.Value);
            if (agenteFisicoViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassificacaoEfeitoId = new SelectList(_classificacaoEfeitoAppService.ObterTodos(), "ClassificacaoEfeitoId", "Classificacao", agenteFisicoViewModel.ClassificacaoEfeitoId);
            return View(agenteFisicoViewModel);
        }

        // POST: agenteFisicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AgenteFisicoViewModel agenteFisicoViewModel)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (ModelState.IsValid)
            {
                if (!_agenteFisicoAppService.Atualizar(agenteFisicoViewModel))
                {
                    TempData["Mensagem"] = "Atenção, há um Agente Fisico com os mesmos dados já cadastrado";
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agenteErgonômico com os mesmos dados já cadastrada')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            ViewBag.ClassificacaoEfeitoId = new SelectList(_classificacaoEfeitoAppService.ObterTodos(), "ClassificacaoEfeitoId", "Classificacao", agenteFisicoViewModel.ClassificacaoEfeitoId);
            return View(agenteFisicoViewModel);
        }

        // GET: agenteFisicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteFisicoViewModel agenteFisico = _agenteFisicoAppService.ObterPorId(id.Value);
            if (agenteFisico == null)
            {
                return HttpNotFound();
            }
            return View(agenteFisico);
        }

        // POST: agenteFisicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (!_agenteFisicoAppService.Excluir(id))
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
                _agenteFisicoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
