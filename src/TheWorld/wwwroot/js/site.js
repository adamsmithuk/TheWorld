﻿// site.js
(function () {

    var $sidebarAndWrapper = $("#sidebar, #wrapper");
    var $icon = $("#sidebarToggle i.fa");

    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        } else {
            $icon.addClass("fa-angle-left");
            $icon.removeClass("fa-angle-right");
        }
    });



    //var ele = $("#username");
    //ele.text("Dylan Smith");

    //var main = $("#main");
    //main.on("mouseenter", function () {
    //    main.style.backgroundColor = "#888";
    //});
    //main.on("mouseleave", function () {
    //    main.style.backgroundColor = "";
    //});

    //var munItem = $("ul.menu li a");
    //munItem.on("click", function () {
    //    var me = $(this);
    //    alert(me.text());
    //});
    
})();

