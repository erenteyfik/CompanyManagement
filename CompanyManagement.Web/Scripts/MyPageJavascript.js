$(document).ready(function () {
    function Contains(text_one, text_two) {
        if (text_one.indexOf(text_two) != -1)
            return true;
    }
    $("#MySearch").keyup(function () {
        var searchText = $("#MySearch").val().toLowerCase();
        $(".MySearch").each(function () {
            if (!Contains($(this).text().toLowerCase(), searchText)) {
                $(this).hide();
            } else {
                $(this).show();
            }
        });
    });
});