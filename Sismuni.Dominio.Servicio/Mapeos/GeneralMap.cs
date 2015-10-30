using AutoMapper;
using Sismuni.Dominio.Entidad.Licencia.GestionDisponibilidadInspector;
using Sismuni.Dominio.Entidad.Licencia.GestionInspeccion;
using Sismuni.Dominio.Entidad.Licencia.GestionSolicitudInspeccion;
using Sismuni.Dominio.Entidad.Transparencia;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sismuni.Dominio.Negocio.Mapeos
{
    public class GeneralMap : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ExpedienteVob, Expediente>();
            Mapper.CreateMap<Expediente, ExpedienteVob>();

            Mapper.CreateMap<SolicitudLicenciaVob, LI_solicitudlicencia>();
            Mapper.CreateMap<LI_solicitudlicencia, SolicitudLicenciaVob>();

            Mapper.CreateMap<SolicitudDisponibilidadInspectorVob, LI_disponibilidadinspector>();
            Mapper.CreateMap<LI_disponibilidadinspector, SolicitudDisponibilidadInspectorVob>();

            Mapper.CreateMap<InspeccionVob, LI_inspeccion>();
            Mapper.CreateMap<LI_inspeccion, InspeccionVob>();

        }
    }
}
