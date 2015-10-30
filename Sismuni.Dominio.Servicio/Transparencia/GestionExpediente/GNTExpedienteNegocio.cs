using Sismuni.Dominio.Entidad.Transparencia;
using Sismuni.Dominio.Entidad.Transparencia.GestionExpediente;
using Sismuni.Dominio.Negocio.Enumeraciones;
using Sismuni.Dominio.Negocio.Recursos;
using Sismuni.Infraestructura.Data.Repositorios.General;
using Sismuni.Infraestructura.Data.Repositorios.Transparencia.GestionExpediente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sismuni.Transversal.Mapeo.Mapeo;
using Sismuni.Infraestructura.Data.Modelo;
using Sismuni.Infraestructura.Data.Recursos;
using Sismini.Transversal.Mapeo.Recursos;

namespace Sismuni.Dominio.Negocio.Transparencia
{
    public class GNTExpedienteNegocio : IGNTExpedienteNegocio
    {
        private readonly IGNTExpedienteRepositorio _expedienteRepositorio;
        private readonly IMultitablaRepositorio _multitablaRepositorio;

        public GNTExpedienteNegocio(IGNTExpedienteRepositorio expedienteRepositorio,
                                    IMultitablaRepositorio multitablaRepositorio)
        {
            if (expedienteRepositorio == (IGNTExpedienteRepositorio)null) throw new ArgumentNullException("expedienteRepositorio");
            if (multitablaRepositorio == (IMultitablaRepositorio)null) throw new ArgumentNullException("multitablaRepositorio");


            _expedienteRepositorio = expedienteRepositorio;
            _multitablaRepositorio = multitablaRepositorio;
        }



        public EditorExpedienteVob ObtenerEditor(int? id)
        {

            //var expedienterepositorio = new GNTExpedienteRepositorio();
            //var generalrepositorio = new MultitablaRepositorio();


            ExpedienteVob objexpediente = new ExpedienteVob();
            string valor = string.Empty;
            string texto = PrimerValorEnum.Seleccione.ToString();


            if (id == null) { id = 0; };

            var expediente = _expedienteRepositorio.BuscarExpedienteporId(Convert.ToInt32(id));

            var tipos_expediente = _multitablaRepositorio.ListarTablas("0002");

            tipos_expediente.Add(new Entidad.General.ElementoVob { Valor = valor, Texto = texto });

            tipos_expediente = tipos_expediente.OrderBy(x=> x.Valor).ToList();

            if (expediente != null)
            {
                objexpediente = expediente;
            }

            return new EditorExpedienteVob
            {
                Expediente = objexpediente,
                Tipo_Expedientes = tipos_expediente
            };


        }

        public int Agregar(RegistrarExpedienteVob registro)
        {
            //var expedienterepositorio = new GNTExpedienteRepositorio();

            var unidadDeTrabajo = _expedienteRepositorio.UnidadDeTrabajo;


            var expediente = registro.Expediente.ProyectarComo<Expediente>();

            expediente.Estado = Convert.ToInt32(EstadosValor.EspedienteActivo);
            expediente.FechaExpediente = DateTime.Now;


            _expedienteRepositorio.Agregar(expediente);

            unidadDeTrabajo.Confirmar();


            return Convert.ToInt32(expediente.NumeroExpediente);

        }

        public int Modificar(RegistrarExpedienteVob registro)
        {
            //var expedienterepositorio = new GNTExpedienteRepositorio();

            int numexpediente = _expedienteRepositorio.ModificarExpediente(registro.Expediente);

            return numexpediente;

        }

        public RespuestaBusquedaExpedientesVob BuscarExpedientes(SolicitudBusquedaExpedientesVob solicitud)
        {
            List<ExpedienteVob> lista = new List<ExpedienteVob>();
           // var expedienterepositorio = new GNTExpedienteRepositorio();

            lista = _expedienteRepositorio.BuscarExpedientes();

            lista = lista.Where(x => x.Estado == 1).ToList();

            if (solicitud.ExpedienteFilter.Codigo_Expediente != null)
            {
                if (solicitud.ExpedienteFilter.Codigo_Expediente > 0)
                {
                    lista = lista.Where(x => x.Codigo_Expediente == solicitud.ExpedienteFilter.Codigo_Expediente).ToList();
                }
            }

            if (solicitud.ExpedienteFilter.NumeroSolicitud != null)
            {
                if (solicitud.ExpedienteFilter.NumeroSolicitud > 0)
                {
                    lista = lista.Where(x => x.NumeroSolicitud == solicitud.ExpedienteFilter.NumeroSolicitud).ToList();
                }
            }

            if (solicitud.ExpedienteFilter.FECHAINICIO != null && solicitud.ExpedienteFilter.FECHAFIN != null)
            {
                lista = lista.Where(x => x.FechaExpediente >= solicitud.ExpedienteFilter.FECHAINICIO && x.FechaExpediente <= solicitud.ExpedienteFilter.FECHAFIN).ToList();
            }

            int total = lista.Count();

            return new RespuestaBusquedaExpedientesVob{
                    listaexpedientes = lista.OrderByDescending(x => x.FechaExpediente).ToList(),
                    totalelementos = total 
              };

        }
    }
}
