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

namespace BI.GST.UI.MVC.Controllers
{
    public class EmpresaUtilizadorasController : Controller
    {
		private readonly IEmpresaUtilizadoraAppService _empresaUtilizadoraAppService;
		private readonly IEnderecoAppService _enderecoViewModelAppService;
		private readonly ITelefoneAppService _funcionarioAppService;
		private readonly IUFAppService _uFAppService;

		public EmpresaUtilizadorasController(IEmpresaUtilizadoraAppService empresaUtilizadoraAppService)
		{
				
		}

		// GET: EmpresaUtilizadoras
		public ActionResult Index()
        {
            var empresasUtilizadora = db.EmpresasUtilizadora.Include(e => e.Endereco);
            return View(empresasUtilizadora.ToList());
        }

        // GET: EmpresaUtilizadoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaUtilizadora empresaUtilizadora = db.EmpresasUtilizadora.Find(id);
            if (empresaUtilizadora == null)
            {
                return HttpNotFound();
            }
            return View(empresaUtilizadora);
        }

        // GET: EmpresaUtilizadoras/Create
        public ActionResult Create()
        {
            ViewBag.EnderecoId = new SelectList(db.Enderecos, "EnderecoId", "Logradouro");
            return View();
        }

        // POST: EmpresaUtilizadoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpresaUtilizadoraId,NomeFantasia,RazaoSocial,CNPJ,EnderecoId,Email,Senha,Delete")] EmpresaUtilizadora empresaUtilizadora)
        {
            if (ModelState.IsValid)
            {
                db.EmpresasUtilizadora.Add(empresaUtilizadora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnderecoId = new SelectList(db.Enderecos, "EnderecoId", "Logradouro", empresaUtilizadora.EnderecoId);
            return View(empresaUtilizadora);
        }

        // GET: EmpresaUtilizadoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaUtilizadora empresaUtilizadora = db.EmpresasUtilizadora.Find(id);
            if (empresaUtilizadora == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnderecoId = new SelectList(db.Enderecos, "EnderecoId", "Logradouro", empresaUtilizadora.EnderecoId);
            return View(empresaUtilizadora);
        }

        // POST: EmpresaUtilizadoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpresaUtilizadoraId,NomeFantasia,RazaoSocial,CNPJ,EnderecoId,Email,Senha,Delete")] EmpresaUtilizadora empresaUtilizadora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresaUtilizadora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnderecoId = new SelectList(db.Enderecos, "EnderecoId", "Logradouro", empresaUtilizadora.EnderecoId);
            return View(empresaUtilizadora);
        }

        // GET: EmpresaUtilizadoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaUtilizadora empresaUtilizadora = db.EmpresasUtilizadora.Find(id);
            if (empresaUtilizadora == null)
            {
                return HttpNotFound();
            }
            return View(empresaUtilizadora);
        }

        // POST: EmpresaUtilizadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpresaUtilizadora empresaUtilizadora = db.EmpresasUtilizadora.Find(id);
            db.EmpresasUtilizadora.Remove(empresaUtilizadora);
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
