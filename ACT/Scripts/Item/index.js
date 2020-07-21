$(function () {
    SearchItemTable();
});

function SearchItemTable() {
    var UserCategoryId = $("#SearchUserCategory").val();
    if (!UserCategoryId) {
        UserCategoryId = SearchSelectedCategoryId;
    }
    Metronic.blockUI({
        target: '.item-table'
    });
    $.ajax(
        {
            type: "GET",
            url: itemTableUrl,
            data: { UserCategoryId: UserCategoryId },
            success: function (data) {
                $(".item-table").html(data);
                $('.make-switch').bootstrapSwitch();
                $('.make-switch').on('switchChange.bootstrapSwitch', function (event, state) {
                    EditNA(UserCategoryId, event.target.dataset.itemId, state);
                });
                Metronic.unblockUI('.item-table');
            },
        });
}



function EditNA(UserCategoryId, itemId, isNA) {
    Metronic.blockUI({
        target: '.item-table'
    });
    $.ajax({
        type: "POST",
        url: EditNAUrl,
        data: { UserCategoryId: UserCategoryId, itemId, itemId, isNA: isNA },
        datatype: "json",
        success: function (data) {
            Metronic.unblockUI('.item-table');
        },
        error: function () {
            alert("Error occured!!")
        }
    });
}

