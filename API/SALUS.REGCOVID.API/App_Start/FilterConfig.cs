using System.Web;
using System.Web.Mvc;

namespace SALUS.REGCOVID.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
