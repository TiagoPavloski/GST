using System.Net;
using System.Web.Mvc;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;

namespace BI.GST.UI.MVC.Controllers
{
    public class EscalasController : Controller
    {
        private readonly IEscalaAppService _escalaAppService;

        public EscalasController(IEscalaAppService escalaAppService)
        {
            _escalaAppService = escalaAppService;
        }

        // GET: Escalas
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var escalaViewModel = _escalaAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "Escalas";
            ViewBag.TotalRegistros = _escalaAppService.ObterTotalRegistros(pesquisa);
            return View(escalaViewModel);
        }

        // GET: Escalas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var escala = _escalaAppService.ObterPorId(id.Value);
            if (escala == null)
            {
                return HttpNotFound();
            }
            return View(escala);
        }

        // GET: Escalas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Escalas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EscalaViewModel escalaViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _escalaAppService.Adicionar(escalaViewModel);

                if (result != "")
                {
                    TempData["Mensagem"] = result;
                }

                else
                    return RedirectToAction("Index");
            }
            return View(escalaViewModel);
        }

        // GET: Escalas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var escala = _escalaAppService.ObterPorId(id.Value);
            if (escala == null)
            {
                return HttpNotFound();
            }
            return View(escala);
        }

        // POST: Escalas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EscalaViewModel escalaViewModel)
        {

            if (ModelState.IsValid)
            {
                var result = _escalaAppService.Atualizar(escalaViewModel);

                if (result != "")
                {
                    TempData["Mensagem"] = result;
                }
                else
                    return RedirectToAction("Index");
            }
            return View(escalaViewModel);
        }

        // GET: Escalas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var escala = _escalaAppService.ObterPorId(id.Value);
            if (escala == null)
            {
                return HttpNotFound();
            }
            return View(escala);
        }

        // POST: Escalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var result = _escalaAppService.Excluir(id);

            if (result != "")
            {
                TempData["Mensagem"] = result;
                return RedirectToAction("Index");
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
                _escalaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
