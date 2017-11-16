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
    public class MedicaoAgentesController : Controller
    {
        private readonly IMedicaoAgenteAppService _medicaoAgenteAppService;

        public MedicaoAgentesController(IMedicaoAgenteAppService medicaoAgenteAppService)
        {
            _medicaoAgenteAppService = medicaoAgenteAppService;
        }

        // GET: medicaoAgentes
        public ActionResult Index(string pesquisa, int page = 0)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            var medicaoAgenteViewModel = _medicaoAgenteAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "medicaoAgentes";
            ViewBag.TotalRegistros = _medicaoAgenteAppService.ObterTotalRegistros(pesquisa);
            return View(medicaoAgenteViewModel);
        }

        // GET: medicaoAgentes/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicaoAgenteViewModel medicaoAgente = _medicaoAgenteAppService.ObterPorId(id.Value);
            if (medicaoAgente == null)
            {
                return HttpNotFound();
            }
            return View(medicaoAgente);
        }

        // GET: medicaoAgentes/Create
        public ActionResult Create()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            return View();
        }

        // POST: medicaoAgentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicaoAgenteViewModel medicaoAgenteViewModel)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (ModelState.IsValid)
            {
                if (!_medicaoAgenteAppService.Adicionar(medicaoAgenteViewModel))
                {
                    //TempData["Mensagem"] = "Atenção, há um Tipo Curso com os mesmos dados";
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um medicaoAgente com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(medicaoAgenteViewModel);
        }

        // GET: medicaoAgentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var medicaoAgente = _medicaoAgenteAppService.ObterPorId(id.Value);
            if (medicaoAgente == null)
            {
                return HttpNotFound();
            }
            return View(medicaoAgente);
        }

        // POST: medicaoAgentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicaoAgenteViewModel medicaoAgenteViewModel)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (ModelState.IsValid)
            {
                if (!_medicaoAgenteAppService.Atualizar(medicaoAgenteViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agenteErgonômico com os mesmos dados já cadastrada')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(medicaoAgenteViewModel);
        }

        // GET: medicaoAgentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicaoAgenteViewModel medicaoAgente = _medicaoAgenteAppService.ObterPorId(id.Value);
            if (medicaoAgente == null)
            {
                return HttpNotFound();
            }
            return View(medicaoAgente);
        }

        // POST: medicaoAgentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (!_medicaoAgenteAppService.Excluir(id))
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
                _medicaoAgenteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
