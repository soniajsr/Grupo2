// MENSAJES Y ALERTAS
var helperjs = {

    // Parametros Globales
    urlBase: $('#urlBase').val(),
    urlSustento: $('#urlSustento').val(),
    urlCarga: $('#urlCarga').val(),
    urlCargaEsp: $('#urlCargaEsp').val(),

    confirmar: function (param) {//mensaje, funcOk, funcCancel) {
        bootbox.dialog({
            message: param.mensaje,
            title: param.titulo ? param.titulo : "Confirmar",
            icon: "sigen-mensaje-info16x16",
            onEscape: function () {
                if (param.funcCancel != undefined)
                    param.funcCancel();
            },
            buttons: {
                aceptar: {
                    label: "Aceptar",
                    className: "btn-primary",
                    callback: function () {
                        if (param.funcOk != undefined)
                            param.funcOk();
                        if (param.url != undefined) {
                            if (param.tipo == null || param.tipo == 'POST')
                                helperjs.setPostUrl(param.url, param.data);
                            else if (param.tipo == 'GET')
                                helperjs.setGetUrl(param.url);
                        }
                    }
                },
                cancelar: {
                    label: "Cancelar",
                    className: "btn-primary",
                    callback: function () {
                        if (param.funcCancel != undefined)
                            param.funcCancel();
                    }
                }
            }
        });
    },

    popupRol: function (param) {
        bootpopup.dialog({
            message: param.mensaje,
            closeButton: false,
            title: param.titulo,
            data: param.data,
            beforeShow: param.beforeShow,
            afterShow: param.afterShow,
            id: param.id,
            modalTop: param.modalTop,
            buttons: {
                aceptar: null,
                cerrarValidar: null
            }
        });
    },

    popup: function (param) {
        bootpopup.dialog({
            message: param.mensaje,
            title: param.titulo,
            data: param.data,
            beforeShow: param.beforeShow,
            afterShow: param.afterShow,
            id: param.id,
            modalTop: param.modalTop,
            buttons: {
                aceptar: param.btnAceptar == false ? null : {
                    label: "Guardar",
                    className: "btn-primary",
                    callback: function () {
                        if (param.funcOk != undefined)
                            return param.funcOk();
                    }
                },

                cerrarValidar: {
                    label: "Cancelar",
                    className: "btn-primary",
                    callback: function () {
                        if (param.funcCancel != undefined)
                            return param.funcCancel();
                    }
                }
            }
        });
    },

    popupinvitacion: function (param) {
        bootpopup.dialog({
            message: param.mensaje,
            closeButton: false,
            title: param.titulo,
            data: param.data,
            beforeShow: param.beforeShow,
            afterShow: param.afterShow,
            id: param.id,
            modalTop: param.modalTop,
            buttons: {
                aceptar: null,
                cerrarValidar: null
            }
        });
    },

    popupmanual: function (param) {
        bootpopup.dialog({
            message: param.mensaje,
            title: param.titulo,
            data: param.data,
            beforeShow: param.beforeShow,
            afterShow: param.afterShow,
            id: param.id,
            modalTop: param.modalTop,
            resizable: true,
            height: 'auto',
            width: '1000px'
        });
    },

    ajaxSend: function (request) {

        var forgeryToke = $("input[name='__RequestVerificationToken']").val();

        if (forgeryToke != undefined && forgeryToke != null) {
            if (request.data == undefined)
                request.data = {};
            request.data.__RequestVerificationToken = forgeryToke;
        }

        $.ajax({
            url: request.url,
            type: (request.type == null) ? "POST" : request.type,
            data: request.data,
            datatype: request.datatype,
            contentType: request.contentType,
            success: function (data, textStatus, jqXhr) {
                if (request.success != undefined)
                    request.success(data, textStatus, jqXhr);
                else {
                    //TO-DO mensaje//helper.procesarSuccessDefault(data, textStatus, jqXhr);
                }
            },
            error: function (jqXhr, textStatus, errorThrown) {
                if (request.error != undefined)
                    request.error(jqXhr, textStatus, errorThrown);
                else {
                    //TO-DO mensaje//helper.procesarErrorDefault(jqXhr, textStatus, jqXhr);
                }
            }
        });
    },

    procesarError: function (data, messageSuccess) {
        if (data == null) {
            return true;
        }
        if (data.Tipo == "Peligro") {
            helperjs.mostrarMensajes.danger(data.Mensaje);
            return false;
        } else if (data.Tipo == "Informativo") {
            helperjs.mostrarMensajes.info(data.Mensaje);
            return false;
        } else if (data.Tipo == "Advertencia") {
            helperjs.mostrarMensajes.warning(data.Mensaje);
            return false;
        } else if (data.Tipo == "Satisfactorio") {
            if (data.mensaje != undefined) {
                helperjs.mostrarMensajes.success(data.Mensaje);
            }
            return true;
        } else {
            if (messageSuccess != undefined) {
                helperjs.mostrarMensajes.success(messageSuccess);
            }
            return true;
        }
    },

    alertar: function (param) {
        bootbox.dialog({
            message: param.mensaje,
            title: param.titulo ? param.titulo : "Alerta",
            icon: "sigen-mensaje-advertencia16x16",
            buttons: {
                aceptar: {
                    label: "Aceptar",
                    className: "btn-primary",
                    callback: function () {
                        if (param.funcOk != undefined)
                            param.funcOk();
                        if (param.url != undefined) {
                            if (param.tipo == null || param.tipo == 'POST')
                                helperjs.setPostUrl(param.url);
                            else if (param.tipo == 'GET')
                                helperjs.seGetUrl(param.url);
                        }
                    }
                }
            }
        });
    },

    valorKey: function (url, key) {
        var key1 = "?" + key + "=";
        var key2 = "&" + key + "=";

        var pos1 = url.indexOf(key1);
        if (pos1 < 0) {
            pos1 = url.indexOf(key2);
            if (pos1 < 0)
                return "";
        }

        pos1 = pos1 + key.length + 2;

        var pos2 = url.indexOf("&", pos1);
        if (pos2 < 0) {
            pos2 = url.length;
            if (pos2 < 0)
                return "";
        }

        return url.substring(pos1, pos2);
    },

    fecha_conver: function (dateString) {
        var date = this.fecha(dateString);
        return date.getTime();
    },

    iniciarMensajes: function () {
        $("#alert-danger").css("display", "none");
        $("#alert-warning").css("display", "none");
        $("#alert-info").css("display", "none");
        $("#alert-success").css("display", "none");
        $("#close-danger").click(function () { $("#alert-danger").fadeOut(); });
        $("#close-warning").click(function () { $("#alert-warning").fadeOut(); });
        $("#close-info").click(function () { $("#alert-info").fadeOut(); });
        $("#close-success").click(function () { $("#alert-success").fadeOut(); });
    },

    mostrarMensajes: {
        danger: function (txt) { var mens = $("#alert-danger"); $("#al-danger").text(txt); mens.fadeIn(); },
        warning: function (txt) { var mens = $("#alert-warning"); $("#al-warning").text(txt); mens.fadeIn(); },
        info: function (txt) { var mens = $("#alert-info"); $("#al-info").text(txt); mens.fadeIn(); },
        success: function (txt) { var mens = $("#alert-success"); $("#al-success").text(txt); mens.fadeIn(); }
    },


    fecha: function (cadena) {
        //FORMATO RECONOCIDO dd/MM/yyyy hh:mm tt;
        var separador = "/";
        var dia = 0;
        var mes = 0;
        var anio = 0;
        var hra = 0;
        var mnt = 0;

        //Separa por dia, mes y año
        if (cadena.indexOf(separador) != -1) {
            var posi1 = 0;
            var posi2 = cadena.indexOf(separador, posi1 + 1);
            var posi3 = cadena.indexOf(separador, posi2 + 1);
            var posi4 = posi3 + 5;
            var posi5 = posi4 + 3;
            var posi6 = posi5 + 3;
            dia = cadena.substring(posi1, posi2);
            mes = cadena.substring(posi2 + 1, posi3);
            anio = cadena.substring(posi3 + 1, posi4);
            hra = cadena.substring(posi4 + 1, posi5);
            mnt = cadena.substring(posi5 + 1, posi6);
        } else {
            dia = 0;
            mes = 0;
            anio = 0;
            hra = 0;
            mnt = 0;
        }

        return new Date(anio, mes, dia, hra, mnt);
    },

    hora: function (cadena) {
        //FORMATO RECONOCIDO hh:mm;
        var separador = ":";
        var hra = 0;
        var mnt = 0;

        //Separa por dia, mes y año
        if (cadena.indexOf(separador) != -1) {
            var posi1 = 0;
            var posi2 = cadena.indexOf(separador, posi1 + 1);
            var posi3 = 5;

            hra = cadena.substring(posi1, posi2);
            mnt = cadena.substring(posi2 + 1, posi3);
        } else {
            hra = 0;
            mnt = 0;
        }

        return hra + mnt;
    },

    sizeToKMB: function (val) {
        if (val < 1024)
            return (val.toFixed(2) + "").replace(".00", "") + " B";
        else if (val < 1024 * 1024)
            return ((val / 1024).toFixed(2) + "").replace(".00", "") + " KB";
        else if (val < 1024 * 1024 * 1024)
            return ((val / (1024 * 1024)).toFixed(2) + "").replace(".00", "") + " MB";
        return "0 B";
    },

    //GET
    setGetUrl: function (url) {
        //window.location.href = url;
        helperjs.showWait();
        var a = document.createElement("a");
        if (a.click) {
            a.setAttribute("href", url);
            a.style.display = "none";
            document.body.appendChild(a);
            a.click();
        } else {
            window.location = url;
        }
    },

    //POST
    setPostUrl: function (url, params1, params2, params3) {

        var form = document.createElement("FORM");
        form.action = url;
        form.method = 'POST';

        //IMPORTANTE: No debe tener ningun tipo de serializacion
        var indexQM = url.indexOf("?");
        if (indexQM >= 0) {
            // the URL has parameters => convert them to hidden form inputs
            var params = url.substring(indexQM + 1).split("&");
            for (var i = 0; i < params.length; i++) {
                var keyValuePair = params[i].split("=");
                var input = document.createElement("INPUT");
                input.type = "hidden";
                input.name = keyValuePair[0];
                if (input.name != '__RequestVerificationToken') {
                    input.value = keyValuePair[1];
                    form.appendChild(input);
                }
            }
        }

        // En caso se envia el array de serializeArray
        if (params1 != undefined)
            for (var i = 0; i < params1.length; i++) {
                var keyValuePair = params1[i];
                var input = document.createElement("INPUT");
                input.type = "hidden";
                input.name = keyValuePair.name;
                if (input.name != '__RequestVerificationToken') {
                    input.value = keyValuePair.value;
                    form.appendChild(input);
                }
            }

        // En caso se envia el array de serializeArray
        if (params2 != undefined)
            for (var i = 0; i < params2.length; i++) {
                var keyValuePair = params2[i];
                var input = document.createElement("INPUT");
                input.type = "hidden";
                input.name = keyValuePair.name;
                if (input.name != '__RequestVerificationToken') {
                    input.value = keyValuePair.value;
                    form.appendChild(input);
                }
            }

        // En caso se envia el array de serializeArray
        if (params3 != undefined)
            for (var i = 0; i < params3.length; i++) {
                var keyValuePair = params3[i];
                var input = document.createElement("INPUT");
                input.type = "hidden";
                input.name = keyValuePair.name;
                input.value = keyValuePair.value;
                form.appendChild(input);
            }

        var forgeryToke = $("input[name='__RequestVerificationToken']").val();

        if (forgeryToke != undefined && forgeryToke != null) {
            var input = document.createElement("INPUT");
            input.type = "hidden";
            input.name = '__RequestVerificationToken';
            input.value = forgeryToke;

            //var tokens = document.getElementById("__RequestVerificationToken");
            //for (var i = 0; tokens.children.length; i++) {
            //    var child = tokens.children[i];
            //    tokens.removeChild(child);
            //}

            form.appendChild(input);
        }

        document.body.appendChild(form);
        helperjs.showWait();
        form.submit();
    },

    setPostUrlTarget: function (url, params1, params2, params3) {

        var form = document.createElement("FORM");
        form.action = url;
        form.target = "_blank";
        form.method = 'POST';

        //IMPORTANTE: No debe tener ningun tipo de serializacion
        var indexQM = url.indexOf("?");
        if (indexQM >= 0) {
            // the URL has parameters => convert them to hidden form inputs
            var params = url.substring(indexQM + 1).split("&");
            for (var i = 0; i < params.length; i++) {
                var keyValuePair = params[i].split("=");
                var input = document.createElement("INPUT");
                input.type = "hidden";
                input.name = keyValuePair[0];
                if (input.name != '__RequestVerificationToken') {
                    input.value = keyValuePair[1];
                    form.appendChild(input);
                }
            }
        }

        // En caso se envia el array de serializeArray
        if (params1 != undefined)
            for (var i = 0; i < params1.length; i++) {
                var keyValuePair = params1[i];
                var input = document.createElement("INPUT");
                input.type = "hidden";
                input.name = keyValuePair.name;
                if (input.name != '__RequestVerificationToken') {
                    input.value = keyValuePair.value;
                    form.appendChild(input);
                }
            }

        // En caso se envia el array de serializeArray
        if (params2 != undefined)
            for (var i = 0; i < params2.length; i++) {
                var keyValuePair = params2[i];
                var input = document.createElement("INPUT");
                input.type = "hidden";
                input.name = keyValuePair.name;
                if (input.name != '__RequestVerificationToken') {
                    input.value = keyValuePair.value;
                    form.appendChild(input);
                }
            }

        // En caso se envia el array de serializeArray
        if (params3 != undefined)
            for (var i = 0; i < params3.length; i++) {
                var keyValuePair = params3[i];
                var input = document.createElement("INPUT");
                input.type = "hidden";
                input.name = keyValuePair.name;
                input.value = keyValuePair.value;
                form.appendChild(input);
            }

        var forgeryToke = $("input[name='__RequestVerificationToken']").val();

        if (forgeryToke != undefined && forgeryToke != null) {
            var input = document.createElement("INPUT");
            input.type = "hidden";
            input.name = '__RequestVerificationToken';
            input.value = forgeryToke;

            //var tokens = document.getElementById("__RequestVerificationToken");
            //for (var i = 0; tokens.children.length; i++) {
            //    var child = tokens.children[i];
            //    tokens.removeChild(child);
            //}

            form.appendChild(input);
        }

        document.body.appendChild(form);
        helperjs.showWait();
        form.submit();

        helperjs.hideWait();
    },

    altoDisponible: function (borde) {
        if (borde == undefined) borde = 20;
        return $(window).height() - borde;
    },

    esIE: function () {
        return $("html").hasClass("ie");
        //return navigator.userAgent.indexOf("MSIE") > 0;
    },

    hideWait: function () {
        $('#wait').hide();
        $('#waitImg').hide();
    },

    showWait: function () {
        $('#wait').show();
        $('#waitImg').show();
    }

};