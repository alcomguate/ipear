using System.Web;
using System.Web.Mvc;

namespace REGISTROCEL_IPEAR
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
