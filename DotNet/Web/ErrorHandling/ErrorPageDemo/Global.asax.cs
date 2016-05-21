using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace ErrorPageDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            if (Session["UserLanguage"] == null)
            {
                Session["UserLanguage"] = "ko-KR";
            }

            // 在 error page 中應該能夠取得這裡設定的 CurrentUICulture。
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["UserLanguage"].ToString());
        }
    }
}
