using OrientationApi;
using OrientationAPI.App_Start;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;

namespace OrientationAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
