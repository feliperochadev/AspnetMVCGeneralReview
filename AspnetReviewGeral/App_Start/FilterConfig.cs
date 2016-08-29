using System.Web.Mvc;

namespace AspnetReviewGeral
{
    public class FilterConfig
    {
        public static void RegisterGlobalFiters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}