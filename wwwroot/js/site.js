// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
'use strict'
$(document).ready(function () {

    const stepPayment = $("#stepPayment")

    $("#changeStacks").change((stacks) => {
        if (stacks.currentTarget.value == 1) {
            stepPayment.addClass("visually--hidden")
        }       
        if (stacks.currentTarget.value == 2) {
            stepPayment.removeClass("visually--hidden")
        } 
    })  

    $("#sumPayment").bind('input', function () {
        $(this).val($(this).val().replace(/[^0-9\.]/g, ''))
    })

    $("#termPayment").bind('input', function () {
        $(this).val($(this).val().replace(/[^0-9\.]/g, ''))
    })

    $("#stacksPayment").bind('input', function () {
        $(this).val($(this).val().replace(/[^0-9\.]/g, ''))
    })


});