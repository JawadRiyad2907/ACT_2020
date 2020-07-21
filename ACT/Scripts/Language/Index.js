
$(document).ready(function () {
    buildDataTable();
});

function buildDataTable() {
    $("#grid-object").DataTable({
        "searching": false,
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": false, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "lengthChange": false,
        "destroy": true,
        "ajax": {
            "url": GridUrl,
            "type": "GET",
            "datatype": "json",
        },
        "columns": [

            { "data": "Name", "autoWidth": true },
            { "data": "LanguageCulture", "autoWidth": true },
            { "data": "DisplayOrder", "autoWidth": true },
            { "data": "Published", "autoWidth": true },
            { "data": "Rtl", "autoWidth": true },
            {
                data: null, width: 250, sortable: false, render: function (data, type, row) {
                    var html = '<a href="#" class="btn default btn-xs blue-stripe"><i class="fa fa-edit"></i> تعديل</a>';
                    html += ' <a href="#" class="btn default btn-xs red-stripe"><i class="fa fa-trash-o"></i> حذف</a>';
                    html += ' <a href="#" class="btn default btn-xs green-stripe"><i class="fa fa-eye"></i> عرض مصادر اللغة</a>'; return html;
                }
            },

        ],
        //"language": {
        //    "emptyTable": locEmpty,
        //    "zeroRecords": locEmpty,
        //    "loadingRecords": locLoading
        //}
    });
}