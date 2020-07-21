


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






