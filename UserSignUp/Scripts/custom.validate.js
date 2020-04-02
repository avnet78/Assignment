$(function () {

    $("#showPwd").change(function () {
        var checked = $(this).is(":checked");
        if (checked) {
            $("#Password").attr("type", "text");
        } else {
            $("#Password").attr("type", "password");
        }
    });
});