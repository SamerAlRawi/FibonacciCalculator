using System.Web;
using System.Web.Mvc;

namespace Fibonacci.Singlepage
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}