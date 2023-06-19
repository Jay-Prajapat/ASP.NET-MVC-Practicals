$(document).ready(function () {
    $("#btn_printText").click(function () {
        $("#lblMessage").html("Hello World");
        
    });
    $("#btn_Bold").click(function () {
        $("#lblMessage").css("font-weight", "bold");
    });

    $("#btn_Italic").click(function () {
        $("#lblMessage").css("font-style", "italic");
    });
    $("#btn_Underline").click(function () {
        $("#lblMessage").css("text-decoration", "underline");
    });
    $("#btn_Reset").click(function () {
        $("#lblMessage").removeAttr("style");
    });
});

