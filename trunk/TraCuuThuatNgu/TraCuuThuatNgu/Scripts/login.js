$(document).ready(function () {

    //dropdown-menu user login
    $('#user-login').click(function () {
        $('.dropdown-menu').slideToggle('slow');
    });

    //close menu when click outside form this
    $(document).mouseup(function (e) {
        console.log(e.target.id);
        if (e.target.id != 'user-login') {
            var container = $('.dropdown-menu');
            if (container.has(e.target).length == 0) {
                container.hide();
            }
        }
    });


    //Open logon popup
    $('.popUpLogon').click(popUpLogonOpen);

    //Close logon popup
    $('#close-popup').click(popUpLogonClose);

});

function popUpLogonOpen() {
    //over-lay
    var windowWidth = $(window).width();
    var windowHeight = $(window).height();
    $('.ui-widget-overlay').css("width", windowWidth + "px");
    $('.ui-widget-overlay').css("height", windowHeight + "px");
    $('.ui-widget-overlay').show();

    //popup div
    var top = windowHeight / 2 - $('.ui-dialog').height() / 2;
    var left = windowWidth / 2 - $('.ui-dialog').width() / 2;
    console.log(top + "-" + left)
    $('.ui-dialog').css("top", top + "px");
    $('.ui-dialog').css("left", left + "px");
    $('.ui-dialog').slideDown('slow');
}

function popUpLogonClose() {
    $('.ui-widget-overlay').hide();
    $('.ui-dialog').hide();
}
