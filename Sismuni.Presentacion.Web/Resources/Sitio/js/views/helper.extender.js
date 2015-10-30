// EXTENSIÓN DE VALIDATE
$.fn.validacionSigen = function (param) {

    // Extensión de validación para no repetir los métodos
    if (param == undefined) { param = {}; }

    this.validate({

        rules: param.rules,

        messages: param.messages,

        highlight: function (element) {
            $(element).closest('.sigen-group').removeClass('has-success');
            $(element).closest('.sigen-group').addClass('has-error');
            $(element).addClass('sigen-required');
        },

        unhighlight: function (element) {
            $(element).closest('.sigen-group').removeClass('has-error');
            $(element).closest('.sigen-group').addClass('has-success');
            $(element).removeClass('sigen-required');
        },

        errorElement: 'span',

        errorClass: 'help-block',

        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length)
                error.insertAfter(element.parent());
            else if (element.parent('.none-group').length)
                error.insertAfter(element.parent());
            else
                error.insertAfter(element);
        }

        //submitHandler: function () {
        //    helperjs.hideWait();
        //}

    });
};

function noUpperFirstLetter(str) {
    return str.charAt(0).toLowerCase() + str.substr(1);
};

function upperFirstLetter(str) {
    return str.charAt(0).toUpperCase() + str.substr(1);
};

//Extensión de caracteres especiales
(function (a) { a.fn.SinCaracteresEpesciales = function (b) { a(this).on({ keypress: function (a) { var c = a.which, d = a.keyCode, e = String.fromCharCode(c).toLowerCase(), f = b; (-1 != f.indexOf(e) || 9 == d || 37 != c && 37 == d || 39 == d && 39 != c || 8 == d || 46 == d && 46 != c) && 161 != c || a.preventDefault() } }) } })(jQuery);