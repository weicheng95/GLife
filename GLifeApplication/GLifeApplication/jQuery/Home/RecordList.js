$(function () {
    $(document).delegate('#CreateFoodRecordModal #CreateFoodBtn', 'click', function () {
        $('#CreateFoodRecordModal form').submit();

    });
});

$(function () {
    $(document).delegate('#CreateSportRecordModal #CreateSportBtn', 'click', function () {
        $('#CreateSportRecordModal form').submit();

    });
});

$(function () {
    $(document).delegate('#CreateTestRecordModal #CreateFoodBtn', 'click', function () {
        $('#CreateTestRecordModal form').submit();

    });
});

//article submit successful event
function onRecordModalCreateSuccess() {
    $('#CreateRecordModal').modal('hide');
    location.reload();
}

