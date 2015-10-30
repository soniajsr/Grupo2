using Microsoft.Practices.Unity;
using Sismuni.Dominio.Negocio.Licencia.GestionSolicitudLicencia;
using Sismuni.Dominio.Negocio.Transparencia;
using Sismuni.Infraestructura.Data.Repositorios.General;
using Sismuni.Infraestructura.Data.Repositorios.Licencia.GestionDisponibilidadInspector;
using Sismuni.Infraestructura.Data.Repositorios.Licencia.GestionInspeccion;
using Sismuni.Infraestructura.Data.Repositorios.Licencia.GestionSolicitudLicencia;
using Sismuni.Infraestructura.Data.Repositorios.Transparencia.GestionExpediente;
using Sismuni.Infraestructura.Data.UnidadDeTrabajo;
using Sismuni.Transversal.Mapeo.Mapeo;

namespace Sismuni.Transversal.Injeccion
{
    public sealed class ContenedorInyeccion
    {
        public static void ObtenerRegistros(IUnityContainer container)
        {
            RegistroBase(container);

            RegistroRepositorios(container);

            RegistroServicios(container);

        }

        private static void RegistroBase(IUnityContainer container)
        {
            //BASE
            container.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());//Singleton
            container.RegisterType<IModeloUnidadDeTrabajo, ModeloUnidadDeTrabajo>(new CicloVidaPorPeticion(), new InjectionConstructor());
        }

        private static void RegistroRepositorios(IUnityContainer container)
        {
            container.RegisterType<IGNTExpedienteRepositorio, GNTExpedienteRepositorio>(new TransientLifetimeManager());
            container.RegisterType<IMultitablaRepositorio, MultitablaRepositorio>(new TransientLifetimeManager());
            container.RegisterType<ILISolicitudLicenciaRepositorio, LISolicitudLicenciaRepositorio>(new TransientLifetimeManager());
            container.RegisterType<ILIDisponibilidadInspectorRepositorio, LIDisponibilidadInspectorRepositorio>(new TransientLifetimeManager());
            container.RegisterType<ILIInspeccionRepositorio, LIInspeccionRepositorio>(new TransientLifetimeManager());
            

        }

        private static void RegistroServicios(IUnityContainer container)
        {
            container.RegisterType<IGNTExpedienteNegocio, GNTExpedienteNegocio>(new TransientLifetimeManager());
            container.RegisterType<ILISolicitudLicenciaNegocio, LISolicitudLicenciaNegocio>(new TransientLifetimeManager());
            
        }
    }
}
