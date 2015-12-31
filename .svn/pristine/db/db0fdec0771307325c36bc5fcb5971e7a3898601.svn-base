$(function () {
    $(".span12").find(".dataTable").dataTable({
        "sPaginationType": "bootstrap",
        //"sScrollX": "100%",
        //"sScrollXInner": "110%",
        //"bScrollCollapse": true, 
        "oLanguage": {
            "sLengthMenu": "_MENU_ records per page"
        }
    });

    $(".span12").find(".dataTable>tbody").on("click", function (event) {
        var result = $(event.target.parentNode).find(".icon-info-sign").parent().attr("href");
        if (result != null)
            location.assign(result);
    });
});