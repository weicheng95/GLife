$(function () {
    $(document).delegate('#CreateRecordModal #createBtn', 'click', function () {
        $('#CreateRecordModal form').submit();

    });
});

//article submit successful event
function onRecordModalCreateSuccess() {
    $('#CreateRecordModal').modal('hide');
    location.reload();
}

$(function () {
    $('#calender').datepicker({
        altFormat: "yy/mm/dd",
        dateFormat: "yy/mm/dd",
        onSelect: function (date) {
            //alert(date);
            $.ajax({
                type: "GET",
                url: "/Home/List",
                data: "Date=" + date,
                dataType: "html",
                contentType: 'application/html; charset=utf-8',
                success: function (data) {
                    $('#TableList').html(data);
                },
                error: function () {
                    alert("Error occured!!")
                }
            });
        }
    });
});

