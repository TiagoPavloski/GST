﻿using System;
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
  public class TipoExamesController : Controller
  {
    private readonly ITipoExameAppService _tipoExameAppService;

    public TipoExamesController(ITipoExameAppService tipoExameAppService)
    {
      _tipoExameAppService = tipoExameAppService;
    }
    // GET: TipoExames
    public ActionResult Index(string pesquisa, int page = 0)
    {
      var tipoExameViewModel = _tipoExameAppService.ObterGrid(page, pesquisa);
      ViewBag.PaginaAtual = page;
      ViewBag.Pesquisa = pesquisa;
      ViewBag.Controller = "TipoExames";
      ViewBag.TotalRegistros = _tipoExameAppService.ObterTotalRegistros(pesquisa);
      return View(tipoExameViewModel);
    }

    // GET: TipoExames/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var tipoExame = _tipoExameAppService.ObterPorId(id.Value);
      if (tipoExame == null)
      {
        return HttpNotFound();
      }
      return View(tipoExame);
    }

    // GET: TipoExames/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: TipoExames/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(TipoExameViewModel tipoExameViewModel)
    {
      if (ModelState.IsValid)
      {
        if (!_tipoExameAppService.Adicionar(tipoExameViewModel))
        {
          System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipoExame com os mesmos dados')</SCRIPT>");
        }
        else
          return RedirectToAction("Index");
      }
      return View(tipoExameViewModel);
    }

    // GET: TipoExames/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var tipoExame = _tipoExameAppService.ObterPorId(id.Value);
      if (tipoExame == null)
      {
        return HttpNotFound();
      }
      return View(tipoExame);
    }

    // POST: TipoExames/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(TipoExameViewModel tipoExameViewModel)
    {
      if (ModelState.IsValid)
      {
        if (!_tipoExameAppService.Atualizar(tipoExameViewModel))
        {
          System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipo de Exame com os mesmos dados já cadastrada')</SCRIPT>");
        }
        else
          return RedirectToAction("Index");
      }
      return View(tipoExameViewModel);
    }

    // GET: TipoExames/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var tipoExame = _tipoExameAppService.ObterPorId(id.Value);
      if (tipoExame == null)
      {
        return HttpNotFound();
      }
      return View(tipoExame);
    }

    // POST: TipoExames/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      if (!_tipoExameAppService.Excluir(id))
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
        _tipoExameAppService.Dispose();
      }
      base.Dispose(disposing);
    }

  }
}
