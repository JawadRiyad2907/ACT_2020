$(document).ready(function () {
    FillLLevel1();
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
                d.SearchLevel3 =$('#SearchLevel3').val();
                d.SearchName = $('#SearchName').val();
            },
        },
        "columns": [

          
            { "data": "Level1Name", width: "250px" },
            { "data": "Level2Name", width: "250px" },
            { "data": "Level3Name", width: "250px" },
            { "data": "Name", width: "250px" },
            { "data": "DisplayOrder", "autoWidth": true },
            {
                data: "Published",
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
                data: null, width: "200px", sortable: false, render: function (data, type, row) {
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
            onDeleteComplete(data);
            SearchDataTable();
        },
        error: function () {
            alert("Error occured!!")
        }
    });
}


function FillLLevel1() {
    $.ajax({
        dataType: "json",
        type: "GET",
        url: fillLevel1Url,
        success: function (data) {
            $.each(data, function (i, data) {
                $("#SearchLevel1").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
        }
    });
}

function FillLLevel2() {
    var Level1Id = $("#SearchLevel1").val();
    if (!Level1Id) {
        EmptyingLevel2();
        return;
    }
    $.ajax({
        dataType: "json",
        type: "GET",
        data: { Level1Id: Level1Id },
        url: fillLevel2Url,
        success: function (data) {
            EmptyingLevel2();
            $.each(data, function (i, data) {
                $("#SearchLevel2").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
        }
    });


}

function FillLLevel3() {
    var Level2Id = $("#SearchLevel2").val();
    if (!Level2Id) {
        EmptyingLevel3();
        return;
    }
    $.ajax({
        dataType: "json",
        type: "GET",
        data: { Level2Id: Level2Id },
        url: fillLevel3Url,
        success: function (data) {
            EmptyingLevel3();
            $.each(data, function (i, data) {
                $("#SearchLevel3").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
        }
    });


}



function EmptyingLevel2() {
    $("#SearchLevel2").empty();
    $("#SearchLevel2").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#SearchLevel2').val('').trigger('change');
}
function EmptyingLevel3() {
    $("#SearchLevel3").empty();
    $("#SearchLevel3").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#SearchLevel3').val('').trigger('change');
}


$('#SearchLevel1').on("change", function (e) {
    FillLLevel2();
});
$('#SearchLevel2').on("change", function (e) {
    FillLLevel3();
});






