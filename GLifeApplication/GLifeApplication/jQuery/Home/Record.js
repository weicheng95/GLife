$(function () {
    $(document).delegate('.modal #editBtn', 'click', function () {
        $('.modal form').submit();
    });
});

$(function () {
    $(document).delegate('#DeleteArticleModal #deleteBtn', 'click', function () {
        $('#DeleteArticleModal form').submit();
    });
});

$(function () {
    $(document).on('click', '.foodname', function (event) {
        event.preventDefault();
        var id = $(this).attr('value');
        var parent = $(this);
        $.ajax({
            type: "GET",
            url: "/Home/FoodDBDetail",
            data: "id=" + id,
            success: function (data) {
               
                $('.well-DBdetail').slideDown();
                $('.foodDB-detail').html(data);
            }
        });
    });
});

$(function () {
    $("#txtSportName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Home/AutoCompleteForSport/',
                data: "{ 'prefix': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },

        select: function (e, i) {
            $("#hfSportId").val(i.item.val);
        },

        minLength: 1
    });

    $(document).on('click', '.sportname', function () {
        var id = $(this).attr('value');
        var parent = $(this);
        $.ajax({
            type: "GET",
            url: "/Home/SportDBDetail",
            data: "id=" + id,
            success: function (data) {
                $('.well-DBdetail').slideDown();
                $('.SportDB-detail').html(data);
            }
        });
    });
});