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
    public class EquipamentoRuidosController : Controller
    {
        private readonly IEquipamentoRuidoAppService _equipamentoRuidoAppService;

        public EquipamentoRuidosController(IEquipamentoRuidoAppService equipamentoRuidoAppService)
        {
            _equipamentoRuidoAppService = equipamentoRuidoAppService;
        }
        // GET: EquipamentoRuidos
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var equipamentoRuidoViewModel = _equipamentoRuidoAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "EquipamentoRuidos";
            ViewBag.TotalRegistros = _equipamentoRuidoAppService.ObterTotalRegistros(pesquisa);

            return View(equipamentoRuidoViewModel);
        }

        // GET: EquipamentoRuidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var equipamentoRuidoViewModel = _equipamentoRuidoAppService.ObterPorId(id.Value);
            if (equipamentoRuidoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(equipamentoRuidoViewModel);
        }

        // GET: EquipamentoRuidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipamentoRuidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EquipamentoRuidoViewModel equipamentoRuidoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_equipamentoRuidoAppService.Adicionar(equipamentoRuidoViewModel))
                {
                    TempData["Mensagem"] = "Atenção, há um Equipamento com os mesmos dados";
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipoCurso com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(equipamentoRuidoViewModel);
        }

        // GET: EquipamentoRuidos/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var equipamentoRuidoViewModel = _equipamentoRuidoAppService.ObterPorId(id.Value);
            if (equipamentoRuidoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(equipamentoRuidoViewModel);
        }

        // POST: EquipamentoRuidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EquipamentoRuidoViewModel equipamentoRuidoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_equipamentoRuidoAppService.Atualizar(equipamentoRuidoViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Equipamento com os mesmos dados já cadastrado')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(equipamentoRuidoViewModel);
        }

        // GET: EquipamentoRuidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var equipamentoRuidoViewModel = _equipamentoRuidoAppService.ObterPorId(id.Value);
            if (equipamentoRuidoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(equipamentoRuidoViewModel);
        }

        // POST: EquipamentoRuidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_equipamentoRuidoAppService.Excluir(id))
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
                _equipamentoRuidoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
