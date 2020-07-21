$(document).ready(function () {
    fillMyItem();
    SearchPerformanceTable();
});


function fillMyItem() {
    $.ajax({
        dataType: "json",
        type: "GET",
        url: fillMyItemUrl,
        success: function (data) {
            $.each(data, function (i, data) {
                $("#SearchMyItem").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
            //selected value if variable exsist
            if (typeof SearchSelectedMyItem != 'undefined') {
                $('#SearchMyItem').val(SearchSelectedMyItem).trigger('change');
                SearchSelectedMyItem = 'undefined';
            }
        }
    });
}


function SearchPerformanceTable() {
    var SearchMyItem = $("#SearchMyItem").val();
    if (!SearchMyItem) {
        SearchMyItem = SearchSelectedMyItem;
    }

    Metronic.blockUI({
        target: '.performance-table'
    });
    $.ajax(
        {
            type: "GET",
            url: performanceTableUrl,
            data: { SearchMyItem: SearchMyItem },
            success: function (data) {
                $(".performance-table").html(data);
                Metronic.unblockUI('.performance-table');
            },
        });
}