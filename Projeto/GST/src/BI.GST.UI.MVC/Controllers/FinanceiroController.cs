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

namespace BI.GST.UI.MVC.Controllers
{
    public class FinanceiroController : Controller
    {
        private ProjetoContext db = new ProjetoContext();

        // GET: Financeiro
        public ActionResult Index()
        {
            return View(db.Financeiros.ToList());
        }

        // GET: Financeiro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financeiro financeiro = db.Financeiros.Find(id);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // GET: Financeiro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Financeiro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FinanceiroId,Titulo,Operacao,Descricao,DataOperacao,NumeroParcelas,DataVencimento,DataQuitacao,Valor,Instituicao,Status,Delete")] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                db.Financeiros.Add(financeiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(financeiro);
        }

        // GET: Financeiro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financeiro financeiro = db.Financeiros.Find(id);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // POST: Financeiro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FinanceiroId,Titulo,Operacao,Descricao,DataOperacao,NumeroParcelas,DataVencimento,DataQuitacao,Valor,Instituicao,Status,Delete")] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(financeiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(financeiro);
        }

        // GET: Financeiro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financeiro financeiro = db.Financeiros.Find(id);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // POST: Financeiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Financeiro financeiro = db.Financeiros.Find(id);
            db.Financeiros.Remove(financeiro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
