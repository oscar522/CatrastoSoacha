using Autofac;
using Autofac.Integration.Mvc;
using CatastroAvanza.Infraestructura.ContratosServicios;
using CatastroAvanza.Infraestructura.ImplementacionesServicios;
using CatastroAvanza.Mapeadores;
using CatastroAvanza.Mapeadores.Interfaces;
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

            builder.RegisterType<Catalogo>()
                .As<ICatalogo>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<ActividadLogic>()
                .As<IActividadLogic>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<ActividadDiariaLogic>()
                .As<IActividadDiariaLogic>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<SecurityLogic>()
                .As<ISecurityLogic>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<TrabajoLogic>()
                .As<ITrabajoLogic>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<ArchivoLogic>()
                .As<IArchivoLogic>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            //Mappers
            builder.RegisterType<MapeadoresApplicacion>()
                .As<IMapeadoresApplicacion>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<ActividadMapper>()
                .As<IActividadMapper>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<UserMapper>()
                .As<IUserMapper>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<TrabajoMapper>()
                .As<ITrabajoMapper>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<ArchivoMapper>()
                .As<IArchivoMapper>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            //Servicios
            builder.RegisterType<AlmacenamientoArchivos>()
                .As<IAlmacenamientoArchivos>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            
        }
    }
}
