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
  public class TipoVacinasController : Controller
  {
    private readonly ITipoVacinaAppService _tipoVacinaAppService;

    public TipoVacinasController(ITipoVacinaAppService tipoVacinaAppService)
    {
      _tipoVacinaAppService = tipoVacinaAppService;
    }
    // GET: TipoVacinas
    public ActionResult Index(string pesquisa, int page = 0)
    {
      var tipoVacinaViewModel = _tipoVacinaAppService.ObterGrid(page, pesquisa);
      ViewBag.PaginaAtual = page;
      ViewBag.Pesquisa = pesquisa;
      ViewBag.Controller = "TipoVacinas";
      ViewBag.TotalRegistros = _tipoVacinaAppService.ObterTotalRegistros(pesquisa);
      return View(tipoVacinaViewModel);
    }

    // GET: TipoVacinas/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var tipoVacina = _tipoVacinaAppService.ObterPorId(id.Value);
      if (tipoVacina == null)
      {
        return HttpNotFound();
      }
      return View(tipoVacina);
    }

    // GET: TipoVacinas/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: TipoVacinas/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(TipoVacinaViewModel tipoVacinaViewModel)
    {
      if (ModelState.IsValid)
      {
        if (!_tipoVacinaAppService.Adicionar(tipoVacinaViewModel))
        {
          System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipo Vacina com os mesmos dados')</SCRIPT>");
        }
        else
          return RedirectToAction("Index");
      }
      return View(tipoVacinaViewModel);
    }

    // GET: TipoVacinas/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var tipoVacina = _tipoVacinaAppService.ObterPorId(id.Value);
      if (tipoVacina == null)
      {
        return HttpNotFound();
      }
      return View(tipoVacina);
    }

    // POST: TipoVacinas/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(TipoVacinaViewModel tipoVacinaViewModel)
    {
      if (ModelState.IsValid)
      {
        if (!_tipoVacinaAppService.Atualizar(tipoVacinaViewModel))
        {
          System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipo de Vacina com os mesmos dados já cadastrada')</SCRIPT>");
        }
        else
          return RedirectToAction("Index");
      }
      return View(tipoVacinaViewModel);
    }

    // GET: TipoVacinas/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var tipoVacina = _tipoVacinaAppService.ObterPorId(id.Value);
      if (tipoVacina == null)
      {
        return HttpNotFound();
      }
      return View(tipoVacina);
    }

    // POST: TipoVacinas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      if (!_tipoVacinaAppService.Excluir(id))
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
        _tipoVacinaAppService.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
