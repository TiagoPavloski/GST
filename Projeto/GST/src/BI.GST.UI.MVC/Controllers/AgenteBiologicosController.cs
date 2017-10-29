using System.Net;
using System.Web.Mvc;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;

namespace BI.GST.UI.MVC.Controllers
{
    public class AgenteBiologicosController : Controller
    {
        private readonly IAgenteBiologicoAppService _agenteBiologicoAppService;
        private readonly IClassificacaoEfeitoAppService _classificacaoEfeitoAppService;

        public AgenteBiologicosController(IAgenteBiologicoAppService agenteBiologicoAppService, IClassificacaoEfeitoAppService clasificacaoEfeitoAppService)
        {
            _agenteBiologicoAppService = agenteBiologicoAppService;
            _classificacaoEfeitoAppService = clasificacaoEfeitoAppService;
        }

        // GET: agenteBiologicos
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var agenteBiologicoViewModel = _agenteBiologicoAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "agenteBiologicos";
            ViewBag.TotalRegistros = _agenteBiologicoAppService.ObterTotalRegistros(pesquisa);
            return View(agenteBiologicoViewModel);
        }

        // GET: agenteBiologicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteBiologicoViewModel agenteBiologico = _agenteBiologicoAppService.ObterPorId(id.Value);
            if (agenteBiologico == null)
            {
                return HttpNotFound();
            }
            return View(agenteBiologico);
        }

        // GET: agenteBiologicos/Create
        public ActionResult Create()
        {
            ViewBag.ClassificacaoEfeitoId = new SelectList(_classificacaoEfeitoAppService.ObterTodos(), "ClassificacaoEfeitoId", "Classificacao");
            var agenteBiologicoViewModel = new AgenteBiologicoViewModel();
            return View(agenteBiologicoViewModel);
        }

        // POST: agenteBiologicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgenteBiologicoViewModel agenteBiologicoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_agenteBiologicoAppService.Adicionar(agenteBiologicoViewModel))
                {
                    ViewBag.ClassificacaoEfeitoId = new SelectList(_classificacaoEfeitoAppService.ObterTodos(), "ClassificacaoEfeitoId", "Classificacao");
                    TempData["Mensagem"] = "Atenção, há um Agente Biológico com os mesmos dados";
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agenteBiologico com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(agenteBiologicoViewModel);
        }

        // GET: agenteBiologicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteBiologicoViewModel = _agenteBiologicoAppService.ObterPorId(id.Value);
            if (agenteBiologicoViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassificacaoEfeitoId = new SelectList(_classificacaoEfeitoAppService.ObterTodos(), "ClassificacaoEfeitoId", "Classificacao", agenteBiologicoViewModel.ClassificacaoEfeitoId);
            return View(agenteBiologicoViewModel);
        }

        // POST: agenteBiologicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AgenteBiologicoViewModel agenteBiologicoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_agenteBiologicoAppService.Atualizar(agenteBiologicoViewModel))
                {
                    TempData["Mensagem"] = "Atenção, há um Agente Biológico com os mesmos dados já cadastrado";
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agenteErgonômico com os mesmos dados já cadastrada')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            ViewBag.ClassificacaoEfeitoId = new SelectList(_classificacaoEfeitoAppService.ObterTodos(), "ClassificacaoEfeitoId", "Classificacao", agenteBiologicoViewModel.ClassificacaoEfeitoId);
            return View(agenteBiologicoViewModel);
        }

        // GET: agenteBiologicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteBiologicoViewModel agenteBiologico = _agenteBiologicoAppService.ObterPorId(id.Value);
            if (agenteBiologico == null)
            {
                return HttpNotFound();
            }
            return View(agenteBiologico);
        }

        // POST: agenteBiologicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_agenteBiologicoAppService.Excluir(id))
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
                _agenteBiologicoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
