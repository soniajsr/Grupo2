window.bootpopup = window.bootpopup || (function init($, undefined) {
    "use strict";

    var templates = {
        dialog:
          "<div class='bootbox modal' tabindex='-1' role='dialog'>" +
            "<div class='modal-dialog'>" +
              "<div class='modal-content'>" +
                "<div class='modal-body'><div class='bootbox-body'></div></div>" +
              "</div>" +
            "</div>" +
          "</div>",
        header:
          "<div class='modal-header'>" +
            "<h4 class='modal-title' id='mod-title'></h4>" +
          "</div>",
        footer:
          "<div class='modal-footer sigen-popup-footer'></div>",
        closeButton:
          "<button type='button' data-bb-handler='closeDialog' class='bootbox-close-button close'>&times;</button>"
    };

    var appendTo = $("body");

    var defaults = {
        // show backdrop or not
        backdrop: true,
        // animate the modal in/out
        animate: true,
        // additional class string applied to the top level dialog
        className: null,
        // whether or not to include a close button
        closeButton: true,
        // show the dialog immediately by default
        show: true
    };

    var exports = {};

    function processCallback(e, dialog, callback) {
        e.preventDefault();

        // by default we assume a callback will get rid of the dialog,
        // although it is given the opportunity to override this

        // so, if the callback can be invoked and it *explicitly returns false*
        // then we'll set a flag to keep the dialog active...
        var preserveDialog = $.isFunction(callback) && callback(e) === false;

        // ... otherwise we'll bin it
        if (!preserveDialog) {
            dialog.modal("hide");
        }
    }

    function getKeyLength(obj) {
        // @TODO defer to Object.keys(x).length if available?
        var k, t = 0;
        for (k in obj) {
            t++;
        }
        return t;
    }

    function each(collection, iterator) {
        var index = 0;
        $.each(collection, function (key, value) {
            iterator(key, value, index++);
        });
    }

    function sanitize(options) {
        var buttons;
        var total;

        if (typeof options !== "object") {
            throw new Error("Por favor ingrese las opciones");
        }

        if (!options.data) {
            throw new Error("Por favor especifique la data a motrar");
        }

        // make sure any supplied options take precedence over defaults
        options = $.extend({}, defaults, options);

        if (!options.buttons) {
            options.buttons = {};
        }

        // we only support Bootstrap's "static" and false backdrop args
        // supporting true would mean you could dismiss the dialog without
        // explicitly interacting with it
        options.backdrop = options.backdrop ? "static" : false;

        buttons = options.buttons;

        total = getKeyLength(buttons);

        each(buttons, function (key, button, index) {

            //verificamos que este asignado
            if (button == null) { total--; return };

            if ($.isFunction(button)) {
                // short form, assume value is our callback. Since button
                // isn't an object it isn't a reference either so re-assign it
                button = buttons[key] = {
                    callback: button
                };
            }

            // before any further checks make sure by now button is the correct type
            if ($.type(button) !== "object") {
                throw new Error("button with key " + key + " must be an object");
            }

            if (!button.label) {
                // the lack of an explicit label means we'll assume the key is good enough
                button.label = key;
            }

            if (!button.className) {
                if (total <= 2 && index === total - 1) {
                    // always add a primary to the main option in a two-button dialog
                    button.className = "btn-primary";
                } else {
                    button.className = "btn-default";
                }
            }
        });

        return options;
    }

    exports.dialog = function (options) {
        options = sanitize(options);

        var dialog = $(templates.dialog);
        var body = dialog.find(".modal-body");
        var buttons = options.buttons;
        var buttonStr = "";

        var callbacks = {};
        if (options.buttons.cerrarValidar != undefined)
            var callbacks = {
                onEscape: options.buttons.cerrarValidar.callback
            };
        else
            var callbacks = {
                onEscape: options.onEscape
            };


        each(buttons, function (key, button) {

            //verificamos que este asignado
            if (button == null) return;

            buttonStr += "<button data-bb-handler='" + key + "' type='button' class='btn " + button.className + "'>" + button.label + "</button>";
            callbacks[key] = button.callback;
        });

        body.find(".bootbox-body").html(options.data);

        if (options.animate === true) {
            dialog.addClass("fade");
        }

        if (options.className) {
            dialog.addClass(options.className);
        }

        if (options.title) {
            body.before(templates.header);
        }

        if (options.closeButton) {
            var closeButton = $(templates.closeButton);
            if (options.buttons.cerrarValidar != undefined)
                callbacks["closeDialog"] = options.buttons.cerrarValidar.callback;
            if (options.title) {
                dialog.find(".modal-header").prepend(closeButton);
            } else {
                closeButton.css("margin-top", "-10px").prependTo(body);
            }
        }

        if (options.title) {
            dialog.find(".modal-title").html(options.title);
        }

        if (buttonStr.length) {
            body.after(templates.footer);
            dialog.find(".modal-footer").html(buttonStr);
        }


        dialog.on("hidden.bs.modal", function (e) {
            // ensure we don't accidentally intercept hidden events triggered
            // by children of the current dialog. We shouldn't anymore now BS
            // namespaces its events; but still worth doing
            if (e.target === this) {
                dialog.remove();
            }
        });


        dialog.on("shown.bs.modal", function () {
            if (options.afterShow != undefined)
                options.afterShow();
            dialog.find(".btn-primary:first").focus();
            $("[title]").tooltip();
        });

        /**
         * Bootbox event listeners; experimental and may not last
         * just an attempt to decouple some behaviours from their
         * respective triggers
         */

        dialog.on("escape.close.bb", function (e) {
            if (callbacks.onEscape) {
                processCallback(e, dialog, callbacks.onEscape);
            }
        });

        /**
         * Standard jQuery event listeners; used to handle user
         * interaction with our dialog
         */

        dialog.on("click", ".modal-footer button", function (e) {
            var callbackKey = $(this).data("bb-handler");

            processCallback(e, dialog, callbacks[callbackKey]);

        });

        dialog.on("click", ".bootbox-close-button", function (e) {
            // onEscape might be falsy but that's fine; the fact is
            // if the user has managed to click the close button we
            // have to close the dialog, callback or not
            processCallback(e, dialog, callbacks.onEscape);
        });

        dialog.on("keyup", function (e) {
            if (e.which === 27) {
                dialog.trigger("escape.close.bb");
            }
        });

        // the remainder of this method simply deals with adding our
        // dialogent to the DOM, augmenting it with Bootstrap's modal
        // functionality and then giving the resulting object back
        // to our caller

        appendTo.append(dialog);

        // Eventos
        dialog.on('show.bs.modal', function (e) {
            if (options.beforeShow != undefined)
                options.beforeShow();
        })

        dialog.modal({
            backdrop: options.backdrop,
            keyboard: false,
            show: false,
            modalTop: options.modalTop
        });

        dialog.attr("id", options.id);

        if (options.modalTop != undefined)
            dialog.addClass("modal-top");

        if (options.show) {
            dialog.modal("show");
        }

        return dialog;

    };

    exports.hideAll = function () {
        $(".bootbox").modal("hide");
    };

    exports.init = function (_$) {
        window.bootpopup = init(_$ || $);
    };

    return exports;

}(window.jQuery));
