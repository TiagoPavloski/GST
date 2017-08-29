using BI.GST.Infra.CrossCutting.MVCFilters;
using System.Web;
using System.Web.Mvc;

namespace BI.GST.UI.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PAPErrorHandler());
        }
    }
}
