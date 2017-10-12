using System.Net;
using System.Web.Mvc;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;

namespace BI.GST.UI.MVC.Controllers
{
    public class ColaboradoresController : Controller
    {
        private readonly IColaboradorAppService _colaboradorAppService;
        private readonly IEmpresaAppService _empresaAppService;

        public ColaboradoresController(IColaboradorAppService colaboradorAppService, IEmpresaAppService empresaAppService)
        {
            _colaboradorAppService = colaboradorAppService;
            _empresaAppService     = empresaAppService;
        }

        // GET: Colaboradores
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var colaboradorViewModel = _colaboradorAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "colaboradores";
            ViewBag.TotalRegistros = _colaboradorAppService.ObterTotalRegistros(pesquisa);

            return View(colaboradorViewModel);
        }

        // GET: Colaboradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var colaboradorViewModel = _colaboradorAppService.ObterPorId(id.Value);
            if (colaboradorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(colaboradorViewModel);
        }

        // GET: Colaboradores/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
            var colaboradorViewModel = new ColaboradorViewModel();

            return View(colaboradorViewModel);
        }

        // POST: Colaboradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ColaboradorViewModel colaboradorViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_colaboradorAppService.Adicionar(colaboradorViewModel))
                {
                    ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
                    //var cipaEmpresa = new CIPAEmpresaViewModel();
                    TempData["Mensagem"] = "Atenção, Colaborador já cadastrado";
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipoCurso com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }

            return View(colaboradorViewModel);
        }

        // GET: Colaboradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var colaboradorViewModel = _colaboradorAppService.ObterPorId(id.Value);
            if (colaboradorViewModel == null)
            {
                return HttpNotFound();
            }

            return View(colaboradorViewModel);
        }

        // POST: Colaboradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ColaboradorViewModel colaboradorViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_colaboradorAppService.Atualizar(colaboradorViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, Colaborador já cadastrado')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(colaboradorViewModel);
        }

        // GET: Colaboradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var colaboradorViewModel = _colaboradorAppService.ObterPorId(id.Value);
            if (colaboradorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(colaboradorViewModel);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_colaboradorAppService.Excluir(id))
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
                _colaboradorAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
