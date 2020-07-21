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
        "ordering": false,
        "destroy": true,
        "pageLength": 5,
        "ajax": {
            "url": GridUrl,
            "type": "GET",
            "datatype": "json",
            data: function (d) {
                d.SearchLevelName = $('#SearchLevelName').val();
                d.SearchResponsibleName = $('#SearchResponsibleName').val();
            },
        },
        "columns": [
            { "data": "LevelName" },
            {
                data: "ResponsibleName", render: function (data, type, row) {
                    if (data) {
                        return data;
                    }
                    else {

                        return '<span class="badge badge-danger">' + withoutResponsibleLoc + ' </span>';
                    }
                }
            },
            {
                data: null, width: "200px", sortable: false, render: function (data, type, row) {
                    var html = '<a href="' + EditUrl + '?LevelId=' + row.LevelId + '" class="btn default btn-xs blue-stripe"><i class="fa fa-edit"></i> تعديل</a>';
                    return html;
                }
            },

        ],
        "language": {
            "emptyTable": emptyTableLoc,
            "zeroRecords": zeroRecordsLoc,
            "loadingRecords": loadingRecordsLoc,
            "processing": loadingRecordsLoc,
            "infoEmpty": "",
            "info": "_TOTAL_ " + totalRecord,
        }
    });
}


function SearchDataTable() {
    $('#grid-object').DataTable().ajax.reload();
}

