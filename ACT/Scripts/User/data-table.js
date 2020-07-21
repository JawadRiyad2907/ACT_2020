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
                d.SearchLevel1 = $('#SearchLevel1').val();
                d.SearchLevel2 = $('#SearchLevel2').val();
                d.SearchLevel3 = $('#SearchLevel3').val();
                d.SearchLevel4 = $('#SearchLevel4').val();
                d.SearchUserCategory = $('#SearchUserCategory').val();
                d.SearchJobTitle = $('#SearchJobTitle').val();
                d.SearchFirstName = $('#SearchFirstName').val();
                d.SearchLastName = $('#SearchLastName').val();
                d.SearchEmail = $('#SearchEmail').val();
            },
        },
        "columns": [

            { "data": "FirstName", width: "150px" },
            { "data": "LastName", width: "150px" },
            { "data": "UserCategoryName", "autoWidth": true },
            { "data": "JobTitleName", "autoWidth": true },
            { "data": "GenderLoc", "autoWidth": true },
            { "data": "Email", "autoWidth": true },
            {
                data: "Active",
                render: function (data, type, row) {
                    if (data) {
                        return '<span class="glyphicon glyphicon-ok"></span>';
                    }
                    else {
                        return '<span class="glyphicon glyphicon-remove"></span>';
                    }
                }
            },
            {
                data: null, width: "350px", sortable: false, render: function (data, type, row) {
                    var html = '<a href="' + EditUrl + '/' + data.Id + '" class="btn default btn-xs blue-stripe"><i class="fa fa-edit"></i> تعديل</a>';
                    html += ' <a href="#" class="btn default btn-xs red-stripe" onClick="ConfirmDelete(' + data.Id + ')"><i class="fa fa-trash-o"></i> حذف</a>';
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