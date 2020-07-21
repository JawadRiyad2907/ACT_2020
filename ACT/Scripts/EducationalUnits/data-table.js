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
        "paging": false,
        "destroy": true,
        "ajax": {
            "url": GridUrl,
            "type": "GET",
            "datatype": "json",
            data: function (d) {
                d.SearchLevel1 = $('#SearchLevel1').val();
                d.SearchLevel2 = $('#SearchLevel2').val();
                d.SearchLevel3 = $('#SearchLevel3').val();
                d.SearchLevel4 = $('#SearchLevel4').val();
                d.SearchName = $('#SearchName').val();
            },
        },
        "columns": [
            {
                width: "30px",
                title: '',
                className: 'treegrid-control',
                data: function (item) {
                    if (item.children && item.children.length != 0) {
                        return '<span><i  class="fa fa-plus"></i></span>';
                    }
                    return '';
                },

            },
            { "data": "Name", width: "350px" },

            {
                width: "150px",
                data: function (data, type, row) {
                    return '<a onclick="allUnitUserModal(' + data.Id + ')">' + viewAllUsersLoc + '</a>';
                },
            },
            { "data": "CountAdditiveUsers", width: "150px" },
            { "data": "DisplayOrder", "autoWidth": true },
            {
                data: null, sortable: false, render: function (data, type, row) {
                    var html = '<a href="' + AddUnitUserUrl + '?unitId=' + data.Id + '&type=1" class="btn default btn-xs purple-stripe unit-user"><i class="fa fa-user"></i>تسكين </a>';
                    return html;
                }
            },
            {
                data: null, sortable: false, render: function (data, type, row) {

                    var html = '<a href="' + AddChildUrl + '?ParentId=' + data.Id + '" class="btn default btn-xs purple-stripe"><i class="fa fa-plus"></i> اضافة فرع</a>';
                    return html;
                }
            },
            {
                data: null, sortable: false, render: function (data, type, row) {
                    var html = '<a href="' + EditUrl + '/' + data.Id + '" class="btn default btn-xs blue-stripe"><i class="fa fa-edit"></i> تعديل</a>';
                    return html;
                }
            },
            {
                data: null, sortable: false, render: function (data, type, row) {
                    var html = ' <a href="#" class="btn default btn-xs red-stripe" onClick="ConfirmDelete(' + data.Id + ')"><i class="fa fa-trash-o"></i> حذف</a>';
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
        },
        'treeGrid': {
            'left': 10,
            'expandIcon': '<span><i class="fa fa-plus"></i></span>',
            'collapseIcon': '<span><i class="fa fa-minus"></i></span>'
        }
    });
}


function SearchDataTable() {
    $('#grid-object').DataTable().ajax.reload();
}

function allUnitUserModal(unitId) {
    $('#userUnitBody').html('<i class="fa fa-circle-o-notch fa-spin fa-3x fa-fw margin-bottom"></i>' + loadingRecordsLoc);
    $('#userUnitModal').modal('show');
    $.ajax({
        type: "POST",
        url: allUserUnitUrl,
        data: { unitId: unitId },
        success: function (data) {
            $('#userUnitBody').html(data);
        }
    });
}