$(document).ready(function () {
    FillUserCategoryForUserDirectResponsable();
});

function FillUserCategoryForUserDirectResponsable() {
    $.ajax({
        dataType: "json",
        type: "GET",
        url: fillUserCategoryForUserDirectResponsableUrl,
        success: function (data) {
            $.each(data, function (i, data) {
                $("#SearchUserCategory").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
        }
    });
}
function FillJobTitleForUserDirectResponsable() {
    var UserCategoryId = $("#SearchUserCategory").val();
    $.ajax({
        dataType: "json",
        type: "GET",
        data: { UserCategoryId: UserCategoryId },
        url: fillJobTitleForUserDirectResponsableUrl,
        success: function (data) {
            EmptyingJobTitleForUserDirectResponsable();
            $.each(data, function (i, data) {
                $("#SearchJobTitle").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
        }
    });
}

function fillUsersForUserDirectResponsable() {
    var UserCategoryId = $("#SearchUserCategory").val();
    var JobTitleId = $("#SearchJobTitle").val();
    $.ajax({
        dataType: "json",
        type: "GET",
        data: { JobTitleId: JobTitleId, UserCategoryId: UserCategoryId },
        url: fillUsersForUserDirectResponsableUrl,
        success: function (data) {
            EmptyingUsersForUserDirectResponsable();
            $.each(data, function (i, data) {
                $("#SearchUser").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
        }
    });
}


function EmptyingJobTitleForUserDirectResponsable() {
    $("#SearchJobTitle").empty();
    $("#SearchJobTitle").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#SearchJobTitle').val('').trigger('change');
}

function EmptyingUsersForUserDirectResponsable() {
    $("#SearchUser").empty();
    $("#SearchUser").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#SearchUser').val('').trigger('change');
}

$('#SearchUserCategory').on("change", function (e) {
    FillJobTitleForUserDirectResponsable();
});
$('#SearchJobTitle').on("change", function (e) {
    fillUsersForUserDirectResponsable();
});