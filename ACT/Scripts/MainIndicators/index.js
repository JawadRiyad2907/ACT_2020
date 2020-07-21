$(function () {
    SearchItemTable();
});

function SearchItemTable() {
    var UserCategoryId = $("#SearchUserCategory").val();
    var JobTitleId = $("#SearchJobTitle").val();
    var UserId = $("#SearchUser").val();
    Metronic.blockUI({
        target: '.item-table'
    });
    $.ajax(
        {
            type: "GET",
            url: itemTableUrl,
            data: { UserCategoryId: UserCategoryId, JobTitleId: JobTitleId, UserId: UserId },
            success: function (data) {
                $(".item-table").html(data);
                Metronic.unblockUI('.item-table');
            },
        });
}





