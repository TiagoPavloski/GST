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
using Rotativa.MVC;
using Microsoft.Reporting.WebForms;

namespace BI.GST.UI.MVC.Controllers
{
    public class PPRAsController : Controller
    {
        private readonly IPPRAAppService _PPRAAppService;
        private readonly IAgentePPRAAppService _agentePPRAAppService;
        private readonly ICronogramaDeAcoesAppService _cronogramaDeAcoesAppService;
        private readonly IAnexoAppService _anexoAppService;
        private readonly IColaboradorAppService _colaboradorAppService;
        private readonly IEquipamentoRuidoAppService _equipamentoRuidoAppService;
        private readonly IEmpresaAppService _empresaAppService;
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly ICIPAEmpresaAppService _cipaEmpresaAppService;
        private readonly IFuncionarioAppService _funcionarioAppService;
        private readonly IMeioPropagacaoAppService _meioPropagacaoAppService;
        private readonly IAgenteAmbientalAppService _agenteAmbientalAppService;

        public PPRAsController(IPPRAAppService ppraAppService, IAgentePPRAAppService agentePPRAAppService, ICronogramaDeAcoesAppService cronogramaDeAcoesAppService, IAnexoAppService anexoAppService,
            IColaboradorAppService colaboradorAppService, IEquipamentoRuidoAppService equipamentoRuidoAppService, IEmpresaAppService empresaAppService, IUsuarioAppService usuarioAppService, 
            ICIPAEmpresaAppService cipaEmpresaAppService, IFuncionarioAppService funcionarioAppService, IAgenteAmbientalAppService agenteAmbientalAppService, IMeioPropagacaoAppService meioPropagacaoAppService)
        {
            _PPRAAppService              = ppraAppService;
            _agentePPRAAppService        = agentePPRAAppService;
            _cronogramaDeAcoesAppService = cronogramaDeAcoesAppService;
            _anexoAppService             = anexoAppService;
            _colaboradorAppService       = colaboradorAppService;
            _equipamentoRuidoAppService  = equipamentoRuidoAppService;
            _empresaAppService           = empresaAppService;
            _usuarioAppService           = usuarioAppService;
            _cipaEmpresaAppService       = cipaEmpresaAppService;
            _funcionarioAppService       = funcionarioAppService;
            _agenteAmbientalAppService   = agenteAmbientalAppService;
            _meioPropagacaoAppService    = meioPropagacaoAppService;

        }

        public ActionResult Cronograma()
        {
            var cronograma = new CronogramaDeAcoesViewModel();
            return PartialView("_CronogramaDeAcoes", cronograma);
        }

        public ActionResult AgentePPRA()
        {
            var agentePPRA = new AgentePPRAViewModel();
            //Agente PPRA
            ViewBag.AgenteAmbientalId = new SelectList(_agenteAmbientalAppService.ObterTodos(), "AgenteAmbientalId", "Nome");
            ViewBag.MeioPropagacaoId = new SelectList(_meioPropagacaoAppService.ObterTodos(), "MeioPropagacaoId", "Nome");
            return PartialView("_AgentePPRA", agentePPRA);
        }

        public JsonResult CipaEmpresa(int id)
        {
            CIPAEmpresaViewModel cipaEmpresa = _cipaEmpresaAppService.ObterUltimaCipaPorEmpresa(id);
            return Json(cipaEmpresa, JsonRequestBehavior.AllowGet);
        }

        // GET: PPRAs
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var ppraViewModel = _PPRAAppService.ObterGrid(page, pesquisa);
            return View(ppraViewModel);
        }

