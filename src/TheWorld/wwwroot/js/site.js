﻿// site.js
(function () {

    var $sidebarAndWrapper = $("#sidebar, #wrapper");
    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $(this).text("Show Sidebar");
        } else {
            $(this).text("Hide Sidebar");
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

