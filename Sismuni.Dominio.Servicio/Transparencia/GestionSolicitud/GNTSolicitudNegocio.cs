using Sismuni.Dominio.Entidad.Transparencia.GestionSolicitud;
using Sismuni.Dominio.Negocio.Enumeraciones;
using Sismuni.Dominio.Negocio.Recursos;
using Sismuni.Infraestructura.Data.Repositorios.General;
using Sismuni.Infraestructura.Data.Repositorios.Transparencia.GestionSolicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Negocio.Transparencia.GestionSolicitud
{
    public class GNTSolicitudNegocio : IGNTSolicitudNegocio
    {
        public RespuestaBusquedaSolicitudesVob BuscarSolicitudes(SolicitudBusquedaSolicitudesVob solicitud)
        {
            List<SolicitudVob> lista = new List<SolicitudVob>();
            var solicitudrepositorio = new GNTSolicitudRepositorio();

            lista = solicitudrepositorio.BuscarSolicitudes();

            
            if (solicitud.SolicitudFilter.Codigo_Solicitud != null)
            {
                if (solicitud.SolicitudFilter.Codigo_Solicitud > 0)
                {
                    lista = lista.Where(x => x.Codigo_Solicitud == solicitud.SolicitudFilter.Codigo_Solicitud).ToList();
                }
            }

  
            if (solicitud.SolicitudFilter.FechaInicio != null && solicitud.SolicitudFilter.FechaFin != null)
            {
                lista = lista.Where(x => x.FechaSolicitud >= solicitud.SolicitudFilter.FechaInicio && x.FechaSolicitud <= solicitud.SolicitudFilter.FechaFin).ToList();
            }

            lista = lista.OrderByDescending(x => x.FechaSolicitud).ToList();

            int total = lista.Count();

            return new RespuestaBusquedaSolicitudesVob
            {
                listasolicitudes = lista.ToList(),
                totalelementos = total
            };

        }

        public EditorSolicitudVob ObtenerEditor(int? id)
        {

            var solicitudrepositorio = new GNTSolicitudRepositorio();
            var generalrepositorio = new MultitablaRepositorio();


            SolicitudVob objsolicitud = new SolicitudVob();
            string valor = string.Empty;
            string texto = PrimerValorEnum.Seleccione.ToString();


            if (id == null) { id = 0; };

            var solicitud = solicitudrepositorio.BuscarSolicitudporId(Convert.ToInt32(id));

            var tipos_documento = generalrepositorio.ListarTablas(GrupoTabla.TipoDocumento);
            var modos_envio = generalrepositorio.ListarTablas(GrupoTabla.ModoEnvio);
            var tipos_informacion = generalrepositorio.ListarTablas(GrupoTabla.TipoInformacionMunicipal);


            tipos_documento.Add(new Entidad.General.ElementoVob { Valor = valor, Texto = texto });
            modos_envio.Add(new Entidad.General.ElementoVob { Valor = valor, Texto = texto });
            tipos_informacion.Add(new Entidad.General.ElementoVob { Valor = valor, Texto = texto });


            tipos_documento = tipos_documento.OrderBy(x => x.Valor).ToList();
            modos_envio = modos_envio.OrderBy(x => x.Valor).ToList();
            tipos_informacion = tipos_informacion.OrderBy(x => x.Valor).ToList();

            if (solicitud != null)
            {
                objsolicitud = solicitud;
            }

            return new EditorSolicitudVob
            {
                Solicitud = objsolicitud,
                Tipo_Documentos = tipos_documento,
                Tipo_Informaciones = tipos_informacion,
                Modo_Envios = modos_envio
            };


        }

        public int Agregar(RegistrarSolicitudVob registro)
        {
            var solicitudrepositorio = new GNTSolicitudRepositorio();

            int numsolicitud = solicitudrepositorio.Agregar(registro.Solicitud);

            return numsolicitud;

        }

        public int Modificar(RegistrarSolicitudVob registro)
        {
            var solicitudrepositorio = new GNTSolicitudRepositorio();

            int numsolicitud = solicitudrepositorio.Modificar(registro.Solicitud);

            return numsolicitud;

        }

    }
}
