// @reference ~/Scripts/Public/common.js
/*!
* Popup jQuery Plugin v1.0
* Inspired by concept in jQuery Avgrund Popin Plugin
*
* Copyright 2012, E-Land systems
*
* History
* v1.0 - 최초 작성, subicura(2012/09/03)
* modal popup 추가 joe(2012/10/30)
*/

// TODO - 버튼 클릭시 callback

$.wf = $.wf || {}; 

; (function ($, window, document, undefined) {
    var wf_popup_class_prefix = "wf-popup-";
    var default_width = 380;
    var default_height = 200;
    var max_width = 640;
    var max_height = 480;

    var pluginName = 'wfPopup',
        defaults = {
            callback: null,
            header: null,
            footer: $('<a class="btn btn-primary" data-wf-dismiss="popup">OK</a>'),
            width: 0,
            height: 0,
            showClose: true,
            closeByEscape: true,
            closeByDocument: true,
            holderClass: '',
            enableStackAnimation: true,
            onBlurContainer: '',
            url: ''
        };

    function Plugin(msg, options) {
        this.msg = msg;
        this.options = $.extend({}, defaults, options);
        this.hasContentScroll = this.options.height > 0 ? true : false;
        this.maxWidth = this.options.width > 0 ? this.options.width : default_width,
        this.maxHeight = this.options.height > 0 ? this.options.height : default_height;
        this.url = this.options.url;
        this._defaults = defaults;
        this._name = pluginName;

        this.init();
    }

    // initialize function
    Plugin.prototype.init = function () {
        var _this = this;

        // header, msg, footer to jquery object
        this.options.header = $("<div></div>").append(this.options.header).clone(true);
        this.msg = $("<div></div>").append(this.msg).clone(true);
        this.options.footer = $("<div></div>").append(this.options.footer).clone(true);

        // detail
        if(this.options.detail) {
            var detail_btn = $('<div style="margin-top:10px;"><span class="label label-info ' + wf_popup_class_prefix + 'detail-btn" style="cursor:pointer">' + $.t('popup.detail_button') + '</span></div>').click(function(e) {
                if($("." +  wf_popup_class_prefix + "detail").css("display") == "none") {
                    $("." +  wf_popup_class_prefix + "detail").show();
                    _this.resize(max_width, max_height, true);
                    $("." +  wf_popup_class_prefix + "detail-btn").text($.t('popup.detail_close_button'));
                } else {
                    $("." +  wf_popup_class_prefix + "detail").hide();
                    _this.resize(_this.maxWidth, _this.maxHeight, _this.hasContentScroll);
                    $("." +  wf_popup_class_prefix + "detail-btn").text($.t('popup.detail_button'));
                }
            });
            this.msg.append(detail_btn);
            this.msg.append($("<pre class='" + wf_popup_class_prefix + "detail' style='display:none; margin-top:10px;'>" + this.options.detail + "</pre>"));
        }

        // dismiss event
        this.options.footer.on("click", '[data-wf-dismiss="popup"]', function() {
            if(_this.options.callback) {
                _this.options.callback.call(_this, $(this).data("wf-callback"));
            }
            _this.deactivate();
        });

        // click event
        this.activate.call(this);
    }

    Plugin.prototype.resize = function (w, h, hasContentScroll) {
        this.getPopupLayer().find('.' + wf_popup_class_prefix + 'content').css("height", "");

        var resizeHeight = h;
        var contentHeight = 0;

        if (hasContentScroll == true) {
            contentHeight = h -
                    this.getPopupLayer().find('.' + wf_popup_class_prefix + 'header').outerHeight() -
                    this.getPopupLayer().find('.' + wf_popup_class_prefix + 'footer').outerHeight();

            this.getPopupLayer().find('.' + wf_popup_class_prefix + 'content').css({
                'height': contentHeight + "px",
                'overflow-y': 'auto'
            });

        } else {
            contentHeight = this.getPopupLayer().find('.' + wf_popup_class_prefix + 'content').outerHeight();
            if (contentHeight < 50) {
                contentHeight = 50;
            }

            this.getPopupLayer().find('.' + wf_popup_class_prefix + 'content').css("height", contentHeight + "px");
        }

        resizeHeight = contentHeight + 
            this.getPopupLayer().find('.' + wf_popup_class_prefix + 'header').outerHeight() +
            this.getPopupLayer().find('.' + wf_popup_class_prefix + 'footer').outerHeight();


        /*
        var popup_top = ($(window).height() - this.getPopupLayer().height()) / 2;
        popup_top = (popup_top < 50) ? 50 : popup_top;
        */

        this.getPopupLayer().css({
            'width': w + 'px',
            'margin-left': '-' + (w / 2 + 10) + 'px',
            'margin-top': '-' + (resizeHeight / 2 + 10) + 'px'
        });
    }

    // show
    Plugin.prototype.activate = function () {
        var _this = this;

        setTimeout(function () {
            $("body").bind('keyup', { _this: _this }, _this.documentKeyup);
            $("body").bind('click', { _this: _this }, _this.documentClick);
        }, 300);


        if (this.options.enableStackAnimation == true) {
            this.getPopupLayer().addClass('stack');
        } else {
            this.getPopupLayer().removeClass('stack');
        }

        this.getPopupLayer().css({
            "-webkit-transition-duration": "0.0s",
            "-moz-transition-duration": "0.0s",
            "-ms-transition-duration": "0.0s",
            "-o-transition-duration": "0.0s",
            "transition-duration": "0.0s"
        });

        this.getPopupLayer().find('.' + wf_popup_class_prefix + 'header').empty().append(this.options.header.clone(true));
        this.getPopupLayer().find('.' + wf_popup_class_prefix + 'content').empty().append(this.msg.clone(true));
        this.getPopupLayer().find('.' + wf_popup_class_prefix + 'footer').empty().append(this.options.footer.clone(true));

        this.resize(this.maxWidth, this.maxHeight, this.hasContentScroll);

        if (this.options.showClose == true) {
            $('.' + wf_popup_class_prefix + 'close', this.getPopupLayer())
                .unbind("click")
                .click(function() {
                    if(_this.options.callback) {
                        _this.options.callback.call(_this, false);
                    }
                    _this.deactivate.call(_this);
                })
                .show();
        } else {
            $('.' + wf_popup_class_prefix + 'close', this.getPopupLayer()).hide();
        }

        if (this.options.onBlurContainer != '') {
            $(this.options.onBlurContainer).addClass('' + wf_popup_class_prefix + 'blur');
        }

        this.getPopupLayer().css({
            "-webkit-transition-duration": "0.4s",
            "-moz-transition-duration": "0.4s",
            "-ms-transition-duration": "0.4s",
            "-o-transition-duration": "0.4s",
            "transition-duration": "0.4s"
        });

        this.getPopupLayer().css({
            visibility:"visible",
            opacity:1.0
        });
        $("." + wf_popup_class_prefix + "overlay").css({
            visibility:"visible",
            opacity:1.0
        });
        $('.' + wf_popup_class_prefix + 'overlay').show().css("opacity", 0.5);
        $("body").addClass('' + wf_popup_class_prefix + 'active');
    }

    // hide
    Plugin.prototype.deactivate = function () {
        $("body").unbind('keyup', this.documentKeyup);
        $("body").unbind('click', this.documentClick);

        this.getPopupLayer().css({
            visibility:"hidden",
            opacity:0.0
        });
        $("." + wf_popup_class_prefix + "overlay").css({
            visibility:"hidden",
            opacity:0.0
        });
        $('.' + wf_popup_class_prefix + 'overlay').hide();
        $("body").removeClass('' + wf_popup_class_prefix + 'active');
    }

    // get layer
    Plugin.prototype.getPopupLayer = function () {
        var _this = this;

        var popup_layer = $("." + wf_popup_class_prefix + 'popin');
        if (popup_layer.length == 0) {
            popup_layer = this.createPopupLayer();
        }
        return popup_layer;
    }

    Plugin.prototype.createPopupLayer = function () {
        var _this = this;

        var popup_layer = $('<div class="' + wf_popup_class_prefix + 'popin ' + this.options.holderClass + '"></div>');
        popup_layer
            .append(
                $('<button type="button" class="close ' + wf_popup_class_prefix + 'close">&times;</button>')
            );

        var popup_header_layer = $('<div class="' + wf_popup_class_prefix + 'header"></div>')
        popup_layer.append(popup_header_layer);

        var popup_content_layer = $('<div class="' + wf_popup_class_prefix + 'content"></div>')
        popup_layer.append(popup_content_layer);

        var popup_footer_layer = $('<div class="' + wf_popup_class_prefix + 'footer"></div>')
        popup_layer.append(popup_footer_layer);

        popup_layer.css({
            'width': this.maxWidth + 'px',
            'margin-left': '-' + (this.maxWidth / 2 + 10) + 'px'
        });

        $("body").append(popup_layer);

        return popup_layer;
    }

    // key event
    Plugin.prototype.documentKeyup = function (e) {
        var _this = e.data._this;

        if (_this.options.closeByEscape == true) {
            if (e.keyCode === 27) {
                if(_this.options.callback) {
                    _this.options.callback.call(_this, false);
                }
                _this.deactivate();
            }
        }
    }

    // document click event
    Plugin.prototype.documentClick = function (e) {
        var _this = e.data._this;

        if (_this.options.closeByDocument == true) {
            if ($(e.target).is('.' + wf_popup_class_prefix + 'overlay')) {
                _this.deactivate();
            }
        }
    }

    // create default wf.popup jQuery plugin
    $.wf.popup = function (msg, options) {
        new Plugin(msg, options);
    }

    // Model popup
    $.wf.modal = function (msg, callback, options){
        if (jQuery.isPlainObject(callback)) {
            options = callback;
            callback = undefined;
        }
        this.msg = '<iframe width="100%" height="100%" src="'+options.url+'"></iframe>';
        var opt = options || {};
        opt.callback = callback;

        var footer = $('<a class="btn btn-primary" data-wf-dismiss="popup" data-wf-callback="false">'+$.t('popup.ok_button')+'</a>');
        opt.footer = footer;

        $.wf.message(this.msg, callback, opt);
    }

    // create alert
    $.wf.alert = function (msg, callback, options) {
        if (jQuery.isPlainObject(callback)) {
            options = callback;
            callback = undefined;
        }

        var opt = options || {};
        opt.callback = callback;

        var footer = $('<a class="btn btn-primary" data-wf-dismiss="popup" data-wf-callback="false">'+$.t('popup.ok_button')+'</a>');
        opt.footer = footer;

        $.wf.message(msg, callback, opt);
        
    }

    // create confirm
    $.wf.confirm = function (msg, callback, options) {
        if (jQuery.isPlainObject(callback)) {
            options = callback;
            callback = undefined;
        }

        var opt = options || {};
        opt.callback = callback;

        var footer = $("<div></div>");
        footer.append($('<a class="btn btn-primary" data-wf-dismiss="popup" data-wf-callback="true">'+$.t('popup.ok_button')+'</a>'));
        footer.append($('<a class="btn" data-wf-dismiss="popup" data-wf-callback="false" style="margin-left:10px;">'+$.t('popup.cancel_button')+'</a>'));
        opt.footer = footer;

        $.wf.message(msg, callback, opt);
        
    }

    $.wf.message = function (msg, callback, options) {
        var _this = this;

        var opt = $.extend({}, {
            type: "info",
            closeByDocument: false,
            callback: callback
        }, options);

        var header = $('<h5>' + $.t('popup.default_title') + '</h5>');
        if(opt.type) {
            var icon = "";
            if(opt.type == "success") {
                icon = "icon-ok";
            } else if(opt.type == "warning") {
                icon = "icon-warning-sign";
            } else if(opt.type == "important") {
                icon = "icon-exclamation-sign";
            } else if(opt.type == "info") {
                icon = "icon-info-sign";
            }
            header = $('<h5><i class="' + icon + '"></i> ' + $.t('popup.' + opt.type + '_title') + '</h5>');
        }

        opt.header = header;

        var popup = new Plugin(msg, opt);
    }

    $(function () {
        // global initialize
        $("body").addClass('' + wf_popup_class_prefix + 'ready');
        $("body").append($('<div class="' + wf_popup_class_prefix + 'overlay"></div>').css({
            visibility:"hidden",
            opacity:0.0
        }));
    });

})(jQuery, window, document);
