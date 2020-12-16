using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TravelGuide.Business.DependencyInjection.Autofac;

namespace TravelGuide.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            //RegisterController için iki yöntem de uygundur ancak direk assembly iþlemi reflection gerektirir.
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new AutofacBusinessModule());//Business tarafýnda yapýlan enjeksiyonlarý build etme

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
