!function(){var s=$("#sidebar, #wrapper"),e=$("#sidebarToggle i.fa");$("#sidebarToggle").on("click",function(){s.toggleClass("hide-sidebar"),s.hasClass("hide-sidebar")?(e.removeClass("fa-angle-left"),e.addClass("fa-angle-right")):(e.addClass("fa-angle-left"),e.removeClass("fa-angle-right"))}),$("#hide").click(function(){$("#passwordform").hide(),$("#existinguserform").show()}),$("#show").click(function(){$("#passwordform").show(),$("#existinguserform").hide()})}();