$(document).ready(function () {
    buildDataTable();
});

function buildDataTable() {
    var table = $("#grid-object").DataTable({
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
                d.SearchName = $('#SearchName').val();
            },
        },
        "columns": [
            {
                className: 'details-control',
                orderable: false,
                data: null,
                defaultContent: '',
                width: "30px"
            },
            { "data": "Name", width: "350px" },
            { "data": "LevelName", width: "350px" },
            { "data": "DisplayOrder", "autoWidth": true },
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
                    html += '<a href="' + EditPrivelages + '?Id=' + data.Id + '" class="btn default btn-xs purple-stripe"><i class="fa fa-lock"></i> تعديل الصلاحيات</a>';
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
  
    $('#grid-object tbody').on('click', 'td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            row.child.hide();
            tr.removeClass('shown');
        }
        else {
            row.child(format(row.data())).show();
            buildPrivilegesTree(row.data());
            tr.addClass('shown');
        }
    });
}


function SearchDataTable() {
    $('#grid-object').DataTable().ajax.reload();
}


function format(rowData) {
    var div = $('<div id="privilegesTree_' + rowData.Id + '" class="tree-demo"><div/>')
        .addClass('loading')
        .text(loadingRecordsLoc + '...');
    return div;
}


function buildPrivilegesTree(rowData) {

    var $treeview = $('#privilegesTree_' + rowData.Id).jstree({
        'plugins': ["wholerow", "checkbox", "types"],
        'core': {
            expand_selected_onload: false, 
            "themes": {
                "responsive": true,
            },
            "check_callback": false,
            'data': {
                'url': menuPrivelageUrl + '?Id=' + rowData.Id,
                'data': function (node) {
                    return { 'id': node.id };
                }
            }
        }
    }).on('refresh.jstree', function () {
        $treeview.jstree('close_all');
    }).on('loaded.jstree', function () {
        $treeview.jstree('close_all');
    });
}