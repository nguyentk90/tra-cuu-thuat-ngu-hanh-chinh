$(document).ready(function () {

    /*LOGIN*/
    //------------------------------------------------
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


    /*LIKE*/
    //-----------------------------------------------
    //like button
    $('#like-check').click(function () {
        var checkLogOn = confirm('Hãy đăng nhập dùng chức năng này.');
        if (checkLogOn) {
            popUpLogonOpen();
        }
    });

    //like button
    $('#like-submit').click(function () {
        $.ajax({
            url: '/Like/Add',
            type: 'POST',
            data: "{ 'headWord': '" + $('#headWord').text() + "'}",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data.message == 'SUCCESS') {
                    var counter = $('.count-like').html();
                    counter++;
                    $('.count-like').html(counter);
                    alert("Đã thêm vào thuật ngữ yêu thích.");
                } else if (data.message == 'EXISTED') {
                    alert("Bạn đã thích từ này");
                } else {
                    alert("Lỗi thêm yêu thích");
                }


            },
            error: function () {
                alert("error");
            }
        });
    });


    /*VALIDATE*/
    //----------------------------------------------------
    //check space and special characters
    $("#search-form").submit(function () {
        if ($.trim($("#search-input").val()) == "") {
            alert("Bạn chưa nhập từ");
            return false;            
        } else { 
            var regex = /[~`!#@$%\^&*+=\-\[\]\\;,/{}|\\"':<>\?]/g ;   
            if(regex.test($("#search-input").val()))
            {
                alert("Không nhập ký tự đặc biệt.");
                return false;
            }
            return true;                       
        }
    });

    //check space comment form
    $("#comment-form").submit(function () {
        if ($.trim($("#comment-content").val()) == "") {
            alert("Bạn chưa nhập nhận xét");
            return false;            
        } else {             
            return true;                       
        }
    });



    /*DELETE USER HISTORY*/
    $(".btn-delete").click(function(){
            
        var checkDelete = confirm('Bạn có chắc muốn xóa không?');

        var row = $(this).parent().parent();

        if (checkDelete) {        
            $.ajax({
                url: '/UserHistory/Delete',
                type: 'POST',
                data: "{ 'historyId': '" + $(this).children().val() + "'}",
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.message == 'SUCCESS') {                        
                        row.slideUp('slow');
                    } else {
                        alert("Lỗi");
                    } 
                },
                error: function () {
                    alert("error");
                }
            });            
        }           
    });


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

    //focus to input field
    //$('#UserName').focus();
}

function popUpLogonClose() {
    $('.ui-widget-overlay').hide();
    $('.ui-dialog').hide();
}
