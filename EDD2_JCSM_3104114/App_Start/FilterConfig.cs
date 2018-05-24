using System.Web;
using System.Web.Mvc;

namespace EDD2_JCSM_3104114
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
