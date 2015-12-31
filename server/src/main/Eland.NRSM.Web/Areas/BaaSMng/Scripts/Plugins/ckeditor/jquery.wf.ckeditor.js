// @reference ~/Scripts/Plugins/ckeditor/ckeditor.js
// @reference ~/Scripts/Plugins/ckeditor/adapters/jquery.js

$.wf.ckeditor = function (obj, language, filebrowserImageUploadUrl, option) {
    var config = {
        filebrowserImageUploadUrl: filebrowserImageUploadUrl
    };

    config.toolbar_Full =
            [
                { name: 'styles', items: ['Font', 'FontSize'] },
                { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] },
                { name: 'colors', items: ['TextColor', 'BGColor'] },
                { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'] },
                { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
                { name: 'insert', items: ['Image', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'] },
                { name: 'tools', items: ['Maximize', 'ShowBlocks', '-', 'About'] }
            ];

    if (language == "ko") {
        config.font_defaultLabel = '돋움';
        config.font_names = '돋움/dotum;돋움체/dotumche;굴림/gulim;굴림체/gulimche;바탕/batang;바탕체/batangche';
        config.fontSize_defaultLabel = '12';
    }
    config.language = language;

    $.extend(true, config, option);

    obj.ckeditor(config);
}