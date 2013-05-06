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
    $("#add-synonym").click(function () {
        //check contains in list li
        if ($.trim($("#input-synonym").val()) == "") {
            alert("Chưa nhập từ!");
            $("#input-synonym").focus();
        } else {
            if (!$('#list-synonyms li:contains("' + $("#input-synonym").val() + '")').length) {
                $("#list-synonyms").append("<li><span class='label label-success'>" + $("#input-synonym").val() + " <a title='xóa' class='delete-synonym' href='javascript:'>x</a></span></li>")
                $("#input-synonym").val("");
                $("#input-synonym").focus();
            }
        }
    });

    $(".delete-synonym").live('click', function () {
        $(this).parent().parent().remove();
    });
});