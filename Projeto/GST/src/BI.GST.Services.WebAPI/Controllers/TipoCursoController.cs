using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BI.GST.Services.WebAPI.Controllers
{
  public class TipoCursoController : ApiController
  {
    private readonly ITipoCursoAppService _tipoCursoAppService;

    public TipoCursoController(ITipoCursoAppService tipoCursoAppService)
    {
      _tipoCursoAppService = tipoCursoAppService;
    }

    // GET: api/TipoCurso
    public IEnumerable<TipoCursoViewModel> Get()
    {
      return _tipoCursoAppService.ObterTodos();
    }

    // GET: api/TipoCurso/5
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/TipoCurso
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/TipoCurso/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/TipoCurso/5
    public void Delete(int id)
    {
    }
  }
}
