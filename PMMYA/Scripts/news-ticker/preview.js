$(function(){$("#layout2, #layout3, #layout4").css("display","none").children(".modern-ticker").modernTicker("pause");$("#theme li").click(function(){var a=$(this);if(!a.hasClass("selected")){$("#theme .selected").removeClass("selected");a.addClass("selected");$("#style-sheet").attr("href","mticker-assets/theme"+a.html().split(" ")[1]+"/modern-ticker.css")}});$("#layout li").click(function(){var a=$(this);if(!a.hasClass("selected")){$("#layout .selected").removeClass("selected");a.addClass("selected");$(".active").removeClass("active").css("display","none").children(".modern-ticker").modernTicker("pause");$("#layout"+a.html().split(" ")[1]).css("display","block").addClass("active").children(".modern-ticker").modernTicker("resume")}});$("#corners li").click(function(){var a=$(this);if(!a.hasClass("selected")){$("#corners .selected").removeClass("selected");a.addClass("selected");var b=$(".modern-ticker");if(b.hasClass("mticker-round")){b.removeClass("mticker-round")}else{b.addClass("mticker-round")}}})})