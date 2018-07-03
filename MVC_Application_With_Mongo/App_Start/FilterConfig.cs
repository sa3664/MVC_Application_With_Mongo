using System.Web;
using System.Web.Mvc;

namespace MVC_Application_With_Mongo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
