using Sismuni.Dominio.Entidad.Licencia.GestionDisponibilidadInspector;
using Sismuni.Presentacion.Web.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sismuni.Presentacion.Web.Models.Licencia.GestionDisponibilidadInspector
{
    public class DisponibilidadInspectorGridModelo : GridModelo<DisponibilidadInspectorVob>
    {
        public DisponibilidadInspectorGridModelo() : base(new List<DisponibilidadInspectorVob>()) { }
        public DisponibilidadInspectorGridModelo(IEnumerable<DisponibilidadInspectorVob> lista, int tamanioPagina, int totalPagina) : base(lista, tamanioPagina, totalPagina) { }

    }
}