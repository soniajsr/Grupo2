var expedientejs = {
    formExpediente: "#ExpedienteForm",

    iniciar: function () {

        var idExpediente = $("#Expediente_NumeroExpediente").val();
        var accionForm = $(this.formExpediente).attr("action");

        if (idExpediente == null || idExpediente == 0) {
            $(sitiojs.titulo).text("Nuevo Expediente");
            $(this.formExpediente).attr("action", accionForm.replace("Registrar", "Agregar"));
        }
        else {
            $(sitiojs.titulo).text("Modificación Expediente");
            $(this.formExpediente).attr("action", accionForm.replace("Registrar", "Modificar"));
        }

        // Preparando validaciones
        expedientejs.validaciones();
        //expedientejs.validarmensajes();
       // expedientejs.validaragregar();
    },

    validarmensajes: function() {

        $("#btn-Grabar").on("click", function () {

            var observaciones = $("#Expediente_Observaciones").val();
            var especificaciones = $("#Especificaciones_Tecnicas").val();

            if (observaciones == "") {
                var request = {
                    titulo: "Validacion Expediente!",
                    mensaje: "Debe Ingresar las Observaciones"
                };
                helperjs.alertar(request);
                return false;
            }

            if (especificaciones == "") {
                var request = {
                    titulo: "Validacion Expediente!",
                    mensaje: "Debe Ingresar las Especificaciones Técnicas"
                };
                helperjs.alertar(request);
                return false;
            }

            helperjs.setPostUrl(url);
            return false;
        });



    },

    validaragregar: function () {

        $("#btn-Agregar-Archivo").on("click", function () {
            var nombre_archivo = $("#Expediente_NOMBREARCHIVO").val();
            var ruta_archivo = $("#fileSubirArchivo").val();

            if (nombre_archivo == "") {
                var request = {
                    titulo: "Validacion Expediente!",
                    mensaje: "Debe Ingresar el nombre del archivo a Agregar"
                };
                helperjs.alertar(request);
                return false;
            }

            if (ruta_archivo == "") {
                var request = {
                    titulo: "Validacion Expediente!",
                    mensaje: "Debe Seleccionar la Ruta del Archivo para Agregar"
                };
                helperjs.alertar(request);
                return false;
            }

            helperjs.setPostUrl(url);
            return false;

        });
        
    },

    validaciones: function () {
        $(this.formExpediente).validacionSigen({

            rules: {
                'Expediente.Asunto': {
                    required: true
                    //  maxlength: 4000,
                },
                'Expediente.Tipo_Expediente': {
                    required: true
                },
                
                
            },
            messages: {
                'Expediente.Asunto': {
                    required: 'Ingrese el Asunto'
                    // maxlength: 'Solo puede ingresar 4000 caracteres'
                },
                'Expediente.Tipo_Expediente': {
                    required: 'Seleccione el Tipo de Expediente'

                },
                
                
            }
        });


    }


};