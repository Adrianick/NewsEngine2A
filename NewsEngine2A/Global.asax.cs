﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace NewsEngine2A
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsEngine2A.Context.NewsEngineContext, NewsEngine2A.Context.Config.Configuration>());

        }
    }
}
