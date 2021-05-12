using Autofac;
using Autofac.Integration.Mvc;
using CatastroAvanza.Mapeadores;
using CatastroAvanza.Negocio.Contratos;
using CatastroAvanza.Negocio.Implementaciones;
using CatastroAvanza.Repositorio.DBContexto;
using CatastroAvanza.Repositorio.DBContexto.Interface;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CatastroAvanza
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            SetAutofacContainer();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            // Register controllers all at once using assembly
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            //Contextos
            builder.RegisterType<ApplicationDbContext>()
                .As<IApplicationDbContext>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            //Logica negocio
            builder.RegisterType<DataForm1Logic>()
                .As<IDataForm1Logic>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            //Mappers
            builder.RegisterType<MapeadoresApplicacion>()
                .As<IMapeadoresApplicacion>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            
        }
    }
}
