$(document).ready(function () {
    // focus on the first visible input
    $('#site-body input:visible, #site-body select').first().focus();

    // configure metismenu
    $('#metismenu').metisMenu();

    // Hide menu by default when loading on mobile
    if ($(window).width() < 768) {
        $('#site-nav').removeClass('show');
    }

    $('#site-nav-toggle').on('click', function (e) {
        $('#site-nav').toggleClass('show');
    });

    $('.delete-confirm').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        $('#delete-modal').modal('show');
        $('#delete-confirm').attr('href', $(this).attr('href'));
        $('#delete-cancel').focus();
    });
});