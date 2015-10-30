var solicitudjs = {
    formSolicitud: "#SolicitudForm",

    iniciar: function () {

        var idSolicitud = $("#Solicitud_NumeroSolicitud").val();
        var accionForm = $(this.formSolicitud).attr("action");

        if (idSolicitud == null || idSolicitud == 0) {
            $(sitiojs.titulo).text("Nueva Solicitud");
            $(this.formSolicitud).attr("action", accionForm.replace("Registrar", "Agregar"));
        }
        else {
            $(sitiojs.titulo).text("Modificación Solicitud");
            $(this.formSolicitud).attr("action", accionForm.replace("Registrar", "Modificar"));
        }

        // Preparando validaciones
        solicitudjs.validaciones();
        solicitudjs.validarmensajes();

        helpervalidacionesjs.soloNumeros("#Solicitud_Telefono", "keypress");
        helpervalidacionesjs.soloNumeros("#Solicitud_Celular", "keypress");
        helpervalidacionesjs.soloemail("#Solicitud_Email", "keypress");
        helpervalidacionesjs.soloNumeros("#Solicitud_NumeroDocumento", "keypress");
        helpervalidacionesjs.soloLetras("#Solicitud_NombresSolicitante", "keypress");
        helpervalidacionesjs.soloLetras("#Solicitud_ApellidoPaternoSolicitante", "keypress");
        helpervalidacionesjs.soloLetras("#Solicitud_ApellidoMaternoSolicitante", "keypress");


        // expedientejs.validaragregar();
    },

    validarmensajes: function () {
        $("#btn-Grabar").on("click", function () {

            var modo = $("#Solicitud_Modo_Envio").val();
            var email = $("#Solicitud_Email").val();
            var direccion = $("#Solicitud_Direccion").val();
            var tipodoc = $("#Solicitud_TipoDocumento").val();
            var nrodoc = $("#Solicitud_NumeroDocumento").val();

            if (modo == "0004001" && email == "") {
                var request = {
                    titulo: "Validacion Solicitud!",
                    mensaje: "Debe Ingresar el Email"
                };
                helperjs.alertar(request);
                return false;
            }

            if (modo == "0004002" && direccion == "") {
                var request = {
                    titulo: "Validacion Solicitud!",
                    mensaje: "Debe Ingresar la Dirección"
                };
                helperjs.alertar(request);
                return false;
            }

            if (tipodoc == "0001001" && nrodoc.length != 8) {
                var request = {
                    titulo: "Validacion Solicitud!",
                    mensaje: "El Dni debe ser de 8 dígitos"
                };
                helperjs.alertar(request);
                return false;
            }

            if (tipodoc == "0001002" && nrodoc.length != 11) {
                var request = {
                    titulo: "Validacion Solicitud!",
                    mensaje: "El Ruc debe ser de 11 dígitos"
                };
                helperjs.alertar(request);
                return false;
            }

            if (tipodoc == "0001003" && nrodoc.length != 15) {
                var request = {
                    titulo: "Validacion Solicitud!",
                    mensaje: "El Carnet de Extranjería debe ser de 15 dígitos"
                };
                helperjs.alertar(request);
                return false;
            }

            helperjs.setPostUrl(url);
            return false;

       });


    },
   
    validaciones: function () {
        $(this.formSolicitud).validacionSigen({

            rules: {
                'Solicitud.Tipo_Informacion': {
                    required: true
                    //  maxlength: 4000,
                },
                'Solicitud.TipoDocumento': {
                    required: true
                },
                'Solicitud.NumeroDocumento': {
                    required: true
                },

                'Solicitud.NombresSolicitante': {
                    required: true
                },

                'Solicitud.ApellidoPaternoSolicitante': {
                    required: true
                },

                'Solicitud.Modo_Envio': {
                    required: true
                },

                'Solicitud.Observaciones': {
                    required: true
                },
            },
            messages: {
                'Solicitud.Tipo_Informacion': {
                    required: 'Seleccione el Tipo de Informacion'
                    // maxlength: 'Solo puede ingresar 4000 caracteres'
                },
                'Solicitud.TipoDocumento': {
                    required: 'Seleccione el Tipo de Documento'

                },

                'Solicitud.NumeroDocumento': {
                    required: 'Ingrese el Numero de Documento'

                },

                'Solicitud.NombresSolicitante': {
                    required: 'Ingrese los Nombres del Solicitante'

                },

                'Solicitud.ApellidoPaternoSolicitante': {
                    required: 'Ingrese el Apellido Paterno del Solicitante'

                },

                'Solicitud.Modo_Envio': {
                    required: 'Seleccione el Modo de Envio'

                },

                'Solicitud.Observaciones': {
                    required: 'Ingrese las Observaciones'

                },


            }
        });


    }


};