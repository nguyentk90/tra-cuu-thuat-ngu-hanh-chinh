//js for admin

$(document).ready(function () {


    //change order searching history list
    $("#order-search-history").change(function () {

        var url = window.location.href;
        var indexOfOrderBy = url.indexOf("orderby");
        var indexOfPage = url.indexOf("?");

        if (indexOfPage != -1) {
            if (indexOfOrderBy != -1) {
                url = url.substr(0, indexOfOrderBy) + "orderby=" + $("#order-search-history").val();
            } else {
                url = window.location + "&orderby=" + $("#order-search-history").val();
            }
        } else {
            url = window.location + "?orderby=" + $("#order-search-history").val();
        }
        window.location.href = url;

    });




    //add synonym

    var synonyms = new Array();
    $("#list-synonyms li").each(function (index) {
        console.log(index + ": " + $(this).children().children().first().text());
        synonyms.push($(this).children().children().first().text());
    });

    $("#add-synonym").click(function () {
        //check contains in list li
        if ($.trim($("#input-synonym").val()) == "") {
            alert("Chưa nhập từ!");
            $("#input-synonym").focus();
        } else {
            if (synonyms.indexOf($("#input-synonym").val()) == -1) {
                synonyms.push($("#input-synonym").val());
                $("#list-synonyms").append("<li><span class='label label-success'><span>" + $("#input-synonym").val() + "</span> <a title='xóa' class='delete-synonym' href='javascript:'>x</a></span></li>")
                $("#input-synonym").val("");
                $("#input-synonym").focus();
            }
        }
    });

    $(".delete-synonym").live('click', function () {
        $(this).parent().parent().remove();
        var i = synonyms.indexOf($(this).prev().text());
        synonyms.splice(i, 1);
    });


    //edit synset form
    $("#edit-synset-form").submit(function () {
        $("#synonyms-data").val(synonyms);
        return true;
    });


    /*DELETE USER HISTORY*/
    $(".btn-comment-delete").click(function () {

        var checkDelete = confirm('Bạn có chắc muốn xóa không?');

        var row = $(this).parent().parent();

        if (checkDelete) {
            $.ajax({
                url: '/Comment/Delete',
                type: 'POST',
                data: "{ 'commentId': '" + $(this).children().val() + "'}",
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


    $("#btn-delete-user").click(function () {

        var checkDelete = confirm("Bạn có chắc muốn xóa thành viên này!");
        if (checkDelete) {
            $.ajax({
                url: '/Users/Delete',
                type: 'POST',
                data: "{ 'userId': '" + $("#userId").val() + "'}",
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.message == 'SUCCESS') {
                        alert("Xóa thành công!");
                        window.location.href ='/Users';
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