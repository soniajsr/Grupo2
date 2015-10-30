/******************************************************************************/
/*                        FUNCIONES PARA VALIDAR CAJAS                        */
/******************************************************************************/

var helpervalidacionesjs = {

    // PERMITE SOLO NUMEROS, ADEMAS DESHABILITA PEGAR EN LA CAJA.
    soloNumeros: function (obj, evt) {
        $(obj).bind(evt, function (e) {
            return (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) ? false : true;
        })

        $(obj).on("paste", function (e) {
            e.preventDefault();
        });
    },

    // PERMITE SOLO NUMEROS, ADEMAS HABILITA PEGAR EN LA CAJA.
    soloNumerosyPegar: function (obj, evt) {
        $(obj).bind(evt, function (e) {
            return (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) ? false : true;
        })
        //    
        //    $(obj).on("paste",function(e){
        //        e.preventDefault();
        //    });
    },

    // PERMITE SOLO LETRAS Y ESPACIOS, ADEMAS DESHABILITA PEGAR EN LA CAJA.
    soloTexyNumSinespacios: function (obj, evt) {
        $(obj).on(evt, function (event) {
            var regExp = /[A-Za-zÃÃ‰ÃÃ“ÃšÃ‘Ã¡Ã©Ã­Ã³ÃºÃ±0123456789_@.]/g;
            var key = String.fromCharCode(event.which);
            if (event.keyCode == 8 || event.keyCode == 37 || event.keyCode == 39 || regExp.test(key)) {
                return true;
            }
            return false;
        });

        $(obj).on("paste", function (e) {
            e.preventDefault();
        });
    },

    // PERMITE SOLO LETRAS Y ESPACIOS, ADEMAS DESHABILITA PEGAR EN LA CAJA.
    soloLetras: function (obj, evt) {
        $(obj).on(evt, function (event) {
            var regExp = /[A-Za-zÃÃ‰ÃÃ“ÃšÃ‘Ã¡Ã©Ã­Ã³ÃºÃ± ]/g;
            var key = String.fromCharCode(event.which);
            if (event.keyCode == 9 || event.keyCode == 8 || event.keyCode == 37 || event.keyCode == 39 || regExp.test(key)) {
                return true;
            }
            return false;
        });

        $(obj).on("paste", function (e) {
            e.preventDefault();
        });
    },

    // PERMITE SOLO LETRAS Y ESPACIOS, HABILITA PEGAR EN LA CAJA.
    soloLetrasyPegar: function (obj, evt) {
        $(obj).on(evt, function (event) {
            var regExp = /[A-Za-zÃÃ‰ÃÃ“ÃšÃ‘Ã¡Ã©Ã­Ã³ÃºÃ± ]/g;
            var key = String.fromCharCode(event.which);
            if (event.keyCode == 8 || event.keyCode == 37 || event.keyCode == 39 || regExp.test(key)) {
                return true;
            }
            return false;
        });
        //
        //    $(obj).on("paste",function(e){
        //        e.preventDefault();
        //    });
    },

    // QUITA UN EVENTO PREVIAMENTE 'BINDEADO'
    unbindAttr: function (obj, evt) {
        $(obj).unbind(evt);
    },

    letrasYnumeros: function (obj, evt) {
        $(obj).bind(evt, function (e) {
            tecla = (document.all) ? e.keyCode : e.which;
            if (e.keyCode == 8) return true;
            if (e.keyCode == 9) return true;
            if (e.keyCode == 35) return true;
            if (e.keyCode == 36) return true;
            if (e.keyCode == 37) return true;
            if (e.keyCode == 38) return true;
            if (e.keyCode == 39) return true;
            if (e.keyCode == 40) return true;
            if (e.keyCode == 46) return true;
            if (e.keyCode == 1) return true;
            patron = /[A-Za-zÃ‘Ã±0-9]/;
            te = String.fromCharCode(tecla);
            return patron.test(te);
        })
    },

    letrasnumerosguion: function (obj, evt) {
        $(obj).bind(evt, function (e) {
            tecla = (document.all) ? e.keyCode : e.which;
            if (e.keyCode == 8) return true;
            if (e.keyCode == 9) return true;
            if (e.keyCode == 35) return true;
            if (e.keyCode == 36) return true;
            if (e.keyCode == 37) return true;
            if (e.keyCode == 38) return true;
            if (e.keyCode == 39) return true;
            if (e.keyCode == 40) return true;
            if (e.keyCode == 46) return true;
            if (e.keyCode == 1) return true;
            patron = /[A-Za-zÃ‘Ã±0-9-_]/;
            te = String.fromCharCode(tecla);
            return patron.test(te);
        })
    },

    letras: function (obj, evt) {
        $(obj).bind(evt, function (e) {
            tecla = (document.all) ? e.keyCode : e.which;
            if (e.keyCode == 8) return true;
            if (e.keyCode == 9) return true;
            if (e.keyCode == 35) return true;
            if (e.keyCode == 36) return true;
            if (e.keyCode == 37) return true;
            if (e.keyCode == 38) return true;
            if (e.keyCode == 39) return true;
            if (e.keyCode == 40) return true;
            if (e.keyCode == 46) return true;
            if (e.keyCode == 1) return true;
            patron = /[A-Za-zÃÃ‰ÃÃ“ÃšÃ‘Ã¡Ã©Ã­Ã³ÃºÃ±()\s_]/;
            te = String.fromCharCode(tecla);
            return patron.test(te);
        })
    },

    formato_doc: function (obj, evt) {
        $(obj).bind(evt, function (e) {
            tecla = (document.all) ? e.keyCode : e.which;
            if (e.keyCode == 8) return true;
            if (e.keyCode == 9) return true;
            if (e.keyCode == 35) return true;
            if (e.keyCode == 36) return true;
            if (e.keyCode == 37) return true;
            if (e.keyCode == 38) return true;
            if (e.keyCode == 39) return true;
            if (e.keyCode == 40) return true;
            if (e.keyCode == 46) return true;
            if (e.keyCode == 1) return true;
            patron = /[0123456789\s-]/;
            te = String.fromCharCode(tecla);
            return patron.test(te);
        })
    },

    solodouble: function (obj, evt) {
        $(obj).bind(evt, function (e) {
            tecla = (document.all) ? e.keyCode : e.which;
            if (e.keyCode == 8) return true;
            if (e.keyCode == 9) return true;
            if (e.keyCode == 35) return true;
            if (e.keyCode == 36) return true;
            if (e.keyCode == 37) return true;
            if (e.keyCode == 38) return true;
            if (e.keyCode == 39) return true;
            if (e.keyCode == 40) return true;
            if (e.keyCode == 46) return true;
            if (e.keyCode == 1) return true;
            patron = /[123456789.1234567890]/;
            te = String.fromCharCode(tecla);
            return patron.test(te);
        })
    },

    solodireccion: function (e) { // 1
        key = e.keyCode || e.which;
        tecla = String.fromCharCode(key).toLowerCase();
        letras = " ï¿½ï¿½ï¿½ï¿½ï¿½-abcdefghijklmnï¿½opqrstuvwxyz _ï¿½#;,.:ABCDEFGHIJKLMNï¿½OPQRSTUVWXYZ0123456789";
        especiales = [1, 8, 9, 36, 37, 39, 46];

        tecla_especial = false
        for (var i in especiales) {
            if (key == especiales[i]) {
                tecla_especial = true;
                break;
            }
        }

        if (letras.indexOf(tecla) == -1 && !tecla_especial)
            return false;
    },

    soloemail: function (e) { // 1
        key = e.keyCode || e.which;
        tecla = String.fromCharCode(key).toLowerCase();
        letras = "-abcdefghijklmnï¿½opqrstuvwxyz_@ï¿½.ABCDEFGHIJKLMNï¿½OPQRSTUVWXYZ0123456789";
        especiales = [1, 8, 9, 36, 37, 39, 46];

        tecla_especial = false
        for (var i in especiales) {
            if (key == especiales[i]) {
                tecla_especial = true;
                break;
            }
        }

        if (letras.indexOf(tecla) == -1 && !tecla_especial)
            return false;
    },

    solousuario: function (e) { // 1
        key = e.keyCode || e.which;
        tecla = String.fromCharCode(key).toLowerCase();
        letras = "-abcdefghijklmnï¿½opqrstuvwxyz_@ï¿½.ABCDEFGHIJKLMNï¿½OPQRSTUVWXYZ0123456789";
        especiales = [1, 8, 9, 36, 37, 39, 46];

        tecla_especial = false
        for (var i in especiales) {
            if (key == especiales[i]) {
                tecla_especial = true;
                break;
            }
        }

        if (letras.indexOf(tecla) == -1 && !tecla_especial)
            return false;

    },

    ClaveUsuario: function (e) {
        tecla = (document.all) ? e.keyCode : e.which;
        if (e.keyCode == 8) return true;
        if (e.keyCode == 9) return true;
        if (e.keyCode == 35) return true;
        if (e.keyCode == 36) return true;
        if (e.keyCode == 37) return true;
        if (e.keyCode == 38) return true;
        if (e.keyCode == 39) return true;
        if (e.keyCode == 40) return true;
        if (e.keyCode == 46) return true;
        if (e.keyCode == 1) return true;
        patron = /[A-Za-zÃÃ‰ÃÃ“ÃšÃ‘Ã¡Ã©Ã­Ã³ÃºÃ±()-123456789.@_]/;
        te = String.fromCharCode(tecla);
        return patron.test(te);
    },

    locaciones: function (e) { // 1
        key = e.keyCode || e.which;
        tecla = String.fromCharCode(key).toLowerCase();
        letras = "-1234567890.";
        especiales = [1, 8, 9, 36, 37, 39, 46];

        tecla_especial = false
        for (var i in especiales) {
            if (key == especiales[i]) {
                tecla_especial = true;
                break;
            }
        }

        if (letras.indexOf(tecla) == -1 && !tecla_especial)
            return false;
    },

    titulos: function (e) {
        key = e.keyCode || e.which;
        tecla = String.fromCharCode(key).toLowerCase();
        letras = " ï¿½ï¿½ï¿½ï¿½ï¿½abcdefghijklmnï¿½opqrstuvwxyzABCDEFGHIJKLMNï¿½OPQRSTUVWXYZ1234567890.#";
        especiales = [1, 8, 9, 36, 37, 39, 46];

        tecla_especial = false
        for (var i in especiales) {
            if (key == especiales[i]) {
                tecla_especial = true;
                break;
            }
        }

        if (letras.indexOf(tecla) == -1 && !tecla_especial)
            return false;
    },


    dinero: function (e) {
        key = e.keyCode || e.which;
        tecla = String.fromCharCode(key).toLowerCase();
        letras = "1234567890.";
        especiales = [1, 8, 9, 36, 37, 39, 46];

        tecla_especial = false
        for (var i in especiales) {
            if (key == especiales[i]) {
                tecla_especial = true;
                break;
            }
        }

        if (letras.indexOf(tecla) == -1 && !tecla_especial)
            return false;
    },

    documentos: function (e) {
        key = e.keyCode || e.which;
        tecla = String.fromCharCode(key).toLowerCase();
        letras = " abcdefghijklmnï¿½opqrstuvwxyzABCDEFGHIJKLMNï¿½OPQRSTUVWXYZ1234567890.-/";
        especiales = [1, 8, 9, 36, 37, 39, 46];

        disables = [16];

        tecla_especial = false
        for (var i in especiales) {
            if (key == especiales[i]) {
                tecla_especial = true;
                break;
            }
        }

        tecla_disabled = true
        for (var i in disables) {
            if (key == disables[i]) {
                disables = false;
                break;
            }
        }

        if (letras.indexOf(tecla) == -1 && !tecla_especial)
            return false;
    },

    solodecimales: function (e) { // 1
        solodouble(e, 'keypress');
        tecla = (document.all) ? e.keyCode : e.which;
        if (tecla == 8) return true;
        if (tecla == 9) return true;
        if (e.keyCode == 9) return true;
        patron = /[0123456789.1234567890]/; // 4
        te = String.fromCharCode(tecla); // 5
        return patron.test(te); // 6
    },


    solodni: function (objTxt) {
        //    by @lorena_lilian
        soloNumeros(objTxt, 'keypress');
        $(objTxt).bind({
            keypress: function (evt) {
                var dni = $(this).val();
                if (dni.length < 8 || evt.which == 8) {
                    return true;
                } else {
                    return false;
                }
            }
        })
    },

    deshabilitaPegar: function (obj) {
        $(obj).keydown(function (event) {
            var teclasNoPermitidas = new Array('c', 'x', 'v');
            var keyCode = (event.keyCode) ? event.keyCode : event.which;
            var esCtrl;
            esCtrl = event.ctrlKey
            if (esCtrl) {
                for (i = 0; i < teclasNoPermitidas.length; i++) {
                    if (teclasNoPermitidas[i] == String.fromCharCode(keyCode).toLowerCase()) {
                        return false;
                    }
                }
            }
            return true;
        });

        $(obj).bind('contextmenu', function (e) {
            return false;
        });
    },

    /*
	validaClave: function (obj, evt) {

		$(obj).bind(evt, function (e) {
			// set password variable
			var pswd = $(this).val();
			
			//validate letter
			if (pswd.match(/[A-z]/)) {
				return true;
			} else {
				return false;
			}

			//validate capital letter
			if (pswd.match(/[A-Z]/)) {
				return true;
			} else {
				return false;
			}

			//validate number
			if (pswd.match(/\d/)) {
				return true;
			} else {
				return false;
			}

			//Validate Caracter especial
			var caracter = "</*#$@%&(!|°¬~^¡?¿)>";

			if (pswd.match(caracter)) {
				return true;
			} else {
				return false;
			}

		})
	}
	*/
}