$(function () {
    $(document).ready(function () {
        var table = $('#dtPaciente').DataTable({
            "pageLength": 10,
            "bSort": false,
            "bLengthChange": false
        });

        $(window).bind('resize', function () {
            $.fn.dataTable.tables({ visible: true, api: true }).columns.adjust();
        });
    });

    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });


    $("#btnAdd").click(function () {
        $("#btnAdd").addClass("hidden");
        $("#btnCancel").removeClass("hidden");
    });

    $("#btnCancel").click(function () {
        $('#FrmNewPaciente').trigger("reset");
        $(".has-error").hide();
        $("#btnAdd").removeClass("hidden");
        $("#btnCancel").addClass("hidden");
    });
});
