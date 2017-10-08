using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using System.Collections.Generic;

namespace BI.GST.UI.MVC.Controllers
{
    public class AgenteRiscoCBOsController : Controller
    {
        private readonly IAgenteRiscoCBOAppService _agenteRiscoCBOAppService;

        public AgenteRiscoCBOsController(IAgenteRiscoCBOAppService agenteRiscoCBOAppService)
        {
            _agenteRiscoCBOAppService = agenteRiscoCBOAppService;
        }

        public ActionResult Index(string pesquisa, int page = 0)
        {
            var agenteRiscoViewModel = _agenteRiscoCBOAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "agenteRiscoCBOs";
            ViewBag.TotalRegistros = _agenteRiscoCBOAppService.ObterTotalRegistros(pesquisa);

            #region DDL Status
            List<SelectListItem> ddlStatus_Risco = new List<SelectListItem>();
            ddlStatus_Risco.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Risco.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_Riscos"] = ddlStatus_Risco;

            foreach (var item in agenteRiscoViewModel)
            {
                item.StatusNome = ddlStatus_Risco.Where(e => e.Value.Trim().Equals(item.Status.ToString())).First().Text;
            }
            #endregion

            return View(agenteRiscoViewModel);
        }

        // GET: AgenteRiscoCBOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteRiscoCBO = _agenteRiscoCBOAppService.ObterPorId(id.Value);
            if (agenteRiscoCBO == null)
            {
                return HttpNotFound();
            }

            var ddlStatus_Riscos = (List<SelectListItem>)TempData["ddlStatus_Riscos"];
            agenteRiscoCBO.StatusNome = ddlStatus_Riscos.Where(e => e.Value.Trim().Equals(agenteRiscoCBO.Status.ToString())).First().Text;

            return View(agenteRiscoCBO);
        }

        // GET: AgenteRiscoCBOs/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: AgenteRiscoCBOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgenteRiscoCBOViewModel agenteRiscoCBOViewModel)
        {

            if (ModelState.IsValid)
            {
                if (!_agenteRiscoCBOAppService.Adicionar(agenteRiscoCBOViewModel))
                {
                    //TempData["Mensagem"] = "Atenção, há um Tipo Curso com os mesmos dados";
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Risco com o mesmo nome!')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            List<SelectListItem> ddlStatus_Risco = new List<SelectListItem>();
            ddlStatus_Risco.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Risco.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_Riscos"] = ddlStatus_Risco;

            agenteRiscoCBOViewModel.StatusNome = ddlStatus_Risco.Where(e => e.Value.Trim().Equals(agenteRiscoCBOViewModel.Status.ToString())).First().Text;


            return View(agenteRiscoCBOViewModel);

        }

        // GET: AgenteRiscoCBOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteRiscoCBO = _agenteRiscoCBOAppService.ObterPorId(id.Value);
            if (agenteRiscoCBO == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> ddlStatus_Risco = new List<SelectListItem>();
            ddlStatus_Risco.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Risco.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_Riscos"] = ddlStatus_Risco;

            var ddlStatus_Riscos = (List<SelectListItem>)TempData["ddlStatus_Riscos"];
            agenteRiscoCBO.StatusNome = ddlStatus_Riscos.Where(e => e.Value.Trim().Equals(agenteRiscoCBO.Status.ToString())).First().Text;

            return View(agenteRiscoCBO);
        }

        // POST: AgenteRiscoCBOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AgenteRiscoCBOViewModel agenteRiscoCBOViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_agenteRiscoCBOAppService.Atualizar(agenteRiscoCBOViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Risco com o mesmo nome!')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(agenteRiscoCBOViewModel);
        }

        // GET: AgenteRiscoCBOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteRiscoCBO = _agenteRiscoCBOAppService.ObterPorId(id.Value);
            if (agenteRiscoCBO == null)
            {
                return HttpNotFound();
            }

            var ddlStatus_Riscos = (List<SelectListItem>)TempData["ddlStatus_Riscos"];
            agenteRiscoCBO.StatusNome = ddlStatus_Riscos.Where(e => e.Value.Trim().Equals(agenteRiscoCBO.Status.ToString())).First().Text;
            return View(agenteRiscoCBO);
        }

        // POST: AgenteRiscoCBOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_agenteRiscoCBOAppService.Excluir(id))
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
                _agenteRiscoCBOAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
