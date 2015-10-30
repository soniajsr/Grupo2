using Sismuni.Dominio.Entidad.Transparencia.GestionSolicitud;
using Sismuni.Infraestructura.Data.Modelo;
using Sismuni.Infraestructura.Data.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.Transparencia.GestionSolicitud
{
    public class GNTSolicitudRepositorio : IGNTSolicitudRepositorio
    {
        public List<SolicitudVob> BuscarSolicitudes()
        {

            using (var context = new UPC_MUNIEntities())
            {

                var consulta = from sol in context.SolicitudInformacionMunicipal
                               select new SolicitudVob
                               {
                                   NumeroSolicitud = sol.NumeroSolicitud,
                                   Codigo_Solicitud = sol.NumeroSolicitud,
                                   FechaSolicitud = sol.FechaSolicitud,
                                   Nombres_Completos_Solicitante = sol.NombresSolicitante + " " + sol.ApellidoPaternoSolicitante + " " + sol.ApellidoMaternoSolicitante,
                                   Nombre_Tipo_Documento = sol.Multitabla.NombreValor,
                                   NumeroDocumento = sol.NumeroDocumento,
                                   Nombre_Estado = sol.Multitabla1.NombreValor
                               };

                return consulta.ToList();
            }


        }

        public SolicitudVob BuscarSolicitudporId(long id)
        {
            using (var context = new UPC_MUNIEntities())
            {

                var consulta = from sol in context.SolicitudInformacionMunicipal
                               where sol.NumeroSolicitud == id
                               select new SolicitudVob
                               {
                                   NumeroSolicitud = sol.NumeroSolicitud,
                                   FechaSolicitud = sol.FechaSolicitud,
                                   NombresSolicitante = sol.NombresSolicitante,
                                   ApellidoPaternoSolicitante = sol.ApellidoPaternoSolicitante,
                                   ApellidoMaternoSolicitante = sol.ApellidoMaternoSolicitante,
                                   TipoDocumento = sol.TipoDocumento,
                                   NumeroDocumento = sol.NumeroDocumento,
                                   Estado_Solicitud = sol.Estado,
                                   Direccion = sol.Direccion,
                                   Telefono = sol.Telefono,
                                   Celular = sol.Celular,
                                   Email = sol.Email,
                                   Modo_Envio = sol.Modo_Envio,
                                   Nombres_Responsable = sol.UsuarioTrabajador.Nombre + " " + sol.UsuarioTrabajador.ApePaterno + " " + sol.UsuarioTrabajador.ApeMaterno,
                                   Tipo_Informacion = sol.Tipo_Informacion ,
                                   Observaciones = sol.Observaciones
                               };

                return consulta.FirstOrDefault();
            }

        }

        public int Agregar(SolicitudVob solicitud)
        {
            SolicitudInformacionMunicipal sol = new SolicitudInformacionMunicipal();

            DateTime fecha = new DateTime();
            fecha = DateTime.Today;

            using (var context = new UPC_MUNIEntities())
            {
                sol.FechaSolicitud = DateTime.Now;
                sol.NombresSolicitante = solicitud.NombresSolicitante;
                sol.ApellidoPaternoSolicitante = solicitud.ApellidoPaternoSolicitante;
                sol.ApellidoMaternoSolicitante = solicitud.ApellidoMaternoSolicitante;
                sol.TipoDocumento = solicitud.TipoDocumento;
                sol.NumeroDocumento = solicitud.NumeroDocumento;
                sol.Direccion = solicitud.Direccion;
                sol.Telefono = solicitud.Telefono;
                sol.Celular = solicitud.Celular;
                sol.Email = solicitud.Email;
                sol.Modo_Envio = solicitud.Modo_Envio;
                sol.Tipo_Informacion = solicitud.Tipo_Informacion;
                sol.Observaciones = solicitud.Observaciones;
                //sol.Estado = EstadosValor.SolicitudPendiente;
                context.SolicitudInformacionMunicipal.Add(sol);
                context.SaveChanges();

                return Convert.ToInt32(sol.NumeroSolicitud);

            };

        }

        public int Modificar(SolicitudVob solicitud)
        {
            SolicitudInformacionMunicipal sol = new SolicitudInformacionMunicipal();

            DateTime fecha = new DateTime();
            fecha = DateTime.Today;

            using (var context = new UPC_MUNIEntities())
            {



                var solmodif = (from c in context.SolicitudInformacionMunicipal
                                where c.NumeroSolicitud == solicitud.NumeroSolicitud
                                select c).First();



                solmodif.NombresSolicitante = solicitud.NombresSolicitante;
                solmodif.ApellidoPaternoSolicitante = solicitud.ApellidoPaternoSolicitante;
                solmodif.ApellidoMaternoSolicitante = solicitud.ApellidoMaternoSolicitante;
                solmodif.TipoDocumento = solicitud.TipoDocumento;
                solmodif.NumeroDocumento = solicitud.NumeroDocumento;
                solmodif.Direccion = solicitud.Direccion;
                solmodif.Telefono = solicitud.Telefono;
                solmodif.Celular = solicitud.Celular;
                solmodif.Email = solicitud.Email;
                solmodif.Modo_Envio = solicitud.Modo_Envio;
                solmodif.Tipo_Informacion = solicitud.Tipo_Informacion;
                solmodif.Observaciones = solicitud.Observaciones;
                context.SaveChanges();

                return Convert.ToInt32(solicitud.NumeroSolicitud);

            };

        }
    }
}
