var solicitudinspeccionjs = {

    formSolicitudInspeccion: "#formSolicitudLicencia",

    iniciar: function () {

    },

    buscadorKey: function (idsolicitud) {

        var urlasignacion = "GestionDisponibilidadInspectorBandeja/Buscar";
        
        var request = {
            url: urlasignacion,
            data: {
                id: idsolicitud
            }
        };

        
        solicitudinspeccionjs.BuscarDisponibilidad(request);
    },

    asignar: function(url) {
        var request = {
            titulo: "Asignar Solicitud de Asignación",
            mensaje: "¿Está seguro que desea realizar la asignación?",
            url: url
        };
        helperjs.confirmar(request);
    },

    BuscarDisponibilidad: function (args) {
        alert(args.url);
        var request = {
            url: helperjs.urlBase + args.url,
            width: 870,
            height: 50,
            data: args.data,
            success: function (data, textStatus, jqXhr) {
                var param = {
                    data: data,
                    modalTop: true,
                    btnAceptar: false,
                    id: "modal-Busqueda-disponibilidad",
                    afterShow: function () {

                    }
                };
                helperjs.popup(param);
            }
        };
        helperjs.ajaxSend(request);

        return false;

    },


}