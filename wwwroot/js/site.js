// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    const stepPayment = $("#stepPayment");

    $("#changeStacks").change((stacks) => {
        if (stacks.currentTarget.value == 1) {
            stepPayment.addClass("visually--hidden")
        }       
        if (stacks.currentTarget.value == 2) {
            stepPayment.removeClass("visually--hidden")
        } 
    })

   
    
});