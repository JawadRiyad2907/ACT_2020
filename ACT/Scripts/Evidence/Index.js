﻿$(document).ready(function () {
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
                d.SearchStandardId = $('#SearchStandardId').val();
                d.SearchName = $('#SearchName').val();
            },
        },
        "columns": [
            { "data": "EvidenceDescription", width: "350px" },
            { "data": "DisplayOrder", "autoWidth": true },
            {
                data: null, width: "300px", sortable: false, render: function (data, type, row) {
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


function ConfirmDelete(Id) {
    swal({
        title: deleteTitle,
        icon: "warning",
        buttons: {
            ok: {
                text: deleteOkButton,
                value: 'ok',
                className: "swal-button--danger"

            },
            close: {
                text: deleteCancelButton,
                value: 'close',
                className: "swal-button--cancel"
            },
        },
    })
        .then((value) => {
            switch (value) {
                case "ok":
                    DeleteObject(Id);
                    break;
                default:
            }
        });
}



function DeleteObject(Id) {
    $.ajax({
        type: "POST",
        url: DeleteUrl,
        data: { Id: Id },
        datatype: "json",
        success: function (data) {
            debugger;
            onDeleteComplete(data);
            SearchDataTable();
        },
        error: function () {
            alert("Error occured!!")
        }
    });
}