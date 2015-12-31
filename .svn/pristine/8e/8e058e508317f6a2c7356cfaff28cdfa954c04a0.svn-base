// @reference ../jquery-1.8.1.js
// @reference ../popup/jquery.wf.popup.js
// @reference ../spin.js

// TODO : error customzing
// loading bar 여러번

$.wf = $.wf || {};

$.wf.loadingOpts = {
    type: "spin",
    imagePath: "/Content/Images/Public/ajax-loader.gif",
    lines: 13, // The number of lines to draw
    length: 7, // The length of each line
    width: 4, // The line thickness
    radius: 10, // The radius of the inner circle
    corners: 1, // Corner roundness (0..1)
    rotate: 0, // The rotation offset
    color: '#000', // #rgb or #rrggbb
    speed: 1, // Rounds per second
    trail: 60, // Afterglow percentage
    shadow: false, // Whether to render a shadow
    hwaccel: false, // Whether to use hardware acceleration
    className: 'spinner', // The CSS class to assign to the spinner
    zIndex: 2e9, // The z-index (defaults to 2000000000)
    top: 'auto', // Top position relative to parent in px
    left: 'auto' // Left position relative to parent in px
};

$.each(["get", "post"], function (i, method) {
    $.wf[method] = function (url, data, callback, type, loading, loadingOpts) {
        // shift arguments if data argument was omitted
        if (jQuery.isFunction(data) || data.success !== undefined) {
            loadingOpts = loading;
            loading = type;
            type = callback;
            callback = data;
            data = undefined;
        }
        loadingOpts = $.extend({}, $.wf.loadingOpts, loadingOpts);

        var efwCallback = {
            success: function (data, statusText, jqXHR) { },
            failure: function (data, statusText, jqXHR) {
                $.wf.alert(data.msg, { 'type': 'warning' });
            },
            jsonError: function (data, statusText, jqXHR) {
                $.wf.alert("Json Syntax Error", { 'type': 'warning' });
            },
            serverError: function (xhr, statusText, thrownError) {
                var errorHandleCodes = ["404", "500"];
                for (var i in errorHandleCodes) {
                    var code = errorHandleCodes[i];
                    if (xhr.status == code) {
                        var detail = "";
                        var data = $.parseJSON(xhr.responseText);
                        for (var key in data) {
                            detail += "[" + key + "] " + data[key] + "<br />";
                        }
                        $.wf.alert(xhr.status + " - " + thrownError, { 'type': 'warning', 'detail': detail });
                        break;
                    }
                }
            }
        };
        if (jQuery.isFunction(callback)) {
            efwCallback.success = callback;
        } else { // 객체
            $.extend(efwCallback, callback);
        }

        var ajaxCallback = function (data, statusText, jqXHR) {
            if (data.result == "success") {
                efwCallback.success(data.data, statusText, jqXHR);
            } else if (data.result == "failure") {
                efwCallback.failure(data, statusText, jqXHR);
            } else {
                efwCallback.jsonError(data, statusText, jqXHR);
            }
        };

        var loadingImage = null;
        var loadingBackground = null;
        var spinner = null;

        if (loading && loading.length > 0) {
            loadingBackground = $("<div style='position:absolute;'></div>");

            if (loadingOpts.type == "image") {
                loadingImage = $("<img src='" + loadingOpts.imagePath + "' style='position:absolute'>");
                loadingBackground.append(loadingImage.css({
                    "top": loading.outerHeight() / 2 - 50,
                    "left": loading.outerWidth() / 2 - 50
                })).css({
                    "backgroundColor": "#FFF",
                    "opacity": "0.4"
                });
            } else {
                spinner = new Spinner(loadingOpts).spin(loading[0]);
            }

            $("body").append(loadingBackground.css({
                "top": loading.offset().top + "px",
                "left": loading.offset().left + "px",
                "width": loading.outerWidth() + "px",
                "height": loading.outerHeight() + "px"
            }));
        }

        return jQuery.ajax({
            type: method,
            url: url,
            data: data,
            success: ajaxCallback,
            traditional :true,
            dataType: type
        }).error(function (xhr, statusText, thrownError) {
            efwCallback.serverError(xhr, statusText, thrownError);
        }).always(function () {
            if (loadingOpts.type == "image") {
                if (loadingImage) {
                    loadingImage.remove();
                }
            } else {
                if (spinner) {
                    spinner.stop();
                }
            }
            if (loadingBackground) {
                loadingBackground.remove();
            }
        });
    };
});


