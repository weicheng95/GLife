$(function () {
    $(document).delegate('#CreateArticleModal #CreateArticleBtn', 'click', function () {
        $('#CreateArticleModal form').submit();

    });
});

function onArticleModalCreateSuccess() {
    $('#CreateArticleModal').modal('hide');
    location.reload();
}