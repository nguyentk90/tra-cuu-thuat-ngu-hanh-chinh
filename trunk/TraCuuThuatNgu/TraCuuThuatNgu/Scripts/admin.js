//js for admin

$(document).ready(function () {

    //change order searching history list
    $("#order-search-history").change(function () {

        var url = window.location.href;
        var indexOfOrderBy = url.indexOf("&orderby");
        var indexOfPage = url.indexOf("page");

        if (indexOfOrderBy == -1) {
            if (indexOfPage == -1) {
                url = window.location + "?orderby=" + $("#order-search-history").val();
            } else {
                url = window.location + "&orderby=" + $("#order-search-history").val();
            }
        } else {
            url = url.substr(0, indexOfOrderBy) + "&orderby=" + $("#order-search-history").val(); ;
        }
        window.location.href = url;

    });
});