        // GET: PPRAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ppraViewModel = _PPRAAppService.ObterPorId(id.Value);
            if (ppraViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ppraViewModel);
        }

        // GET: PPRAs/Create
        public ActionResult Create()
        {
            var usuario = _usuarioAppService.ObterTodos().FirstOrDefault(); 

            ViewBag.EquipamentoRuidoId     = new SelectList(_equipamentoRuidoAppService.ObterTodos(), "EquipamentoRuidoId", "Nome");

            ViewBag.ResponsavelTecnicoId   = new SelectList(_colaboradorAppService.ObterTodosPorEmpresa(usuario.EmpresaId), "ColaboradorId", "Nome");
            ViewBag.ResponsavelMedicoId    = new SelectList(_colaboradorAppService.ObterTodosPorEmpresa(usuario.EmpresaId), "ColaboradorId", "Nome");
            ViewBag.ResponsavelAmbientalId = new SelectList(_colaboradorAppService.ObterTodosPorEmpresa(usuario.EmpresaId), "ColaboradorId", "Nome");

            ViewBag.EmpresaClienteId       = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
            ViewBag.EmpresaLocalId         = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");

            //Agente PPRA
            ViewBag.AgenteAmbientalId = new SelectList(_agenteAmbientalAppService.ObterTodos(), "AgenteAmbientalId", "Nome");
            ViewBag.MeioPropagacaoId = new SelectList(_meioPropagacaoAppService.ObterTodos(), "MeioPropagacaoId", "Meio");

            var ppraViewModel = new PPRAViewModel();
            return View(ppraViewModel);
        }

        // POST: PPRAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PPRAViewModel ppraViewModel, List<AgentePPRAViewModel> agentePPRAViewModel, List<CronogramaDeAcoesViewModel> cronogramaDeAcoesViewModel)
        {
           // if (ModelState.IsValid)
  
            _PPRAAppService.Adicionar(ppraViewModel,agentePPRAViewModel, cronogramaDeAcoesViewModel);
            return RedirectToAction("Index");

            var usuario = _usuarioAppService.ObterTodos().FirstOrDefault();
            ViewBag.EquipamentoRuidoId = new SelectList(_equipamentoRuidoAppService.ObterTodos(), "EquipamentoRuidoId", "Nome");

            ViewBag.ResponsavelTecnicoId = new SelectList(_colaboradorAppService.ObterTodosPorEmpresa(usuario.EmpresaId), "ColaboradorId", "Nome");
            ViewBag.ResponsavelMedicoId = new SelectList(_colaboradorAppService.ObterTodosPorEmpresa(usuario.EmpresaId), "ColaboradorId", "Nome");
            ViewBag.ResponsavelAmbientalId = new SelectList(_colaboradorAppService.ObterTodosPorEmpresa(usuario.EmpresaId), "ColaboradorId", "Nome");

            ViewBag.EmpresaClienteId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
            ViewBag.EmpresaLocalId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");

            //Agente PPRA
            ViewBag.AgenteAmbientalId = new SelectList(_agenteAmbientalAppService.ObterTodos(), "AgenteAmbientalId", "Nome");
            ViewBag.MeioPropagacaoId = new SelectList(_meioPropagacaoAppService.ObterTodos(), "MeioPropagacaoId", "Nome");

            ppraViewModel.CronogramasDeAcao = cronogramaDeAcoesViewModel;
            ppraViewModel.AgentesPPRA = agentePPRAViewModel;

            return View(ppraViewModel);
        }

        // GET: PPRAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ppra = _PPRAAppService.ObterPorId(id.Value);
            if (ppra == null)
            {
                return HttpNotFound();
            }
            var usuario = (UsuarioViewModel)Session["Usuario"];

            ViewBag.EquipamentoRuidoId = new SelectList(_equipamentoRuidoAppService.ObterTodos(), "EquipamentoRuidoId", "Nome", ppra.EquipamentoRuidoId);

            ViewBag.ResponsavelTecnicoId = new SelectList(_colaboradorAppService.ObterTodosPorEmpresa(usuario.EmpresaId), "ColaboradorId", "Nome", ppra.ResponsavelTecnicoId);
            ViewBag.ResponsavelMedicoId = new SelectList(_colaboradorAppService.ObterTodosPorEmpresa(usuario.EmpresaId), "ColaboradorId", "Nome", ppra.ResponsavelMedicoId);
            ViewBag.ResponsavelAmbientalId = new SelectList(_colaboradorAppService.ObterTodosPorEmpresa(usuario.EmpresaId), "ColaboradorId", "Nome", ppra.ResponsavelAmbientalId);

            ViewBag.EmpresaClienteId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia", ppra.EmpresaClienteId);
            ViewBag.EmpresaLocalId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia", ppra.EmpresaLocalId);

            return View(ppra);
        }

        // POST: PPRAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PPRAViewModel ppraViewModel)
        {
            if (ModelState.IsValid)
            {
                _PPRAAppService.Atualizar(ppraViewModel);
                return RedirectToAction("Index");
            }
            var usuario = _usuarioAppService.ObterTodos().FirstOrDefault();
            ViewBag.EquipamentoRuidoId = new SelectList(_equipamentoRuidoAppService.ObterTodos(), "EquipamentoRuidoId", "Nome", ppraViewModel.EquipamentoRuidoId);

            ViewBag.ResponsavelTecnicoId = new SelectList(_colaboradorAppService.ObterTodosPorEmpresa(usuario.EmpresaId), "ColaboradorId", "Nome", ppraViewModel.ResponsavelTecnicoId);
            ViewBag.ResponsavelMedicoId = new SelectList(_colaboradorAppService.ObterTodosPorEmpresa(usuario.EmpresaId), "ColaboradorId", "Nome", ppraViewModel.ResponsavelMedicoId);
            ViewBag.ResponsavelAmbientalId = new SelectList(_colaboradorAppService.ObterTodosPorEmpresa(usuario.EmpresaId), "ColaboradorId", "Nome", ppraViewModel.ResponsavelAmbientalId);

            ViewBag.EmpresaClienteId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia", ppraViewModel.EmpresaClienteId);
            ViewBag.EmpresaLocalId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia", ppraViewModel.EmpresaLocalId);

            return View(ppraViewModel);
        }

        // GET: PPRAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ppra = _PPRAAppService.ObterPorId(id.Value);
            if (ppra == null)
            {
                return HttpNotFound();
            }

            return View(ppra);
        }

        // POST: PPRAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_PPRAAppService.Excluir(id))
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
                _PPRAAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Gerar(int? id)
        {
            return RedirectToAction("Index", "PPRARelatorioNew", new { ppraid = id });
        }
    }
}
