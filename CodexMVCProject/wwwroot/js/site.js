// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    $("#btnsubmit").click(function (e) {

        $.ajax({
            url: "/Product/AddProduct",
            type: "POST",
            dataType: 'json',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: $("#productform").serialize(),
            success: function (response) {
                // Handle the response from the server here
                
                if (response.success) {
                    $('#valid-feedback').show();
                    setTimeout(function () {
                        $('#valid-feedback').hide();
                    }, 3000);
                }
                else {
                    $('#invalid-feedback').show();
                    setTimeout(function () {
                        $('#invalid-feedback').hide();
                    }, 3000);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });

    });
});
