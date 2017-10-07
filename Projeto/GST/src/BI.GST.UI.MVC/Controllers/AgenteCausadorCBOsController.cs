using BI.GST.Application.Interface;
using System.Web.Mvc;
using System.Net;
using BI.GST.Application.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BI.GST.UI.MVC.Controllers
{
    public class AgenteCausadorCBOsController : Controller
    {
        private readonly IAgenteCausadorCBOAppService _agenteCausadorCBOAppService;

        public AgenteCausadorCBOsController(IAgenteCausadorCBOAppService agenteCausadorCBOAppService)
        {
            _agenteCausadorCBOAppService = agenteCausadorCBOAppService;
        }

        // GET: agenteCausadorCBO
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var agenteCausadorViewModel = _agenteCausadorCBOAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "agenteCausadorCBOs";
            ViewBag.TotalRegistros = _agenteCausadorCBOAppService.ObterTotalRegistros(pesquisa);
            

            #region DDL Status
            List<SelectListItem> ddlStatus_Causador = new List<SelectListItem>();
            ddlStatus_Causador.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Causador.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_Causador"] = ddlStatus_Causador;

            foreach (var item in agenteCausadorViewModel)
            {
                item.StatusNome = ddlStatus_Causador.Where(e => e.Value.Trim().Equals(item.Status.ToString())).First().Text;
            }
            #endregion

            return View(agenteCausadorViewModel);
        }


        // GET: AgenteCausadorCBOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteCausadorCBO = _agenteCausadorCBOAppService.ObterPorId(id.Value);
            if (agenteCausadorCBO == null)
            {
                return HttpNotFound();
            }

            var ddlStatus_Riscos = (List<SelectListItem>)TempData["ddlStatus_Causador"];
            agenteCausadorCBO.StatusNome = ddlStatus_Riscos.Where(e => e.Value.Trim().Equals(agenteCausadorCBO.Status.ToString())).First().Text;

            return View(agenteCausadorCBO);
        }

        // GET: AgenteCausadorCBOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgenteCausadorCBOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgenteCausadorCBOViewModel agenteCausadorCBOViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_agenteCausadorCBOAppService.Adicionar(agenteCausadorCBOViewModel))
                {
                    //TempData["Mensagem"] = "Atenção, há um Tipo Curso com os mesmos dados";
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Agente Causador com o mesmo nome!')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }

            List<SelectListItem> ddlStatus_Risco = new List<SelectListItem>();
            ddlStatus_Risco.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Risco.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_Causador"] = ddlStatus_Risco;

            agenteCausadorCBOViewModel.StatusNome = ddlStatus_Risco.Where(e => e.Value.Trim().Equals(agenteCausadorCBOViewModel.Status.ToString())).First().Text;

            return View(agenteCausadorCBOViewModel);
        }

        // GET: AgenteCausadorCBOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agente = _agenteCausadorCBOAppService.ObterPorId(id.Value);
            if (agente == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> ddlStatus_Risco = new List<SelectListItem>();
            ddlStatus_Risco.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Risco.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_Causador"] = ddlStatus_Risco;

            var ddlStatus_Riscos = (List<SelectListItem>)TempData["ddlStatus_Causador"];
            agente.StatusNome = ddlStatus_Riscos.Where(e => e.Value.Trim().Equals(agente.Status.ToString())).First().Text;

            return View(agente);
        }

        // POST: AgenteCausadorCBOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AgenteCausadorCBOViewModel agenteCausadorCBOViewModel)
        {

            if (ModelState.IsValid)
            {
                if (!_agenteCausadorCBOAppService.Atualizar(agenteCausadorCBOViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Agente Causador com o mesmo nome!')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(agenteCausadorCBOViewModel);
        }

        // GET: AgenteCausadorCBOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agente = _agenteCausadorCBOAppService.ObterPorId(id.Value);
            if (agente == null)
            {
                return HttpNotFound();
            }

            var ddlStatus_Riscos = (List<SelectListItem>)TempData["ddlStatus_Causador"];
            agente.StatusNome = ddlStatus_Riscos.Where(e => e.Value.Trim().Equals(agente.Status.ToString())).First().Text;
            return View(agente);

        }

        // POST: AgenteCausadorCBOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_agenteCausadorCBOAppService.Excluir(id))
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
                _agenteCausadorCBOAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
